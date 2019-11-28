using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Music : MonoBehaviour
{
    private static Music instance;

    private Music() { }

    public enum Track { BASS, GUITAR, FATWA, VOICE, ALL }

    AudioSource drums;
    AudioSource bass;
    AudioSource guitars;
    AudioSource keyboard1;
    AudioSource keyboard2;
    AudioSource fatwa;
    AudioSource voice;

    public void Setup()
    {

    }

    public void StartMusic()
    {
        //SoundManager.Instance.PlayMusic(drums);
        drums = GameObject.Find("Drums").GetComponent<AudioSource>();
        drums.Play();

        bass = GameObject.Find("Bass").GetComponent<AudioSource>();
        bass.Play();

        guitars = GameObject.Find("Guitars").GetComponent<AudioSource>();
        guitars.Play();

        keyboard1 = GameObject.Find("Keyboard1").GetComponent<AudioSource>();
        keyboard1.Play();

        keyboard2 = GameObject.Find("Keyboard2").GetComponent<AudioSource>();
        keyboard2.Play();

        fatwa = GameObject.Find("Extras").GetComponent<AudioSource>();
        fatwa.Play();

        voice = GameObject.Find("Vocals").GetComponent<AudioSource>();
        voice.Play();
    }

    public void ChangeTrackSound(Track track, float percent)
    {
        switch(track)
        {
            case Track.BASS:
                bass.volume *= percent;
                break;
            case Track.GUITAR:
                guitars.volume *= percent;
                break;
            case Track.FATWA:
                fatwa.volume *= percent;
                break;
            case Track.VOICE:
                voice.volume *= percent;
                break;
            case Track.ALL:
                break;
        }
    }

    public void ResetTrackSound(Track track)
    {
        switch (track)
        {
            case Track.BASS:
                bass.volume = 1f;
                break;
            case Track.GUITAR:
                guitars.volume = 1f;
                break;
            case Track.FATWA:
                fatwa.volume = 1f;
                break;
            case Track.VOICE:
                voice.volume = 1f;
                break;
            case Track.ALL:
                break;
        }
    }

    public float GetElapsedTime()
    {
        return drums.time;
    }

    public static Music Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Music();
            }
            return instance;
        }
    }
}
