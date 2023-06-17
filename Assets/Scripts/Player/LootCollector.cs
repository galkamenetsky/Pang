using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootCollector : MonoBehaviour
{
    public static event Action<LootObject> OnLoot;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Loot"))
        {
           LootObject lootObject = other.GetComponent<LootObject>();
            OnLoot?.Invoke(lootObject);
        }
    }
}
