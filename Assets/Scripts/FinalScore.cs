using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

    private Text score;
    private Text message;
    private Text replaymsg;
	private Text highscore;
	private int minScore = 100;

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    // Use this for initialization
    void Start () {
       

        message = GameObject.Find("GameOverText").GetComponent<Text>();
        replaymsg = GameObject.Find("StartNewGameButton").GetComponentInChildren<Text>();
        score = GameObject.Find("Score").GetComponent<Text>();
		highscore = GameObject.Find("Highscore").GetComponent<Text>();
	

		if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("Highscore")) {
			PlayerPrefs.SetInt ("Highscore", PlayerPrefs.GetInt ("Score"));
			score.text = "You've set a new highscore of " + PlayerPrefs.GetInt ("Score") + " points!";
		} else {
			score.text = "Final Score: " + PlayerPrefs.GetInt("Score") + " / " + minScore;
		}

		highscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore") + " / " + minScore;

        // change message if player won
        if (PlayerPrefs.GetInt("Score") >= minScore) {
            message.text = "We're saved!\nYou successfully sanitized the youth!";
            replaymsg.text = "Start New Game";
        }



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
