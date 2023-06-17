using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeData : MonoBehaviour
{
    [SerializeField] private int life;
    [Range(0f,1f)]
    [SerializeField] private float volumeBG;
    [Range(0f, 1f)]
    [SerializeField] private float volumeEffects;

    private void Awake()
    {
        PlayerPrefManager.Life = life;
        PlayerPrefManager.Score = 0;
        if (PlayerPrefManager.FirstOpenApp)
        {
            PlayerPrefManager.VolumeBG = volumeBG;
            PlayerPrefManager.VolumeInGame = volumeEffects;
            PlayerPrefManager.FirstOpenApp = false;
        }

    }
    private void OnApplicationQuit()
    {
        PlayerPrefManager.FirstOpenApp = true;
    }

}
