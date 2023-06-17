using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private BallGenerator gene;
    [SerializeField] private GenerateLevel generateLevel;
    [SerializeField] private Timer timer;
    [SerializeField] private PlayerHit playerHit;
    [SerializeField] private TMP_Text lifeText; 
    public event Action<bool> OnLevelWin;
    public event Action<bool> OnLevelFailed;
    public static int currentLevel;
    private void OnEnable()
    {
        gene.NoBallsRemain += LevelWinHandle;
        timer.OnTimerEnded += LevelFailedHandle;
        playerHit.OnPlayerHit += LevelFailedHandle;
        Time.timeScale = 1;
        lifeText.text = PlayerPrefManager.Life.ToString();
    }
    private void Start()
    {
        generateLevel.LoadLevel(currentLevel);
    }

    private void LevelFailedHandle()
    {
       int currentLives = --PlayerPrefManager.Life;
       OnLevelFailed?.Invoke(currentLives > 0);
    }

    private void LevelWinHandle()
    {
        currentLevel++;
        bool isLevelExist = generateLevel.IsLevelExist(currentLevel);
        if (!isLevelExist)
            currentLevel = 0;
        OnLevelWin?.Invoke(isLevelExist);
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
    private void OnDisable()
    {
        gene.NoBallsRemain -= LevelWinHandle;
        timer.OnTimerEnded -= LevelFailedHandle;
        playerHit.OnPlayerHit -= LevelFailedHandle;
    }
}
