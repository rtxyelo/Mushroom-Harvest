using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSoundBehaviour : MonoBehaviour
{
    [SerializeField]
    private AudioSource _hitSound;

    [SerializeField]
    private AudioSource _coinSound;

    [SerializeField]
    private AudioSource _beeSound;

    private readonly string _volumeKey = "Volume";

    public void PlayHitSound()
    {
        if (_hitSound != null)
        {
            _hitSound.volume = PlayerPrefs.GetFloat(_volumeKey);
            _hitSound.Play();
        }
    }

    public void PlayCoinSound()
    {
        if ( _coinSound != null)
        {
            _coinSound.volume = PlayerPrefs.GetFloat(_volumeKey);
            _coinSound.Play();
        }
    }

    public void PlayBeeSound()
    {
        if (_beeSound != null)
        {
            _beeSound.volume = PlayerPrefs.GetFloat(_volumeKey);
            _beeSound.Play();
        }
    }
}
