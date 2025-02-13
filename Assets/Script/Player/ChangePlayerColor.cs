using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerColor : MonoBehaviour {

    SpriteRenderer Player_Renderer;

	// Use this for initialization
	void Start ()
    {
        Player_Renderer = gameObject.GetComponent<SpriteRenderer>();	
	}
	
	void ChangeColor ()
    {
        Player_Renderer.color = Color.gray;
        Invoke("ReturnColor", 3f);
    }

    void ReturnColor ()
    {
        Player_Renderer.color = Color.white;
    }
}
