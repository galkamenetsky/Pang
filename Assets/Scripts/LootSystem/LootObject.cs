using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class LootObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renderer;
    private ObjectPool<LootObject> pool;
    public string Name { get; private set; }
    public float Size { set => renderer.size = new Vector2(value,value); }
    public void Init(Loot loot,Vector3 position, ObjectPool<LootObject> pool)
    {
        renderer.sprite = loot.image;
        Name = loot.lootName;
        transform.position = position;
        this.pool = pool;
    }
   
    public void Release()
    {
        pool.Release(this); 
    }
}
