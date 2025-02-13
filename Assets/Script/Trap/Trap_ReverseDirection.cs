using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_ReverseDirection : MonoBehaviour
{

    static public bool ReverseDirection = false;
    bool OneTimeTrap = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (OneTimeTrap == true)
        {
            ReverseDirection = true;
            GameObject.FindWithTag("Player").SendMessage("ChangeColor");
            Invoke("RestoreDirection", 3.0f);
            OneTimeTrap = false;
        }
    }

     static public void RestoreDirection()
    {
        ReverseDirection = false;
    }
}
