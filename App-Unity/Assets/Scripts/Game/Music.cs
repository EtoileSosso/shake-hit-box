using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public AudioClip[] musics;
    public Text currentSeconds;
    public Text currentMinutes;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayMusic(musics[0]);
        currentSeconds.text = "00";
        currentMinutes.text = "00";
        //SoundManager.instance.PlayMusic(musics[1]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SoundManager.Instance.ChangePitch(musics[0]);

        if (Input.GetKeyDown(KeyCode.UpArrow))
            SoundManager.Instance.UpVolume(musics[0]);

        if (Input.GetKeyDown(KeyCode.DownArrow))
            SoundManager.Instance.DownVolume(musics[0]);

        float timer = SoundManager.Instance.GetCurrentTime();
        string minutes = Mathf.Floor((int)timer / 60).ToString("00");
        string seconds = ((int)timer % 60).ToString("00");
        currentSeconds.text = seconds;
        currentMinutes.text = minutes;
    }
}
