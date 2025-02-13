using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSet : MonoBehaviour {

	//public GameObject ButtonSound;
    public Button[] Buttons = null;
    public int i = 0;
    static public int KeyNum;
    public static int stageLevel = 0;

    void Awake()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = null;
		//ButtonSound = GameObject.Find ("ButtonSound");
        KeyNum = 1;
        if (File.Exists(Application.persistentDataPath + "/KeyInfo.dat"))
        {
            file = File.Open(Application.persistentDataPath + "/KeyInfo.dat", FileMode.Open);
        }
        else
        {
            Debug.Log("No");
            KeyNum = 1;
        }

        if (file != null && file.Length > 0)
        {
            GameClear.LevelData data = (GameClear.LevelData)bf.Deserialize(file);

            KeyNum = data.KeyNum;

            Debug.Log(KeyNum);
        }


        for (i = 1; i < Buttons.Length; i++)
            Buttons[i].interactable = false;

        for (i = 0; i < KeyNum; i++)
        {
            Buttons[i].interactable = true;
        }
    }

    public void ButtonClick(Button btn)
    {
        for (i = 0; i < Buttons.Length; i++)
        {
            if (btn == Buttons[i])
                stageLevel = i + 3;
        }

		//ButtonSound.GetComponent<AudioSource> ().Play ();
		//DontDestroyOnLoad (ButtonSound);
        SceneManager.LoadScene(stageLevel, LoadSceneMode.Single);
    }
}
