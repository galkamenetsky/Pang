using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Ball : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 velocity;
    [SerializeField] private int sizeScaleRatio;
    [SerializeField] private ObjectPool<Ball> pool;
   
    public static event Action<Ball> OnExplode;
    public ObjectPool<Ball> Pool { set => pool = value; }
    public float Size {
        get => transform.localScale.x*sizeScaleRatio;
        set
        {
            transform.localScale = new Vector3(value/ sizeScaleRatio, value/ sizeScaleRatio, value/ sizeScaleRatio);
        }
    }
    public Vector2 Velocity { get => rb.velocity; set => rb.velocity = value; }
    public Vector3 Position { get => transform.position; set => transform.position = value; }

    public void Explode()
    {
        if (gameObject.activeSelf == false)
            return;
        pool.Release(this);
        OnExplode?.Invoke(this);
    }
}
