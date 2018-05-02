using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

	public void GameRestarter() {
		SceneManager.LoadScene ("chooseMom");
	}

    public void LoadCredits() {
        SceneManager.LoadScene("credits");
    }
}
