using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {
    
    private Animator bgAnim;
    private Animator titleAnim;
    private Animator subtitleAnim;
    private Text instructions;
    private Text enter;
    private int state = 0;
	private RawImage instrImage;

	// Use this for initialization
	void Start () {
        bgAnim = GameObject.Find("BG").GetComponent<Animator>();
        titleAnim = GameObject.Find("Title").GetComponent<Animator>();
        subtitleAnim = GameObject.Find("Subtitle").GetComponent<Animator>();
        instructions = GameObject.Find("Instructions").GetComponent<Text>();
        enter = GameObject.Find("Enter").GetComponent<Text>();
		instrImage = GameObject.Find("RawImage").GetComponent<RawImage>();

		instructions.enabled = false;
		instrImage.enabled = false;
        enter.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Submit")) {
			if (state == 0) {
				bgAnim.SetTrigger ("fade_in");
				titleAnim.SetTrigger ("fade");
				subtitleAnim.SetTrigger ("fade");
				state++;
				Invoke ("DisplayText", 1f); // wait a second before displaying text
			} else if (state == 1) {
				instructions.text = "";
				instrImage.enabled = true;
				state++;
			} else if (state == 2) {
				instrImage.enabled = false;
                instructions.text = "\n\n\nCalling a PTA meeting...";
                SceneManager.LoadScene("startMenu");
            }
            
        }
	}

    private void DisplayText() {
        instructions.enabled = true;
        enter.enabled = true;
    }
}
