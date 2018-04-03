using UnityEngine;
using System.Collections;
using System;


public class CameraControl : MonoBehaviour
{

    public GameObject[] moms;
    //public GameObject player;       //Public variable to store a reference to the player game object
    public float smoothing = 1f;

    private GameObject player;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
		//depends on game instead of calling on another script
		foreach (GameObject m in moms) {
			if (m.activeSelf) {
				player = m;
			} // set the player to the selected mom

		}
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = player.transform.position - transform.position;
    }

    void LateUpdate()
    {
        Animator player_animator = player.GetComponent<Animator>();
        float cam_multiplier = Mathf.Clamp(Math.Abs(player_animator.GetFloat("vely")) + 1, 1.0F, 1.5F);
        float desiredAngle = player.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle % 360, 0);
        transform.position = Vector3.Lerp(transform.position, player.transform.position - (rotation * offset * cam_multiplier), smoothing * Time.deltaTime);
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(30, desiredAngle % 360, 0), smoothing * Time.deltaTime);
    }
}