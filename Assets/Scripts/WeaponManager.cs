using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
    public Rigidbody[] weaponList;

    RootMotionControl movement;
    int curIndex = 0;
    // Use this for initialization
    void Start () {
        movement = GetComponent<RootMotionControl>();
    }
	
	// Update is called once per frame
	void Update () {
        if (weaponList.Length > 1 && Input.GetButtonDown("Fire3")) {
            Debug.Log("clicked");
            curIndex++;
            if (curIndex == weaponList.Length)
            {
                curIndex = 0;
            }
            Destroy(movement.currProjectile);
            movement.projectile = weaponList[curIndex];
            movement.Reload();
            
        }

    }
}
