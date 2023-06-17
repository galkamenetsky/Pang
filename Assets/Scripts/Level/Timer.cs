using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private TMP_Text timeText;
    public event Action OnTimerEnded;

    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = ((int)time).ToString();
        if (time <= 0f)
        {
            OnTimerEnded?.Invoke();
            enabled = false;
        }
    }
    public void SetTime(float time) => this.time = time;
}
