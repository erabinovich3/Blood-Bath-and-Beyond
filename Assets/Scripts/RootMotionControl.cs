using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RootMotionControl : MonoBehaviour {

    

    private Animator anim;
    
   

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public float speedH = 2.0f;

    private AudioSource source;


    void Awake() {
        anim = GetComponent<Animator>();
        source = GetComponents<AudioSource>()[1];

        if (anim == null) {
            Debug.LogError("Animator not found");
        }

    }
    public void Step()
    {
        //source.Stop();
        source.Play();
       // Debug.Log("PrintEvent: step called at: " + Time.time);
    }


    // Update is called once per frame
    void Update () {
        yaw += speedH * Input.GetAxis("Mouse X");
        if (yaw == 0.0F)
        {
            yaw = 0.01F;
        }
        //transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        transform.Rotate(0, speedH * Input.GetAxis("Mouse X"), 0);
        //anim.SetFloat("velx", Input.GetAxis("Mouse X"));
        if (Input.GetAxis("Vertical") != 0.0F)
        {
            anim.SetFloat("vely", Input.GetAxis("Vertical"));
        }
        anim.SetFloat("velx", Input.GetAxis("Horizontal"));

    }


}
