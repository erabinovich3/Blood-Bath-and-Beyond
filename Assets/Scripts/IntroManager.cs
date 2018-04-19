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

	// Use this for initialization
	void Start () {
        bgAnim = GameObject.Find("BG").GetComponent<Animator>();
        titleAnim = GameObject.Find("Title").GetComponent<Animator>();
        subtitleAnim = GameObject.Find("Subtitle").GetComponent<Animator>();
        instructions = GameObject.Find("Instructions").GetComponent<Text>();
        enter = GameObject.Find("Enter").GetComponent<Text>();

        instructions.enabled = false;
        enter.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Submit")) {
            if (state == 0) {
                bgAnim.SetTrigger("fade_in");
                titleAnim.SetTrigger("fade");
                subtitleAnim.SetTrigger("fade");
                state++;

                Invoke("DisplayText", 1f); // wait a second before displaying text
            } else if (state == 1) {
                instructions.text = "Gameplay\n\nUse WASD or the arrow keys to move your mom, and control her direction with the mouse."
                    + "\n\nClick to throw and bring hygiene to the unkempt youth, but be sure to use the left Alt key to switch to the right ammo!"
                    + "\n\nThrowing the incorrect thing at a teen results in a loss of points, and the moms need all the help they can get!"
                    + "\n\n(Don't forget to look around for a special treat just for moms, it'll add to your time!)"
                    + "\n\nReach the target score before time runs out to save the youth from their unhygienic ways!";
                state++;
            } else if (state == 2) {
                instructions.text = "\n\n\nCalling a PTA meeting...";
                SceneManager.LoadScene("chooseMom");
            }
            
        }
	}

    private void DisplayText() {
        instructions.enabled = true;
        enter.enabled = true;
    }
}
