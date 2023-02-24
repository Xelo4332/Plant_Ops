using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource soundEffectSource;
    public static AudioManager instance = null;
    private AudioClip _currentSoundEffect;
    public AudioClip CurrentSoundEffct => _currentSoundEffect;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        soundEffectSource.clip = clip;
        soundEffectSource.Play();
        if (_currentSoundEffect != clip)
        {
            _currentSoundEffect = clip;
        }
    }

    public void ClearSoundEffect()
    {
        soundEffectSource.Stop();
        soundEffectSource.clip = null;
        _currentSoundEffect = null;
    }
}
// abdi
