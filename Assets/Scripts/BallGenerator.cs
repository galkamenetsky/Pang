using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallFactory))]
public class BallGenerator : MonoBehaviour
{
    private BallFactory factory;

    public event Action NoBallsRemain;


    void Start()
    {
        factory = GetComponent<BallFactory>();
        Ball.OnExplode += OnExplode;
    }
  
    private void OnExplode(Ball ball)
    {
       if(ball.Size <= 1)
       {
            if (factory.BallRemian == 0)
                NoBallsRemain?.Invoke();
       }
       else
       {
            factory.GetBallAfterExplode(ball.Position,ball.Size);
       }
    }
    private void OnDisable()
    {
        Ball.OnExplode -= OnExplode;
    }
}
