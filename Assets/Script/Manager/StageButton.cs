using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageButton : MonoBehaviour {

    public Button Button;

	// Use this for initialization
	void Start ()
    {
        GameObject StageText = gameObject.transform.FindChild("StageText").gameObject;
        GameObject StageLock = gameObject.transform.FindChild("StageLock").gameObject;

        StageText.SetActive(false);
        StageLock.SetActive(false);

        if (Button.interactable == true)
        {
            StageText.SetActive(true);
            StageLock.SetActive(false);
        }

        else if (Button.interactable == false)
        {
            StageText.SetActive(false);
            StageLock.SetActive(true);
        }
    }
}
