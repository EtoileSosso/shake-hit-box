using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Small Players heads
    public GameObject smallPink;
    public GameObject smallPurple;
    public GameObject smallRed;
    public GameObject smallYellow;

    // Big Players heads
    public GameObject bigPink;
    public GameObject bigPurple;
    public GameObject bigRed;
    public GameObject bigYellow;

    // Players count
    public GameObject playersCount;
    Component playersCountText;



    // Start is called before the first frame update
    void Start()
    {
        playersCountText = playersCount.GetComponent<Text>();

        // Setup Controllers Manager
        ControllersManager.Instance.Setup();
        ControllersManager.Instance.SetupNetwork();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DoCheck()
    {
        for (;;)
        {

            yield return new WaitForSeconds(1f);
        }
    }
}
