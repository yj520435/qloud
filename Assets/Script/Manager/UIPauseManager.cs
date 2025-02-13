using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPauseManager : MonoBehaviour {

    public GameObject PauseCanvas;
    static GameObject BgmSound;

    void Awake()
    {
        BgmSound = GameObject.Find("BgmSound");
        PauseCanvas = GameObject.Find("PauseCanvas");
    }

    void Start()
    {
        PauseCanvas.SetActive(false);
    }

    public void ResumeButton()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1;
        BgmSound.GetComponent<AudioSource>().UnPause();
    }

    public void MenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
