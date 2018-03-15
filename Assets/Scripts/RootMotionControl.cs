using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RootMotionControl : MonoBehaviour {

    public Rigidbody projectile;

    private Animator anim;
    private Transform handHold;
    private Rigidbody currProjectile;

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
        currProjectile = Instantiate(projectile, handHold);
        currProjectile.isKinematic = true;
        currProjectile.transform.localPosition = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("velx", Input.GetAxis("Horizontal"));
        anim.SetFloat("vely", Input.GetAxis("Vertical"));
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
        currProjectile.AddForce(this.transform.forward * 30f, ForceMode.VelocityChange);

        // Destroy thing you threw after 2 seconds
        Destroy(GameObject.Find("ThrowableBall(Clone)"), 2.0f);

        // make sure you can receive another thing
        currProjectile = null;

        // get a new thing to throw after two-thirds of a second
        Invoke("Reload", 0.75f);

        
    }

    private void Reload() {
        // a new thing to throw
        currProjectile = Instantiate(projectile, handHold);
        currProjectile.isKinematic = true;
        currProjectile.transform.localPosition = Vector3.zero;
    }
}
