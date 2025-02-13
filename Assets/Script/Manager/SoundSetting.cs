using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundSetting : MonoBehaviour
{

    GameObject obj;
    AudioSource Mainsound;

    public Text BgmText;
    public Text EffText;

    // Use this for initialization
    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("MainSound");
        Mainsound = obj.GetComponent<AudioSource>();

        if (MainMenu.bgmFlag == 1)   //배경음 ON에서 OFF로
        {
            BgmText.GetComponent<Text>().text = "ON";
        }

        else if (MainMenu.bgmFlag == 0)   //배경음을 OFF에 ON으로
        {
            BgmText.GetComponent<Text>().text = "OFF";
        }

        if (MainMenu.effFlag == 1)
        {   //효과음 ON에서 OFF로
            EffText.GetComponent<Text>().text = "ON";
        }

        else if (MainMenu.effFlag == 0)
        {   //효과음 OFF에 ON으로
            EffText.GetComponent<Text>().text = "OFF";
        }
    }

    public void bgmCtrlButton()
    {
        bgmCtrl();
    }

    public void effCtrlButton()
    {
        effCtrl();
    }


    void bgmCtrl()
    {
        if (MainMenu.bgmFlag == 1)   //배경음 ON에서 OFF로
        {
            Mainsound.Stop();   //배경음 중지
            BgmText.GetComponent<Text>().text = "OFF";
            MainMenu.bgmFlag = 0;   //플래그를 0으로
        }

        else if (MainMenu.bgmFlag == 0)   //배경음을 OFF에 ON으로
        {
            Mainsound.Play();   //배경음 재생
            BgmText.GetComponent<Text>().text = "ON";
            MainMenu.bgmFlag = 1;
        }
    }

    void effCtrl()
    {
        if (MainMenu.effFlag == 1)   //효과음 ON에서 OFF로
        {
            EffText.GetComponent<Text>().text = "OFF";
            MainMenu.effFlag = 0;
        }
        else if (MainMenu.effFlag == 0)   //효과음 OFF에 ON으로
        {
            EffText.GetComponent<Text>().text = "ON";
            MainMenu.effFlag = 1;
        }
    }

    void Update() //뒤로가기
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
