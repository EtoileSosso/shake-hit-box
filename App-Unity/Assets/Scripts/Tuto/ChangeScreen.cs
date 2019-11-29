using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreen : MonoBehaviour
{
    private int slide = 0;
    private int tuto = 0;
    public Animator[] anims = new Animator[4];
    public GameObject[] tutos = new GameObject[4];
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
        foreach(GameObject t in tutos)
        {
            t.GetComponentInChildren<Text>().color = new Color(1, 1, 1, 0.5f);
            t.GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        tutos[0].GetComponentInChildren<Text>().color = new Color(1, 1, 1, 1);
        tutos[0].GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
        foreach(Animator a in anims)
        {
            a.enabled = false;
        }
        anims[0].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (slide < 7)
            {
                if (slide == 1)
                {
                    if (tuto < 3)
                    {
                        tutos[tuto].GetComponentInChildren<Text>().color = new Color(1, 1, 1, 0.5f);
                        tutos[tuto].GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.5f);
                        anims[tuto].enabled = false;
                        tuto += 1;
                        tutos[tuto].GetComponentInChildren<Text>().color = new Color(1, 1, 1, 1);
                        tutos[tuto].GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                        anims[tuto].enabled = true;
                    }
                    else
                    {
                        slides[slide].SetActive(false);
                        slide += 1;
                        slides[slide].SetActive(true);
                    }
                } else
                {
                    slides[slide].SetActive(false);
                    slide += 1;
                    slides[slide].SetActive(true);

                    if (slide == 6)
                    {
                        logo.SetActive(false);
                    }
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
