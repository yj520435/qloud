using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Speed;

    Animator Animator;
    Vector3 Movement;
    Transform GroundCheck;

    int MovementFlag = 0;
    bool Reverse = true;
    bool Ground;

    // Use this for initialization
    void Start()
    {
        Animator = gameObject.GetComponentInChildren<Animator>();

        GroundCheck = transform.FindChild("GroundCheck");

        StartCoroutine("ChangeMovement");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Ground = (Physics2D.OverlapPoint(GroundCheck.position) != null) ? true : false;
        if (Ground == false)
        {
            if (MovementFlag == 1)
            {
                MovementFlag = 2;
                Ground = true;
            }

            else if (MovementFlag == 2)
            {
                MovementFlag = 1;
                Ground = true;
            }
        }
    }

    void Move()
    {
        Vector3 MoveVelocity = Vector3.zero;

        if (MovementFlag == 1)
        {
            MoveVelocity = Vector3.right;
            transform.localScale = new Vector3(3, 3, 3);
        }

        else if (MovementFlag == 2)
        {
            MoveVelocity = Vector3.left;
            transform.localScale = new Vector3(-3, 3, 3);
        }

        transform.position += MoveVelocity * Speed * Time.deltaTime;
    }

    IEnumerator ChangeMovement()
    {
        MovementFlag = Random.Range(0, 3);
        Debug.Log(MovementFlag);

        if (MovementFlag == 0)
            Animator.SetBool("isMoving", false);

        else
            Animator.SetBool("isMoving", true);

        yield return new WaitForSeconds(2f);

        StartCoroutine("ChangeMovement");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
            GameObject.FindWithTag("Manager").SendMessage("die");

        else if(other.gameObject.tag == "Obstacle" && Reverse == true)
        {
            if (MovementFlag == 1)
            {
                MovementFlag = 2;
            }

            else if (MovementFlag == 2)
            {
                MovementFlag = 1;
            }

            Reverse = false;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle" && Reverse == false)
            Reverse = true;
    }
}
