using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    //[SerializeField] private Sound[] sounds;
    [SerializeField] private AudioClip fireSound; 
    [SerializeField] private AudioClip ballExplodeSound;

    [SerializeField] private AudioSource source;
    void OnEnable()
    {
        Ball.OnExplode += BallExplodeSound;
        Fire.OnAttack += FireSound;
    }

    private void FireSound()
    {
        source.clip = fireSound;
        source.Play();
    }

    private void BallExplodeSound(Ball obj)
    {
        source.clip = ballExplodeSound;
        source.Play();
    }
    private void OnDisable()
    {
        Ball.OnExplode -= BallExplodeSound;
        Fire.OnAttack -= FireSound;
    }
}
