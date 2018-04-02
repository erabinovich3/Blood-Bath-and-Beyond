using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        // add time to the timer?

        Destroy(this.gameObject);
    }
}
