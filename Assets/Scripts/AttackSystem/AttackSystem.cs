using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] private Fire[] fireTypes;
    [SerializeField] private Transform fireContainer;
    [SerializeField] private Transform firePosition;
    [SerializeField] private int attacksInTheSameTime;
    [SerializeField] private float attackOffset;
    private ObjectPool<Fire> firePool;
    int currentAmountOfAttacks;
    int fireIndex;

    private void Start()
    {
        currentAmountOfAttacks = 0;
        fireIndex = 0;
        InitPool(fireTypes[fireIndex]);
    }
    private void InitPool(Fire fireType)
    {
        firePool = new ObjectPool<Fire>(() => {
            Fire fire =  Instantiate(fireType, fireContainer);
            fire.Pool = firePool;
            return fire;
        }, fire => {
            fire.gameObject.SetActive(true);
            currentAmountOfAttacks++;
        }, fire => {
            fire.gameObject.SetActive(false);
            currentAmountOfAttacks--;
        }, fire => {
            Destroy(fire.gameObject);
        }, false, 3, 10);
    }
    public void IncreaseAttacksInTheSameTime()
    {
        attacksInTheSameTime++;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;
        if (currentAmountOfAttacks == attacksInTheSameTime)
            return;
        Vector3 attackInit = new Vector3(firePosition.position.x, firePosition.position.y, firePosition.position.z);
        firePool.Get().Attack(attackInit);
    }
    public void ToggleFire()
    {
        fireIndex = (++fireIndex) % fireTypes.Length;
        firePool.Clear();
        InitPool(fireTypes[fireIndex]);
    }
}
