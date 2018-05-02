using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public AudioClip gain;

    float timeLeft = 60.0f;
    Text time;
    Animator anim;
    AudioSource source;

	// Use this for initialization
	void Start () {
        time = GetComponent<Text>();
        time.text = displayTime();

        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime; // decrement time
        // update gui timer
        time.text = "Time: " + displayTime();

        // end game when timer runs out
        if (timeLeft <= 0) {
            SceneManager.LoadScene("endScreen");
            GameController.controller.gamesPlayed++;
        }
	}

    string displayTime() {
        string display = (int)(timeLeft / 60) + ":";

        if ((int)(timeLeft % 60) < 10) {
            display += "0" + (int)(timeLeft % 60);
        } else {
            display += (int)(timeLeft % 60);
        }

        return display;
    }

    public void addTime() {
        anim.SetTrigger("add-time"); // trigger added time animation
        if (GameController.controller.curMom == 1)
        {
            timeLeft += 45f;
        }
        else
        {
            timeLeft += 30f;
        }
        
        source.PlayOneShot(gain);
    }
}
