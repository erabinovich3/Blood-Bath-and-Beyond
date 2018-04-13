using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text scoreView;
    public GameObject wine;

    private int score;
    private Animator scoreAnim;
    private Timer timer;

	// Use this for initialization
	void Awake () {
        score = 0;
        PlayerPrefs.SetInt("Score", 0); // reset score for end scene
        timer = GameObject.Find("Timer").GetComponent<Timer>();

        if (timer == null) {
            Debug.LogError("Timer not found");
        }
    }
	
	void spawnWine() {
        // set random position in level
        float x = Random.Range(-218, 164);
        float y = 5f;
        float z = Random.Range(-28, 178);

        // spawn wine
        Instantiate(wine, new Vector3(x,y,z), Quaternion.identity);
        Debug.Log("WINE SPAWNED");
    }

    public void AddScore(int num) {
        Debug.Log("Add Score called");
        score += num;
        

        if (scoreAnim == null) {
            scoreAnim = GameObject.Find("Chips").GetComponentInChildren<Animator>();
        }
        

        if (scoreAnim == null) {
            Debug.LogError("Score Animator not found");
        }

        if (num < 0) { // losing points
            scoreAnim.SetTrigger("rip");
        } else { // gaining points
            scoreAnim.SetTrigger("nice");
        }

        scoreView.text = "" + score + " / 100"; // update score display
        PlayerPrefs.SetInt("Score", score); // save score for end scene

        // when you hit something, there's a 50/50 chance for more wine to spawn
        if (Random.Range(0,2) == 1) {
            spawnWine();
        }
    }

    public void addTime() {
        timer.addTime();
    }
}
