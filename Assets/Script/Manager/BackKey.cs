using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackKey : MonoBehaviour {

    GameObject PauseCanvas;
    static GameObject BgmSound;

    void Awake()
    {
        PauseCanvas = GameObject.Find("PauseCanvas");
        BgmSound = GameObject.Find("BgmSound");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject PauseCanvas2 = GameObject.Find("PauseCanvas");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(PauseCanvas2);
            if (PauseCanvas2 == null)
            {
                PauseCanvas.SetActive(true);
                Time.timeScale = 0;
                BgmSound.GetComponent<AudioSource>().Pause();
            }

            else if (PauseCanvas2 != null)
            {
                PauseCanvas.SetActive(false);
                Time.timeScale = 1;
                BgmSound.GetComponent<AudioSource>().UnPause();
            }
        }
    }
}
