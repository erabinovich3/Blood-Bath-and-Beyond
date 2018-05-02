	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMom : MonoBehaviour {

	public GameObject[] dismoms;
	public GameObject[] moms;
	public Light[] lights;
	public int momNumber = 0;
	public bool momSelected = false;

	//Need to enable and disable certain things
	public GameObject[] enablingToSwitch;
	 




	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        //Select mom and make necessary GUI changes
        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("LoadingScene");
        }
        else
        {

            int count = 0;
            bool[] unlm = GameController.controller.unlockedMoms;
            for (int i = 0; i < unlm.Length; i ++)
            {
                if (unlm[i] == true)
                {
                    count++;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                momNumber = (momNumber - 1) % count;
                string logMessage = "The number is " + momNumber + ".";
                Debug.Log(logMessage);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                momNumber = (momNumber + 1) % count;
                string logMessage = "The number is " + momNumber + ".";
                Debug.Log(logMessage);
            }
            GUIChanges();

        }
    }

    public void GUIChanges () {
        if (lights[0] == null)
        {
            return;
        }
		for (int i = 0; i < lights.Length; i++) {
			if (i == momNumber) {
				lights [i].intensity = 12;
			} else {
				lights [i].intensity = 3;
			}
		}
	}
}
