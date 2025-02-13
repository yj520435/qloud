using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_FallingGround : MonoBehaviour {

    public Rigidbody2D fallingGround;
    public GameObject fallingPoint;
    GameObject Player;

    int Mask;

    void Awake()
    {
        Player = GameObject.Find("Player");
        Mask = 1 << LayerMask.NameToLayer("Player");
        fallingGround.Sleep();
    }
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 13f, Mask);

        if (hit.collider != null)
        {
            fallingGround.WakeUp();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.FindWithTag("Manager").SendMessage("die");
        }
    }
}
