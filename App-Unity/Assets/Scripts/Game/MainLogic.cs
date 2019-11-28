using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLogic : MonoBehaviour
{
    public GameObject scoreIndication;
    Text scoreText;
    bool doChrono = false;
    float elapsedTime = 0f;
    int previousElapsedTimeSeconds = 0;
    int elapsedTimeSeconds = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = scoreIndication.GetComponent<Text>();
        scoreText.text = "0 pt";

        ControllersManager.Instance.Setup();

        // Setup sound manager
        Music.Instance.Setup();

        // Setup Timeline manager
        TimelineManager.Instance.Setup();

        StartGame();
    }

    void StartGame()
    {
        doChrono = true;
        Music.Instance.StartMusic();
    }

    void CheckForMotion()
    {
        // TODO gérer plusieurs à la même seconde
        OneMotion motion = TimelineManager.Instance.CheckForCurrentMotion(elapsedTimeSeconds);
        //Debug.Log(motion.players);
        if(motion.type != MotionType.NONE)
        {
            Debug.Log(motion.players);
            // bool res = ControllersManager.Instance.startListeningToMotion(motion.type, motion.players);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(doChrono)
        {
            elapsedTime += Time.deltaTime;
            elapsedTimeSeconds = (int)(elapsedTime % 60);

            if(elapsedTimeSeconds > previousElapsedTimeSeconds)
            {
                //Debug.Log(elapsedTimeSeconds);
                CheckForMotion();
            }
            previousElapsedTimeSeconds = elapsedTimeSeconds;
        }
    }
}
