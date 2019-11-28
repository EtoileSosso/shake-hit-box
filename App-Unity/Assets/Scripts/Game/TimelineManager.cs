using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Track { BASS, GUITAR, FATWA, VOICE, ALL, NONE }

public struct LocalTime
{
    public int minutes;
    public int seconds;

    public LocalTime(int pMinutes = 0, int pSeconds = 0)
    {
        minutes = pMinutes;
        seconds = pSeconds;
    }
}

public enum PlayerByColor {PURPLE, PINK, ORANGE, RED}

public struct OneMotion
{
    public MotionType type;
    public Track track;
    //public LocalTime time;
    public int time;
    public int iterations;
    public List<PlayerByColor> players;

    public OneMotion(MotionType pType = MotionType.NONE, Track pTrack = Track.NONE, int pTime = 0, int pIterations = 0, List<PlayerByColor> pPlayers = null)
    {
        type = pType;
        track = pTrack;
        time = pTime;
        iterations = pIterations;
        players = pPlayers;
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
        GetMotionList();
    }

    public OneMotion CheckForCurrentMotion(int seconds)
    {
        //Debug.Log(motionsList.Count);
        foreach(OneMotion current in motionsList)
        {
            if(current.time == seconds)
            {
                return current;
            }
        }
        return new OneMotion(MotionType.NONE, Track.NONE);
    }

    private void GetMotionList()
    {
        // At 10 seconds
        motionsList.Add(
            new OneMotion(
                MotionType.HORIZONTAL,
                Track.FATWA,
                1, // TODO set to 10
                4,
                new List<PlayerByColor>() { PlayerByColor.PURPLE, PlayerByColor.PINK, PlayerByColor.ORANGE, PlayerByColor.RED }
            )
        );

        // At 14 seconds
        motionsList.Add(
            new OneMotion(
                MotionType.CIRCLE,
                Track.VOICE,
                14,
                8,
                new List<PlayerByColor>() { PlayerByColor.PURPLE, PlayerByColor.PINK, PlayerByColor.ORANGE, PlayerByColor.RED }
            )
        );



        // At 21 seconds
        motionsList.Add(
            new OneMotion(
                MotionType.HORIZONTAL,
                Track.BASS, // TODO redéfinir ?
                21,
                4,
                new List<PlayerByColor>() { PlayerByColor.ORANGE, PlayerByColor.RED }
            )
        );

        // At 25 seconds
        motionsList.Add(
            new OneMotion(
                MotionType.CIRCLE,
                Track.GUITAR,
                25,
                4,
                new List<PlayerByColor>() { PlayerByColor.PINK }
            )
        );
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
