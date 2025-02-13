using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour {
    public float movePower = 1f;
    public float jumpPower = 1f;

    Rigidbody2D rigid;
    Animator animator;
    //SpriteRenderer rend;
    Vector3 movement;

	public AudioClip jumpSound;
	private AudioSource source;
    private new Transform camera;

    bool isJumping = false;
    bool oneTimeTrap = true;
    public bool inputLeft = false;
    public bool inputRight = false;
    public bool inputJump = false;
    public bool ground = true;
    public bool reverse = false;
    public float i = 16.5f;
   

	// Use this for initialization
	void Start () {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        //rend = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
		source = gameObject.GetComponent<AudioSource>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        UIButtonManager ui = GameObject.FindGameObjectWithTag("Manager").GetComponent<UIButtonManager>();
        ui.Init();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(reverse == false)
            ani();

        else if(reverse == true)
        {
            Reverseani();
            Invoke("a", 10f);
        }

    }

    void FixedUpdate()
    {
        if(reverse == false)
            Move();
        
        else if(reverse == true)
        {
            ReverseMove();
            Invoke("a", 10f);
        }
        Jump();
        //키보드 테스트용 
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            inputLeft = true;
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            inputLeft = false;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            inputRight = true;
        if (Input.GetKeyUp(KeyCode.RightArrow))
            inputRight = false;
        if (Input.GetKeyDown(KeyCode.Space))
            inputJump = true;
    }

    void Move()//정방향
    {
        Vector3 moveVelocity = Vector3.zero;
        reverse = false;
        if(inputLeft)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1);
            if (transform.position.x < camera.position.x - i)
                transform.position = new Vector3(camera.position.x - i, transform.position.y, transform.position.z);
        }

        else if (inputRight)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    public void ReverseMove()//방향키 반전
    {
        Vector3 moveVelocity = Vector3.zero;

        if (inputLeft)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
        }

        else if (inputRight)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    public void ani()
    {
        reverse = false;
        if (!inputRight && !inputLeft)
        {
            animator.SetBool("isMoving", false);
        }
        else if (inputLeft)
        {
            animator.SetBool("isMoving", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (inputRight)
        {
            animator.SetBool("isMoving", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        if ((Input.GetButtonDown("Jump") || inputJump) && !animator.GetBool("isJumping"))
        {
            isJumping = true;
            inputJump = false;
            animator.SetBool("isJumping", true);
            animator.SetTrigger("doJumping");
            ground = false;
        }
    }

    public void Reverseani()
    {
        if (!inputRight && !inputLeft)
        {
            animator.SetBool("isMoving", false);
        }
        else if (inputLeft)
        {
            animator.SetBool("isMoving", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (inputRight)
        {
            animator.SetBool("isMoving", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if ((Input.GetButtonDown("Jump") || inputJump) && !animator.GetBool("isJumping"))
        {
            isJumping = true;
            inputJump = false;
            animator.SetBool("isJumping", true);
            animator.SetTrigger("doJumping");
            ground = false;
        }
    }

    void Jump()
    {
        if (!isJumping)
            return;

        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

		source.PlayOneShot(jumpSound,1);

        isJumping = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Attach : " + other.gameObject.layer);
        Debug.Log("y : " + rigid.velocity.y);

        if (other.gameObject.layer == 0 && rigid.velocity.y <= 0)
        {
            animator.SetBool("isJumping", false);
            ground = true;
        }

        else if (other.gameObject.layer == 0 && rigid.velocity.y > 0)
        {
            animator.SetBool("isJumping", true);
            ground = false;
        }

        if (other.gameObject.tag == "Fcloud" && oneTimeTrap ==true)
        {
            reverse = true;
            oneTimeTrap = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 0 && rigid.velocity.y <= 0)
        {
            animator.SetBool("isJumping", false);
            ground = true;
        }

        else if (other.gameObject.layer == 0 && rigid.velocity.y > 0)
        {
            animator.SetBool("isJumping", true);
            ground = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Detach : " + other.gameObject.layer);
        Debug.Log("y : " + rigid.velocity.y);

        if (other.gameObject.layer == 0)
        {
            animator.SetBool("isJumping", true);
            ground = false;
        }

    }

    void a()
    {
        reverse = false;
    }
}
