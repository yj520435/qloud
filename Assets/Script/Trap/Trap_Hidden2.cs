using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Hidden2 : MonoBehaviour {

    Renderer Render;

    void Start ()
    {
        Render = gameObject.GetComponent<Renderer>();
        Render.enabled = false;
    }
	
	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Render.enabled = true;
        }
    }
}
