	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMom : MonoBehaviour {

	public GameObject[] moms;
	public Light[] lights;
	public int momNumber = 0;
	public GameObject momSelected;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
//		GameObject[] cmListObj = SceneManager.GetSceneByName ("choose-mom").GetRootGameObjects ();
//		GameObject temp = cmListObj [1];
//		for (int i = 0; i < cmListObj.Length; i++) {
//			temp = cmListObj [i];
//			Debug.Log (temp.ToString ());
//		}
//
//
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			momNumber = (momNumber + 4) % 5;
			string logMessage = "The number is " + momNumber + ".";
			Debug.Log(logMessage);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			momNumber = (momNumber + 1) % 5;
			string logMessage = "The number is " + momNumber + ".";
			Debug.Log(logMessage);
		}
		GUIChanges ();

		if (Input.GetKeyDown(KeyCode.Space)) {
			SelectTheMom ();
		}


	}

	public void SelectTheMom () {
		//TODO: switch on the mom kinda like toggle button from M1
		momSelected = moms[momNumber];
		SceneManager.LoadScene ("level1");
	}

	public void GUIChanges () {
		for (int i = 0; i < 5; i++) {
			if (i == momNumber) {
				lights [i].intensity = 14;
			} else {
				lights [i].intensity = 7;
			}
		}
	}
}
