using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour {
    
	void Awake () {
        // get all the music gameObjects in scene
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        // destroy duplicates
        if (objs.Length > 1) {
            Destroy(this.gameObject);
        }

        // keep alive
        DontDestroyOnLoad(this.gameObject);
	}
}
