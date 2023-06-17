using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class IMusicPlayer : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private AudioSource audioSource;
   
    private float volume;
    protected abstract float CurrentVolume { get; set; }
    void Start()
    {
        volume = CurrentVolume;
        audioSource.volume = volume;
    }
    public void ChangeVolume(float v)
    {
        audioSource.volume = v;
        CurrentVolume = v;
    }
}
