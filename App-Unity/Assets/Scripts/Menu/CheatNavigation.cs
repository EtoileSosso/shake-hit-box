using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheatNavigation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button cheatButton = gameObject.GetComponent<Button>();
        cheatButton.onClick.AddListener(cheatButtonClickHandler);
    }

    void cheatButtonClickHandler()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);
    }
}
