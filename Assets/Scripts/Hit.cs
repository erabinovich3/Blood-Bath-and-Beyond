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
            // change layer mask of projectile to prevent multiple hits
            //collision.collider.gameObject.layer = LayerMask.NameToLayer("Default");
            // change layer mask of teen to prevent bugs with mom collision and multiple hits
            this.gameObject.layer = LayerMask.NameToLayer("Clean-Teen");

            //play hit noise
            source.Play();
            // play hit animation
            anim.SetTrigger("hit");
            gameObject.GetComponent<TeenMovement>().hit();

            // add to score only if correct weapon, else take score
            if (this.gameObject.tag == "Boy") {
                if (collision.gameObject.tag == "Soap") { // right thing, add points
                    manager.AddScore(20);
                } else { // wrong thing, subtract score
                    manager.AddScore(-20);
                }
            } else if (this.gameObject.tag == "Girl") {
                if (collision.gameObject.tag == "Tampon") { // right thing, add points
                    manager.AddScore(20);
                }
                else { // wrong thing, subtract score
                    manager.AddScore(-20);
                }
            }

            // change CapsuleCollider to horizontal and decrease radius so he hits the ground
            collider.radius = 0.15f;
            collider.direction = 2;
        }
    }
}
