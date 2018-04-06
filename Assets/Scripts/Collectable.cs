using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        // add time to the timer
        Timer timer = GameObject.Find("Timer").GetComponent<Timer>();
        timer.addTime();
        
        // Destroy collectible
        Destroy(this.gameObject);
        Debug.Log("WINE DESTROYED");
    }
}
