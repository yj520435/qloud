using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Monster : MonoBehaviour {

    public GameObject m;

    bool Exist_Monster = false;

    Transform Player;
	// Use this for initialization
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player" && Exist_Monster == false)
        {
            Make_Monster();
            Exist_Monster = true;
        }
    }

    void Make_Monster()
    {
        GameObject Monster = (GameObject)Instantiate(m, new Vector3(Player.position.x + 15f, Player.position.y, 0f), Quaternion.identity);
        Destroy(Monster, 1);
    }
}
