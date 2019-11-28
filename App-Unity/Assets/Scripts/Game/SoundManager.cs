using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    private SoundManager() { }

    public AudioSource musicSource;
    public AudioSource timelineSource;

    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;


    public void Setup()
    {

    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.PlayOneShot(clip);
    }

    public void ChangePitch(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.pitch = 1.5f;
    }

    public void UpVolume(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.volume = musicSource.volume + 0.1f;
        Debug.Log(musicSource.volume);

    }

    public void DownVolume(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.volume = musicSource.volume - 0.1f;
        Debug.Log(musicSource.volume);

    }

    public float GetCurrentTime()
    {
        return timelineSource.time;

    }

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SoundManager();
            }
            return instance;
        }
    }
}