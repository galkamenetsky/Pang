using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Sound : MonoBehaviour
{
    [HideInInspector]  public AudioSource source;
    public string clipName;
    public AudioClip audioClip;
    public bool isLoop;
    public bool isOnAwake;

    [Range(0, 1)]
    public float volume = 0.5f;
}
