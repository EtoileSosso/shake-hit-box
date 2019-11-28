using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreen : MonoBehaviour
{
    private int slide = 0;
    public GameObject[] slides = new GameObject[7]; 
    public GameObject logo; 
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject s in slides)
        {
            s.SetActive(false);
        }
        slides[slide].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            if (slide < 7)
            {
                slides[slide].SetActive(false);
                slide += 1;
                slides[slide].SetActive(true);

                if(slide == 6)
                {
                    logo.SetActive(false);
                }
            }
            else
            {
                Scene currentScene = SceneManager.GetSceneByName("Tuto");
                SceneManager.UnloadSceneAsync(currentScene.buildIndex);
            }
        }
    }
}
