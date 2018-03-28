using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplaySelectedMom : MonoBehaviour {
  
	public GameObject[] moms;

	// Use this for initialization
	void Start () {
		GameObject temp = GameObject.Find("MomSelect");
		SelectMom momScript = temp.GetComponent<SelectMom>();
		int sM = momScript.momNumber;
		for (int i = 0; i < 5; i++) {
			if (i == sM) {
				moms [i].SetActive (true);
			} else {
				moms [i].SetActive(false);
			}
		}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
