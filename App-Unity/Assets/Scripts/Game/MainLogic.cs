using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLogic : MonoBehaviour
{
    public GameObject scoreIndication;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = scoreIndication.GetComponent<Text>();
        scoreText.text = "0 pt";

        ControllersManager.Instance.Test();

        // Setup sound manager
        SoundManager.Instance.Setup();

        // Setup Timeline manager
        TimelineManager.Instance.Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
