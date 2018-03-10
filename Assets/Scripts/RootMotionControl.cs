using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RootMotionControl : MonoBehaviour {

    private Animator anim;

    void Awake() {
        anim = GetComponent<Animator>();

        if (anim == null) {
            Debug.LogError("Animator not found");
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // move
        Move();
	}

    void Move() {
        anim.SetFloat("velx", Input.GetAxis("Horizontal"));
        anim.SetFloat("vely", Input.GetAxis("Vertical"));
    } 
}
