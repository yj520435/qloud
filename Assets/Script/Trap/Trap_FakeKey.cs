using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_FakeKey : MonoBehaviour {



    void OnTriggerEnter2D(Collider2D other)
    {
        
        gameObject.GetComponent<SpriteRenderer>().color= Color.red; //열쇠 빨간 색으로 변한다.
        GameObject.FindWithTag("Manager").SendMessage("die");

    }
}
