using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Track { BASS, GUITAR, FATWA, VOICE, ALL }

struct Time
{
    public int minutes;
    public int seconds;

    public Time(int pMinutes, int pSeconds)
    {
        minutes = pMinutes;
        seconds = pSeconds;
    }
}

enum PlayerByColor {PURPLE, PINK, ORANGE, RED}

struct OneMotion
{
    public MotionType type;
    public Track track;
    public Time time;

    public OneMotion(MotionType pType, Track pTrack, Time pTime)
    {
        type = pType;
        track = pTrack;
        time = pTime;
    }
}

public class TimelineManager : MonoBehaviour
{
    private static TimelineManager instance;

    private TimelineManager() { }

    private List<OneMotion> motionsList = new List<OneMotion>();

    public void Setup()
    {
        SetupMotion();
    }

    private void SetupMotion()
    {
        motionsList.Add(OneMotion())
    }

    public static TimelineManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TimelineManager();
            }
            return instance;
        }
    }
}
