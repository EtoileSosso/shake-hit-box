using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadingscreen : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    private int number = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(3);
        if(number < 2)
        {
            if(number == 0)
            {
                animateText(Text1);
            }
            else
            {
                animateText(Text2);
            }
            number++;
        } else // TODO: Check if game is finished or not to choose next scene
        {
            SceneManager.LoadScene("Game");
            // SceneManager.SetActiveScene(SceneManager.GetSceneByName("Game"));
        }
        StartCoroutine(ExampleCoroutine());
    }

    void animateText(GameObject text)
    {
        text.GetComponent<Animator>().enabled = true;
    }
}
