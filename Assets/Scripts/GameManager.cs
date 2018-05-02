using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text scoreView;
    public GameObject wine;
    public AudioClip gainPoints;
    public AudioClip losePoints;

    public int score;
    private Animator scoreAnim;
    private Timer timer;
    private AudioSource source;
    private int sound;

	// Use this for initialization
	void Awake () {
        score = 0;
        PlayerPrefs.SetInt("Score", 0); // reset score for end scene

		if (!PlayerPrefs.HasKey ("Highscore")) {
			PlayerPrefs.SetInt ("Highscore", 0);
		}

        sound = 0;

        timer = GameObject.Find("Timer").GetComponent<Timer>();

        if (timer == null) {
            Debug.LogError("Timer not found");
        }

        source = GetComponent<AudioSource>();

        if (source == null) {
            Debug.LogError("Audio source not found");
        }
    }
	
	void spawnWine() {
        // set random position in level
        float x = Random.Range(-218, 164);
        float y = 5f;
        float z = Random.Range(-50, 178);

        // make sure point is on nav mesh
        NavMeshHit hit;
        NavMesh.SamplePosition(new Vector3(x, y, z), out hit, 13f, NavMesh.AllAreas);

        // spawn wine, adjust height
        Instantiate(wine, hit.position + new Vector3(0, 5f, 0), Quaternion.identity);
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
            sound = 1; // set sound
            Invoke("PlaySound", 1f);
        } else { // gaining points
            scoreAnim.SetTrigger("nice");
            sound = 0; // set sound
            Invoke("PlaySound", 0.5f);
        }

        scoreView.text = "" + score + " / 100"; // update score display
        PlayerPrefs.SetInt("Score", score); // save score for end scene

        // when you hit something, there's a 33% chance for more wine to spawn
        if (Random.Range(0,3) == 1) {
            spawnWine();
        }
    }

    public void addTime() {
        timer.addTime();
    }

    private void PlaySound() {
        if (sound == 0) { // gain points sound
            source.PlayOneShot(gainPoints);
        } else if (sound == 1) { // lose points sound
            source.PlayOneShot(losePoints);
        }
    }
}
