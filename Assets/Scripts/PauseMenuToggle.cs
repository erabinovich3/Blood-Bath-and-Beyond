using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuToggle : MonoBehaviour {
	
	public Button instB;
	public Button retuB;
	private RawImage instrImage;
	float timer = 0;

	bool paused;
	bool showingInstructions;

	// Use this for initialization
	void Start () {
		paused = false;
		showingInstructions = true;
		instB.onClick.AddListener (showInstructions);
		retuB.onClick.AddListener (returnToSelectMom);
		instB.gameObject.SetActive(false);
		retuB.gameObject.SetActive(false);
		instrImage = GameObject.Find("RawImage").GetComponent<RawImage>();
		instrImage.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (showingInstructions) {
				instrImage.gameObject.SetActive(false);
				showingInstructions = false;
			} else if (paused) {
				instB.gameObject.SetActive(false);
				retuB.gameObject.SetActive(false);
				paused = false;
				Time.timeScale = 1f;

			} else {
				instB.gameObject.SetActive(true);
				retuB.gameObject.SetActive(true);
				paused = true;
				Time.timeScale = 0f;
			}
		}
	}

	public void showInstructions() {
		instrImage.gameObject.SetActive(true);
		showingInstructions = true;
	}

	public void returnToSelectMom() {
		SceneManager.LoadScene("chooseMom");
	}

}
