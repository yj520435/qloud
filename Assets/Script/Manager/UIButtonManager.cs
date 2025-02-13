using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonManager : MonoBehaviour {

    public GameObject Player;
    public PlayerMove PlayerScript;

    public void Init() 
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerScript = Player.GetComponent<PlayerMove>();
    }

    public void LeftDown()
    {
        PlayerScript.inputLeft = true;
    }

    public void LeftUp()
    {
        PlayerScript.inputLeft = false;
    }

    public void RightDown()
    {
        PlayerScript.inputRight = true;
    }

    public void RightUp()
    {
        PlayerScript.inputRight = false;
    }

    public void JumpClick()
    {
        if (PlayerScript.Ground == true)
            PlayerScript.inputJump = true;

        else if (PlayerScript.Ground == false)
            PlayerScript.inputJump = false;
    }
}
