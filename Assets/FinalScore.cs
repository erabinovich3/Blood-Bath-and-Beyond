using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

    private Text score;
    private Text message;
    private Text replaymsg;

	// Use this for initialization
	void Start () {
        message = GameObject.Find("GameOverText").GetComponent<Text>();
        replaymsg = GameObject.Find("StartNewGameButton").GetComponentInChildren<Text>();
        score = GameObject.Find("Score").GetComponent<Text>();
        // display final score
        score.text = "Final Score: " + PlayerPrefs.GetInt("Score") + " / 100";

        // change message if player won
        if (PlayerPrefs.GetInt("Score") >= 10) {
            message.text = "We're saved!\nYou successfully sanitized the youth!";
            replaymsg.text = "Start New Game";
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
