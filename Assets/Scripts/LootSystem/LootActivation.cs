using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LootActivation : MonoBehaviour
{
    public UnityEvent OnExtraFire;
    public UnityEvent OnToggleFire;
    public UnityEvent OnExtraLife;


    private void Start()
    {
        LootCollector.OnLoot += LootCollector_OnLoot;
    }
    private void OnDisable()
    {
        LootCollector.OnLoot -= LootCollector_OnLoot;
    }
    private void LootCollector_OnLoot(LootObject lootObject)
    {
        switch (lootObject.Name)
        {
            case "FireChange":
                OnToggleFire?.Invoke();
                break;
            case "ExtraFire":
                OnExtraFire?.Invoke();
                break;
            default:
                break;
        }
        lootObject.Release();
    }
}
