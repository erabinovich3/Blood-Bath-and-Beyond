using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
    public Rigidbody[] weaponList;
    public float reloadCD = 5;
    public Rigidbody projectile;
    public Rigidbody currProjectile;

    private Transform handHold;
    private Animator anim;
    RootMotionControl movement;
    int curIndex = 0;
    private float reloadTimer;
    private GameObject soap;
    private GameObject tampon;

    void Awake () {

        handHold = this.transform.Find("mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/" +
            "mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/ProjectileHoldSpot");

        projectile = weaponList[0];
        if (projectile == null)
        {
            Debug.LogError("projectile has not been assigned a value.");
        }

        soap = GameObject.Find("Soap Panel");
        tampon = GameObject.Find("Tampon Panel");
        tampon.SetActive(false);

    }

    void Start()
    {
        anim = GetComponent<Animator>();
        // initial thing to throw
        Reload();
    }


    private void FixedUpdate()
    {
        reloadTimer += Time.deltaTime;
        if (currProjectile != null && Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("throw");
        }
        else
        {
            //anim.SetBool("throw", false);
        }
        if (weaponList.Length > 1 && Input.GetButtonDown("Fire2") && reloadTimer >= reloadCD)
        {
            reloadTimer = 0f;
            curIndex++;
            if (curIndex >= weaponList.Length)
            {
                curIndex = 0;
                soap.SetActive(true);
                tampon.SetActive(false);
            } else {
                soap.SetActive(false);
                tampon.SetActive(true);
            }
            if (currProjectile != null ) {
                Destroy(currProjectile.gameObject);
            }
            

            //Debug.Log(currProjectile);
            projectile = weaponList[curIndex];
            Invoke("Reload", 0.75f);

        }
    }

    private void Throw()
    {
        // release the thing
        currProjectile.transform.SetParent(null);
        // make thing under force control
        currProjectile.isKinematic = false;

        currProjectile.velocity = Vector3.zero;
        currProjectile.angularVelocity = Vector3.zero;

        // add force to the thing to actually throw it
        currProjectile.AddForce(this.transform.forward * 60f, ForceMode.VelocityChange);

        // Destroy thing you threw after 2 seconds
        Destroy(currProjectile.gameObject,  2.0f);

        // make sure you can receive another thing
        currProjectile = null;

        // get a new thing to throw after two-thirds of a second
        Invoke("Reload", 0.75f);


    }

    public void Reload()
    {
        // a new thing to throw
        currProjectile = Instantiate(projectile, handHold);
        currProjectile.isKinematic = true;
        currProjectile.transform.localPosition = Vector3.zero;
    }
}
