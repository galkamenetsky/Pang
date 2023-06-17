using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LootSystem : MonoBehaviour
{
    [SerializeField] private LootObject lootObject;
    [SerializeField] private Loot[] loots;
    [SerializeField] private int lootChance;
    [SerializeField] private int minCapacity;
    [SerializeField] private int maxCapacity;
    [SerializeField] private float size;
    [SerializeField] private float timeToDisapear;
    private ObjectPool<LootObject> pool;
    private void Start()
    {
        Ball.OnExplode += GenerateLoot;
        InitPool();
    }

   
    private void InitPool()
    {
        pool = new ObjectPool<LootObject>(() => {
            LootObject lootObj = Instantiate(lootObject, transform);
            lootObj.Size = size;
            return lootObj;
        }, loot => {
            loot.gameObject.SetActive(true);
        }, loot => {
            loot.gameObject.SetActive(false);
        }, loot => {
            Destroy(loot.gameObject);
        }, true, minCapacity, maxCapacity);
    }

    private void GenerateLoot(Ball ball)
    {
        if(Random.Range(0,100) < lootChance)
        {
            LootObject loot = pool.Get();
            int index = Random.Range(0, loots.Length);
            loot.Init(loots[index], ball.Position,pool);
        }
    }


    private void OnDisable()
    {
        Ball.OnExplode -= GenerateLoot;
    }
}
