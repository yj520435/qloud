using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour {

    public static int KeyNum = 0;

    public AudioClip KeySound;

    AudioSource Source;
    GameObject ClearCanvas;

    [Serializable]
    public class LevelData
    {
        public int KeyNum;
    }

    // Use this for initialization
    void Start ()
    {
        Source = gameObject.GetComponent<AudioSource>();

        ClearCanvas = GameObject.Find("ClearCanvas");
        ClearCanvas.SetActive(false);

        LoadData();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Invoke("NextStage", 1.5f);

		if (MainMenu.effFlag == 1)   //효과음 ON
		{
			Source.PlayOneShot (KeySound, 1);
		}
		else   //효과음 OFF
		{
			//NOTHING
		}

        gameObject.GetComponent<SpriteRenderer>().enabled = false; //열쇠 렌더러 끄기

        KeyNum = SceneManager.GetActiveScene().buildIndex-1; //현재 씬 번호를 KeyNum에 저장

        SaveData();

        ClearCanvas.SetActive(true);

    }

    public void SaveData() //데이터 저장
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/KeyInfo.dat");

        LevelData data = new LevelData();

        data.KeyNum = KeyNum;
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadData() //데이터 불러오기
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/KeyInfo.dat", FileMode.Open);

        if (file != null && file.Length > 0)
        {
            LevelData data = (LevelData)bf.Deserialize(file);

            KeyNum = data.KeyNum;

            Debug.Log(KeyNum);
        }

        file.Close();
    }

    void NextStage() //다음 스테이지로 넘어감
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }
}

