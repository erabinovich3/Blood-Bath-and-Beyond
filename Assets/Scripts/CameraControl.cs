using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object
    public float smoothing = 1f;

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = player.transform.position - transform.position;
    }

    void LateUpdate()
    {
        float desiredAngle = player.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = Vector3.Lerp(transform.position, player.transform.position - (rotation * offset), smoothing * Time.deltaTime);
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(30, desiredAngle, 0), smoothing * Time.deltaTime);
    }
}