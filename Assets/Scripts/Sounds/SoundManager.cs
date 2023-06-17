using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get => instance;
    }
    [SerializeField] private AudioSource bgAudioSource;
    [SerializeField] private AudioSource gfxAudioSource;
    [SerializeField] private AudioClip[] bgClips;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        if (bgClips.Length == 0)
            Destroy(this);
        StartCoroutine(Loop());
    }
    IEnumerator Loop()
    {
        int index = 0;
        while(true)
        {
            bgAudioSource.clip = bgClips[index];
            bgAudioSource.Play();
            yield return new WaitUntil(()=> bgAudioSource.isPlaying == false);
            index = (index++) % bgClips.Length;
        }
    }
    public float BGVolume { set => bgAudioSource.volume = value; }
    public float GFXVolume { set => gfxAudioSource.volume = value; }

}
