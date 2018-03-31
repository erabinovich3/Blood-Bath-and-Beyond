using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RootMotionControl : MonoBehaviour {

    public Rigidbody projectile;

    private Animator anim;
    private Transform handHold;
    public Rigidbody currProjectile;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public float speedH = 2.0f;

    void Awake() {
        handHold = this.transform.Find("mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/" +
            "mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/ProjectileHoldSpot");

        if (projectile == null) {
            Debug.LogError("projectile has not been assigned a value.");
        }

        anim = GetComponent<Animator>();

        if (anim == null) {
            Debug.LogError("Animator not found");
        }
    }

    // Use this for initialization
    void Start () {
        // initial thing to throw
        Reload();
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
        
    }

    private void FixedUpdate() {
        if (currProjectile != null && Input.GetButtonDown("Fire1")) {
            anim.SetBool("throw", true);
        } else {
            anim.SetBool("throw", false);
        }
    }

    private void Throw() {
        // release the thing
        currProjectile.transform.SetParent(null);
        // make thing under force control
        currProjectile.isKinematic = false;

        currProjectile.velocity = Vector3.zero;
        currProjectile.angularVelocity = Vector3.zero;

        // add force to the thing to actually throw it
        currProjectile.AddForce(this.transform.forward * 60f, ForceMode.VelocityChange);

        // Destroy thing you threw after 2 seconds
        Destroy(GameObject.Find("ThrowableBall(Clone)"), 2.0f);

        // make sure you can receive another thing
        currProjectile = null;

        // get a new thing to throw after two-thirds of a second
        Invoke("Reload", 0.75f);

        
    }

    public void Reload() {
        // a new thing to throw
        currProjectile = Instantiate(projectile, handHold);
        currProjectile.isKinematic = true;
        currProjectile.transform.localPosition = Vector3.zero;
    }
}
