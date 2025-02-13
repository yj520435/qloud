using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSound : MonoBehaviour {

	void Awake ()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("MainSound");
        if (obj.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (SceneManager.GetActiveScene().buildIndex > 2)
        {
            Destroy(this.gameObject);
        }
    }
}
