using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(CapsuleCollider))]
public class Hit : MonoBehaviour {

    private Animator anim;
    private CapsuleCollider collider;

    private void Awake() {
        anim = GetComponent<Animator>();

        if (anim == null) {
            Debug.LogError("Animator not found");
        }

        collider = GetComponent<CapsuleCollider>();

        if (collider == null) {
            Debug.LogError("Capsule Collider not found");
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Projectiles")) {
            // play hit animation
            anim.SetTrigger("hit");

            // change CapsuleCollider to trigger, non longer an obstacle
            collider.isTrigger = true;
        }
    }
}
