using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMonster : MonoBehaviour {

    public float Speed; 
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(new Vector3(-(Speed * Time.deltaTime), 0, 0));	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            GameObject.FindWithTag("Manager").SendMessage("die");
    }
}
