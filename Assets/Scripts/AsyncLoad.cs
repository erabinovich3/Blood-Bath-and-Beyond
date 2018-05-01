using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsyncLoad : MonoBehaviour {

    private Slider slider;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        StartCoroutine(LoadNewScene());
    }
	
	// Update is called once per frame
	void Update () {
        slider.value += Time.deltaTime / 5;
        if (slider.value >= .95)
        {
            slider.value = 0;
        }
	}


    IEnumerator LoadNewScene()
    {


        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = SceneManager.LoadSceneAsync("level1");

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {
            yield return null;
        }

    }
}
