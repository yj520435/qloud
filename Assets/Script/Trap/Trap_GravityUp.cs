using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_GravityUp : MonoBehaviour
{
    bool OneTimeTrap = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (OneTimeTrap == true)
        {
            PlayerMove.JumpPower = 8f;
            GameObject.FindWithTag("Player").SendMessage("ChangeColor");
            Invoke("RestoreGravity", 3.0f);
            OneTimeTrap = false;
        }
    }

    void RestoreGravity()
    {
        PlayerMove.JumpPower = 13f;
    }
}
