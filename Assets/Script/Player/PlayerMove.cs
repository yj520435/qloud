using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float MovePower = 10f; // 움직이는 속도 조절
    static public float JumpPower = 13f; // 점프 높이 조절
    public float i = 1f; // 캐릭터 왼쪽 움직임 제한 

    public bool inputLeft = false;
    public bool inputRight = false;
    public bool inputJump = false;
    public bool isJumping = false;
    public bool Ground = true; // 땅 체크
    bool Side_Check;

    public AudioClip JumpSound;

    Transform Player_Side; // 벽에 닿았을 때 점프 안되도록 함
    Transform Camera;
    AudioSource Source;
    Rigidbody2D Rigid;
    Animator Animator;
    Vector3 Movement;
 
    // Use this for initialization
    void Start()
    {
        Rigid = gameObject.GetComponent<Rigidbody2D>();
        Animator = gameObject.GetComponent<Animator>();
        Source = gameObject.GetComponent<AudioSource>();

        Player_Side = transform.FindChild("Player_Side");
        Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;

        UIButtonManager Ui = GameObject.FindGameObjectWithTag("Manager").GetComponent<UIButtonManager>();
        Ui.Init();
    }

    void Update()
    {
        if (Trap_ReverseDirection.ReverseDirection == false)
            Player_Animation();

        else if (Trap_ReverseDirection.ReverseDirection == true)
        {
            Player_Animation_Reverse();
        }

    }

    void FixedUpdate()
    {
        Side_Check = (Physics2D.OverlapPoint(Player_Side.position) != null) ? true : false;

        if (Trap_ReverseDirection.ReverseDirection == false)
            Move();

        else if (Trap_ReverseDirection.ReverseDirection == true)
        {
            Move_Reverse();
        }
        Jump();
    }

    void Move() //캐릭터 이동함수
    {
        Vector3 MoveVelocity = Vector3.zero;

        if(inputLeft)
        {
            MoveVelocity = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1);

            if (transform.position.x < Camera.position.x - i) //왼쪽 움직임 거리 조정
                transform.position = new Vector3(Camera.position.x - i, transform.position.y, transform.position.z);
        }

        else if(inputRight)
        {
            MoveVelocity = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (!Side_Check)
            transform.position += MoveVelocity * MovePower * Time.deltaTime;
    }
    
    void Move_Reverse()
    {
        Vector3 MoveVelocity = Vector3.zero;

        if (inputLeft)
        {
            MoveVelocity = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
        }

        else if (inputRight)
        {
            MoveVelocity = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (!Side_Check)
            transform.position += MoveVelocity * MovePower * Time.deltaTime;
    }

    void Jump()
    {
        if (!isJumping)
            return;

        Rigid.velocity = Vector2.zero;

        Vector2 JumpVelocity = new Vector2(0, JumpPower);

        Rigid.AddForce(JumpVelocity, ForceMode2D.Impulse);

		if (MainMenu.effFlag == 1)   //효과음 ON
		{
			Source.PlayOneShot (JumpSound, 1);
		}
		else   //효과음 OFF
		{
			//NOTHING
		}

        isJumping = false;
    }

    void Player_Animation()
    {
        if (!inputRight && !inputLeft)
        {
            Animator.SetBool("isMoving", false);
        }

        else if (inputLeft)
        {
            Animator.SetBool("isMoving", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        else if (inputRight)
        {
            Animator.SetBool("isMoving", true);
            transform.localScale = new Vector3(1, 1, 1);
        }

        if ((Input.GetButtonDown("Jump") || inputJump) && !Animator.GetBool("isJumping"))
        {
            isJumping = true;
            inputJump = false;
            Animator.SetBool("isJumping", true);
            Animator.SetTrigger("doJumping");
            Ground = false;
        }
    }

    void Player_Animation_Reverse()
    {
        if (!inputRight && !inputLeft)
        {
            Animator.SetBool("isMoving", false);
        }

        else if (inputLeft)
        {
            Animator.SetBool("isMoving", true);
            transform.localScale = new Vector3(1, 1, 1);
        }

        else if (inputRight)
        {
            Animator.SetBool("isMoving", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if ((Input.GetButtonDown("Jump") || inputJump) && !Animator.GetBool("isJumping"))
        {
            isJumping = true;
            inputJump = false;
            Animator.SetBool("isJumping", true);
            Animator.SetTrigger("doJumping");
            Ground = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer == 10 && Rigid.velocity.y <= 0)
        {
            Animator.SetBool("isJumping", false);
            Ground = true;
        }

        else if (other.gameObject.layer == 10 && Rigid.velocity.y > 0)
        {
            Animator.SetBool("isJumping", true);
            Ground = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 10 && Rigid.velocity.y <= 0)
        {
            Animator.SetBool("isJumping", false);
            Ground = true;
        }

        else if (other.gameObject.layer == 10 && Rigid.velocity.y > 0)
        {
            Animator.SetBool("isJumping", true);
            Ground = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 10)
        {
            Animator.SetBool("isJumping", true);
            Ground = false;
        }
    }
}

