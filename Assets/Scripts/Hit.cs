using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(CapsuleCollider))]
public class Hit : MonoBehaviour {

    private Animator anim;
    private CapsuleCollider collider;
    private GameManager manager;
    private AudioSource source;

    private void Awake() {
        source = GetComponent<AudioSource>();

        anim = GetComponent<Animator>();

        if (anim == null) {
            Debug.LogError("Animator not found");
        }

        collider = GetComponent<CapsuleCollider>();

        if (collider == null) {
            Debug.LogError("Capsule Collider not found");
        }

        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision) {
        // make sure a projectile hit teen, not something else
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Projectiles")) {
            //play hit noise
            source.Play();
            // play hit animation
            anim.SetTrigger("hit");
            gameObject.GetComponent<TeenMovement>().hit();

            // add to score
            manager.AddScore(20);

            // change CapsuleCollider to horizontal and decrease radius so he hits the ground
            collider.radius = 0.15f;
            collider.direction = 2;
        }
    }
}
