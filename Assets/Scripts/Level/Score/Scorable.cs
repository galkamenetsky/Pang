using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scorable : MonoBehaviour
{
    public static event Action<int> OnScoreObtained;
    public abstract int CalculatePoints();
    private void OnDisable() => OnScoreObtained?.Invoke(CalculatePoints());
}
