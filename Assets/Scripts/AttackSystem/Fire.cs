using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Fire : MonoBehaviour
{
    [SerializeField] protected float speed;

    public ObjectPool<Fire> Pool { get; internal set; }

    public static event Action OnAttack;

    public virtual void Attack(Vector3 pos)
    {
        transform.position = new Vector3(pos.x, pos.y - transform.localScale.y / 2, pos.z);
        OnAttack?.Invoke();
    }
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            collision.collider.GetComponent<Ball>().Explode();
        }
        Pool.Release(this);
    }
}
