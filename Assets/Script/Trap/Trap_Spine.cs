using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Spine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
            GameObject.FindWithTag("Manager").SendMessage("die");
    }
}