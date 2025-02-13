using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSound : MonoBehaviour
{

    public void BtnSound()
    {
        if (MainMenu.effFlag == 0)
        {
            this.gameObject.GetComponent<AudioSource>().Stop();
        }
        else if (MainMenu.effFlag == 1)
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {
        //Invoke("SoundDestroy", 3.0f);
    }

    void SoundDestroy()
    {
        //if (SceneManager.GetActiveScene().name == "StageSet" || SceneManager.GetActiveScene().name == "Setting")
        //{
            //Destroy(this.gameObject);
        //}
    }
}
