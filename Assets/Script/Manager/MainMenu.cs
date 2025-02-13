using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    GameObject obj;
    AudioSource Mainsound;

    public static int bgmFlag = 1;
    public static int effFlag = 1;

    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("MainSound");
        Mainsound = obj.GetComponent<AudioSource>();

        if (bgmFlag == 0)   //bgm OFF상태이면
        {
            Mainsound.Stop();
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("StageSet");
    }

    public void SettingButton()
    {
        SceneManager.LoadScene("Setting");
    }

    public void EixtButton()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //뒤로가기
        {
            Application.Quit();
        }
    }
}
