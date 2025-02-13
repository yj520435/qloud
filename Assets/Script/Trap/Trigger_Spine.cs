using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Spine : MonoBehaviour {

    public GameObject Spine;
    public GameObject SpinePoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
            Make_Spine();
    }

    void Make_Spine()
    {
       Instantiate(Spine, SpinePoint.transform.position, Quaternion.identity);
    }
}
