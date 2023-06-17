using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "new Level", menuName = "Level Generator/New Level")]
public class LevelInfo : ScriptableObject
{
    [Serializable]
    public class BallInfo
    {
        public Vector2 position;
        public Vector2 velocity;
        public float size;
        public BallInfo(Vector2 pos, float size)
        {
            this.position = pos;
            velocity = Vector2.zero;
            this.size = size;
        }
    }
    public BallInfo[] balls;
    public int levelTime;
}
