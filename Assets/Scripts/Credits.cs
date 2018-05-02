using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    public Button start;
    public Button quit;

    private Text credits;

	// Use this for initialization
	void Start () {
        //start = GameObject.Find("Start Menu").GetComponent<Button>();
        start.onClick.AddListener(LoadStart);

        //quit = GameObject.Find("Quit").GetComponent<Button>();
        quit.onClick.AddListener(Quit);

        credits = GameObject.Find("Credits").GetComponent<Text>();
	}

    public void LoadStart() {
        SceneManager.LoadScene("startMenu");
    }

    public void Quit() {
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
