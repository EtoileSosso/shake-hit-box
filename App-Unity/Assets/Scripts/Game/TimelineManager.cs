using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Track { BASS, GUITAR, FATWA, VOICE, ALL }

struct LocalTime
{
    public int minutes;
    public int seconds;

    public LocalTime(int pMinutes, int pSeconds)
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
    public LocalTime time;
    public int iterations;
    public List<PlayerByColor> players;

    public OneMotion(MotionType pType, Track pTrack, LocalTime pTime, int pIterations, List<PlayerByColor> pPlayers)
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
        motionsList = GetMotionList();
    }

    private List<OneMotion> GetMotionList()
    {
        List<OneMotion> list = new List<OneMotion>();

        // At 10 seconds
        list.Add(
            new OneMotion(
                MotionType.HORIZONTAL,
                Track.FATWA,
                new LocalTime(0, 10),
                4,
                new List<PlayerByColor>() { PlayerByColor.PURPLE, PlayerByColor.PINK, PlayerByColor.ORANGE, PlayerByColor.RED }
            )
        );

        // At 14 seconds
        list.Add(
            new OneMotion(
                MotionType.CIRCLE,
                Track.VOICE,
                new LocalTime(0, 14),
                8,
                new List<PlayerByColor>() { PlayerByColor.PURPLE, PlayerByColor.PINK, PlayerByColor.ORANGE, PlayerByColor.RED }
            )
        );

        // At 21 seconds
        list.Add(
            new OneMotion(
                MotionType.HORIZONTAL,
                Track.BASS, // TODO redéfinir ?
                new LocalTime(0, 21),
                4,
                new List<PlayerByColor>() { PlayerByColor.ORANGE, PlayerByColor.RED }
            )
        );

        // At 25 seconds
        list.Add(
            new OneMotion(
                MotionType.CIRCLE,
                Track.GUITAR,
                new LocalTime(0, 21),
                4,
                new List<PlayerByColor>() { PlayerByColor.PINK }
            )
        );

        return list;
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
