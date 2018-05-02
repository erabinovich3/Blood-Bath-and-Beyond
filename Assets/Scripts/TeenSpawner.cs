using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeenSpawner : MonoBehaviour {

    public GameObject[] spawnPoints;
    public GameObject[] spawnList;
    public float spawnInterval = 5f;

    float timer;
    
	// Use this for initialization
	void Start () {
        Debug.Log(GameController.controller.curMom);
        if (GameController.controller.curMom == 2)
        {
            spawnInterval = 2.5f;
        } else
        {
            spawnInterval = 5f;
        }
        timer = spawnInterval;
	}
	
	// Update is called once per frame
	void Update () {

        if (timer >= spawnInterval)
        {
            int sPIndex = Random.Range(0, spawnPoints.Length);
            GameObject currentPoint = spawnPoints[sPIndex];
            int sLIndex = Random.Range(0, spawnList.Length);
            GameObject currentSpawn = spawnList[sLIndex];
            Instantiate(currentSpawn, currentPoint.transform.position, currentPoint.transform.rotation);
            timer = 0f;
        }

        timer += Time.deltaTime;
    }
}
