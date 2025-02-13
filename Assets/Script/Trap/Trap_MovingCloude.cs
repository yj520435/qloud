using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_MovingCloude : MonoBehaviour {

    public float platformSpeed = 5f;
    public float endPosition;
    bool endPoint = true;
    int count = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
            count++;
        }

    }

    void Update()
    {
        if (endPoint && count == 3)
        {
            transform.position += Vector3.right * platformSpeed * Time.deltaTime;
        }
        if (transform.position.x >= endPosition)
        {
            endPoint = false;
        }
    }
}
