using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_HidePlayer : MonoBehaviour {

    GameObject Player;
    SpriteRenderer Rend;

    bool OneTimeTrap = true;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Rend = Player.gameObject.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(OneTimeTrap == true)
        {
            Rend.enabled = false;
            Invoke("Restore", 3.0f);
            OneTimeTrap = false;
        }
    }

    void Restore()
    {
        Rend.enabled = true;
    }
}
