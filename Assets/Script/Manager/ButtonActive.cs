using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActive : MonoBehaviour {

    GameObject PauseCanvas;
    Button[] Buttons = new Button[3];
    // Use this for initialization
    void Start()
    {
        Buttons[0] = GameObject.Find("LeftButton").GetComponent<Button>();
        Buttons[1] = GameObject.Find("RightButton").GetComponent<Button>();
        Buttons[2] = GameObject.Find("JumpButton").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        PauseCanvas = GameObject.Find("PauseCanvas");
        if (PauseCanvas == null)
        {
            for (int i = 0; i < 3; i++)
            {
                Buttons[i].interactable = true;
            }
        }

        else if (PauseCanvas != null)
        {
            for (int i = 0; i < 3; i++)
            {
                Buttons[i].interactable = false;
            }
        }
    }
}
