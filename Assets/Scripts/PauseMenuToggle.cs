using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class PauseMenuToggle : MonoBehaviour {

	private CanvasGroup canvasGroup;

	public Button resume;
	public Button instB;
	public Button quitB;
	public RawImage instrImage;
	public Button back;

    // Use this for initialization
    void Start () {

		instB.onClick.AddListener (showInstructions);
		quitB.onClick.AddListener (quitGame);
		back.onClick.AddListener (goBack);
		resume.onClick.AddListener (resumeGame);


		instB.gameObject.SetActive(false);

		quitB.gameObject.SetActive(false);
		back.gameObject.SetActive(false);
		resume.gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (canvasGroup.interactable) {
				Time.timeScale = 1f;
				instB.gameObject.SetActive(false);
				quitB.gameObject.SetActive(false);
				resume.gameObject.SetActive (false);
				canvasGroup.interactable = false;
				canvasGroup.blocksRaycasts = false;
				canvasGroup.alpha = 0f;
				instrImage.gameObject.SetActive(false);
				Cursor.visible = false;
			} else {
				Time.timeScale = 0f;
				instB.gameObject.SetActive(true);
				quitB.gameObject.SetActive(true);
				resume.gameObject.SetActive (true);
				canvasGroup.interactable = true;
				canvasGroup.blocksRaycasts = true;
				canvasGroup.alpha = 1f;
				Cursor.visible = true;
			}
		}
	}

	public void showInstructions() {
		instrImage.gameObject.SetActive(true);
		back.gameObject.SetActive (true);
	}

	public void quitGame() {
		Application.Quit ();
	}

	public void goBack() {
		instrImage.gameObject.SetActive (false);
		back.gameObject.SetActive (false);
	}

	public void resumeGame() {
		Time.timeScale = 1f;
		instB.gameObject.SetActive(false);
		quitB.gameObject.SetActive(false);
		resume.gameObject.SetActive (false);
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
		canvasGroup.alpha = 0f;
		instrImage.gameObject.SetActive(false);
		Cursor.visible = false;
	}

	void Awake () {
		canvasGroup = GetComponent<CanvasGroup> ();

		if (canvasGroup == null)
			Debug.LogError ("Canvas group not found");

		Time.timeScale = 1f;
	}
}
