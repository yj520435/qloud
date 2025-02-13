using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmController : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        if (MainMenu.bgmFlag == 0)
        {
            this.GetComponent<AudioSource>().Stop();
        }
        else if (MainMenu.bgmFlag == 1)
        {
            this.GetComponent<AudioSource>().Play();
        }
        
    }
}
