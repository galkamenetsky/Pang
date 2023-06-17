using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlacerBall : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;
    public float Size { get; set; }
    public Vector2 Velocity { get => velocity; set => velocity = value; }
    public Vector3 Position { get => transform.position; set => transform.position = value; }
}
