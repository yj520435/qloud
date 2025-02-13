using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Thunderbolt : MonoBehaviour
{

    GameObject Player;
    SpriteRenderer Player_Renderer;

    void Awake()
    {
        Player = GameObject.Find("Player");
        Player_Renderer = Player.GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player_Renderer.color = Color.black;
            GameObject.FindWithTag("Manager").SendMessage("die");
        }
    }
}
