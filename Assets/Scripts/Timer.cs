using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    float timeLeft = 120.0f;
    Text time;

	// Use this for initialization
	void Start () {
        time = GetComponent<Text>();
        time.text = displayTime();
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime; // decrement time
        // update gui timer
        time.text = "Time: " + displayTime();

        // end game when timer runs out
        if (timeLeft <= 0) {
            SceneManager.LoadScene("endScreen");
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
        timeLeft += 15f;
    }
}
