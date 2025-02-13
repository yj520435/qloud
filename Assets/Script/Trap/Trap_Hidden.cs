using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Hidden : MonoBehaviour {

    Renderer Render;
    Transform Player;

	// Use this for initialization
	void Start ()
    {
        Render = gameObject.GetComponent<Renderer>();

        Player = GameObject.FindGameObjectWithTag("Player").transform;

        Render.enabled = false;
	}

    void OnTriggerEnter2D(Collider2D other)
    {   
        if (Player.GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            Render.enabled = true;
            gameObject.layer = 10;
        }
    }
}
