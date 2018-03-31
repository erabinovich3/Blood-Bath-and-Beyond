using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeenSpawner : MonoBehaviour {

    public GameObject[] spawnPoints;
    public GameObject[] spawnList;
    public int spawnInterval;

    float timer;
    
	// Use this for initialization
	void Start () {
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
