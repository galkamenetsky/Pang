using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BallFactory : MonoBehaviour
{
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private Transform container;
    [SerializeField] private Vector2 startVelocity;
    [SerializeField] private float offsetPosition;
    [SerializeField] private int minCapacity;
    [SerializeField] private int maxCapacity;

    private ObjectPool<Ball> ballPool;

    public static event Action OnBallCreated;

    private void Awake()
    {
        InitPool();
    }
    public int BallRemian { get => ballPool.CountActive; }
    private void InitPool()
    {
        ballPool = new ObjectPool<Ball>(() => {
            Ball ball = Instantiate(ballPrefab, container);
            ball.Pool = ballPool;
            return ball;
        }, ball => {
            ball.gameObject.SetActive(true);
        }, ball => {
            ball.gameObject.SetActive(false);
        }, ball => {
            Destroy(ball.gameObject);
        }, true, minCapacity, maxCapacity);
    }

    public void GetBallAfterExplode(Vector3 position, float size)
    {
        GetBall(new Vector3(position.x + offsetPosition, position.y, position.z), startVelocity, size/2);
        GetBall(new Vector3(position.x - offsetPosition, position.y, position.z), new Vector2(-1 * startVelocity.x, startVelocity.y), size/2);
    }
    public void GetBall(Vector3 pos, Vector2 velocity, float size)
    {
        Ball b = ballPool.Get();
        b.Position = pos;
        b.Velocity = velocity;
        b.Size = size;
        OnBallCreated?.Invoke();
    }
    private void OnDisable()
    {
      //  ballPool.Clear();
    }
}
