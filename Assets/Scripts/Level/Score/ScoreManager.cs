using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Level level;
    [SerializeField] private int scoreMultiplier;
    [SerializeField] private TMP_Text scoreText;
    private int score;
    public int Score
    {
        get => score;
        private set
        {
            score = value;
            scoreText.text = score.ToString();
        }
    }

    void Awake()
    {
        Score = PlayerPrefManager.Score;
    }

    private void OnEnable()
    {
        Scorable.OnScoreObtained += UpdateScore;
        level.OnLevelWin += (levelRemains) => PlayerPrefManager.Score = Score;
        
    }

    private void UpdateScore(int score)
    {
        Score += score;
    }

    private void OnDisable()
    {
        Scorable.OnScoreObtained -= UpdateScore;
        level.OnLevelWin -= (levelRemains) => PlayerPrefManager.Score = Score;
    }
}
