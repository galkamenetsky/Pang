using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [SerializeField] private BallFactory ballFactory;
    [SerializeField] private Timer timer;
    public List<LevelInfo> levels;

    public void LoadLevel(int level)
    {
        foreach (LevelInfo.BallInfo ball in levels[level].balls)
        {
            ballFactory.GetBall(ball.position, ball.velocity, ball.size);
        }
        timer.SetTime(levels[level].levelTime);
    }

    public bool IsLevelExist(int level) => level < levels.Count;
}
