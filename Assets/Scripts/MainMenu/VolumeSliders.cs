using System;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliders : MonoBehaviour
{
    [SerializeField] private Slider sliderBG;
    [SerializeField] private Slider sliderGFX;
    void Start()
    {
        sliderBG.value = PlayerPrefManager.VolumeBG;
        sliderBG.onValueChanged.AddListener(SetBgVolume);
        SetBgVolume(sliderBG.value);

        sliderGFX.value = PlayerPrefManager.VolumeInGame;
        sliderGFX.onValueChanged.AddListener(SetGFXVolume);
        SetGFXVolume(sliderGFX.value);
    }
    protected virtual void SetBgVolume(float volume)
    {
        SoundManager.Instance.BGVolume = volume;
        PlayerPrefManager.VolumeBG = volume;
    }
    protected virtual void SetGFXVolume(float volume)
    {
        SoundManager.Instance.GFXVolume = volume;
        PlayerPrefManager.VolumeInGame = volume;
    }
}
