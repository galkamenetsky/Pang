using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelEndUI : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Button gameOverButton;
    [SerializeField] private Button startLevelButton;

    public string TitleText
    {
        set => titleText.text = value;
    }
    public string ScoreText
    {
        set => scoreText.text = value;
    }
    public bool GameOver
    {
        set
        {
            if (value)
                gameOverButton.gameObject.SetActive(true);
            else
                startLevelButton.gameObject.SetActive(true);
        } 
    }
}
