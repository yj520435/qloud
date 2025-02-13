using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    static GameObject GameOverCanvas;
    static GameObject Player;
	static GameObject BgmSound;

    public AudioClip GameOverSound;

    AudioSource Source;
    SpriteRenderer Player_Renderer;
    Rigidbody2D Player_Rigid;

    bool onetime = false;

    // Use this for initialization
    void Awake ()
    {
        GameOverCanvas = GameObject.Find("GameOverCanvas");
        Player = GameObject.FindGameObjectWithTag("Player");
        Player_Renderer = Player.GetComponent<SpriteRenderer>();
        Player_Rigid = Player.GetComponent<Rigidbody2D>();
		BgmSound = GameObject.Find("BgmSound");
		Source = gameObject.GetComponent<AudioSource>();
        GameOverCanvas.SetActive(false);	
	}

    public IEnumerator die()
    {
        if (onetime == false)
        {
            Trap_ReverseDirection.RestoreDirection();  //지우지 말것. 방향키 바뀐 채로 죽으면 원래대로 되돌려야 하기 때문.
            Player.GetComponent<PlayerMove>().enabled = false;
            Player.transform.FindChild("Player_Head").gameObject.SetActive(false);
            Player.gameObject.layer = 0;
            Player_Renderer.flipY = true;
            Player_Rigid.velocity = Vector2.zero;
            Vector2 UpVelocity = new Vector2(0, 15);
            Player_Rigid.AddForce(UpVelocity, ForceMode2D.Impulse);
            Source.PlayOneShot(GameOverSound, 1);
            onetime = true;
            BgmSound.SetActive(false);
        }
        yield return new WaitForSeconds(2f);
		Player.SetActive(false);
        GameOverCanvas.SetActive(true);
    }
}
