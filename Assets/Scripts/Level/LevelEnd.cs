using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private Level level;
    [SerializeField] private LevelEndUI levelEndUI;

    [SerializeField] private string levelFailedText;
    [SerializeField] private string gameOverText;

    [SerializeField] private string levelWinText;
    [SerializeField] private string gameWinText;
    private void Start()
    {
        level.OnLevelFailed += OnLevelFailed;
        level.OnLevelWin += OnLevelWin;

    }
    private void OnLevelWin(bool levelRemains)
    {
        level.Pause();
        levelEndUI.ScoreText = PlayerPrefManager.Score.ToString();
        if (levelRemains)
        {
            levelEndUI.TitleText = levelWinText;
            levelEndUI.GameOver = false;
        }
        else
        {
            levelEndUI.TitleText = gameWinText;
            levelEndUI.GameOver = true;
        }
        levelEndUI.gameObject.SetActive(true);
    }

    private void OnLevelFailed(bool lifeRemains)
    {
        level.Pause();
        levelEndUI.ScoreText = PlayerPrefManager.Score.ToString();
        if (lifeRemains)
        {
            levelEndUI.TitleText = levelFailedText;
            levelEndUI.GameOver = false;
        }
        else
        {
            levelEndUI.TitleText = gameOverText;
            levelEndUI.GameOver = true;
        }
        levelEndUI.gameObject.SetActive(true);
    }

}
