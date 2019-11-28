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
    int elapsedTimeSeconds = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = scoreIndication.GetComponent<Text>();
        scoreText.text = "0 pt";

        ControllersManager.Instance.Test();

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

    // Update is called once per frame
    void Update()
    {
        if(doChrono)
        {
            elapsedTime += Time.deltaTime;
            elapsedTimeSeconds = (int)(elapsedTime % 60);
        }
    }
}
