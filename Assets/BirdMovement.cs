using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdMovement : MonoBehaviour {

    Vector3 velocity = Vector3.zero;
    public float flapSpeed = 100f;
    public float forwardSpeed = 1f;

    bool didFlap = false;
    

    Animator animator;

    bool dead = false;
    float deathCooldown;

    // Use this for initialization
    void Start () {
        animator = transform.GetComponentInChildren<Animator>();

        if(animator == null) {
            Debug.LogError("Didn't find Animator!");
        }
	}

    // Do Grpahic & Input updates here
    void Update() {
        if (dead) {
            deathCooldown -= Time.deltaTime;
        
            if(deathCooldown <= 0) {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
                    Application.LoadLevel(Application.loadedLevel);
                }
            }
        }
        else {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
                didFlap = true;
            }
        }
    }


    // Do Physics engine updates here
    void FixedUpdate(){

        if (dead)
            return;

        GetComponent<Rigidbody2D>().AddForce(Vector2.right * forwardSpeed);

        if (didFlap) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * flapSpeed);
            animator.SetTrigger("DoFlap");


            didFlap = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        animator.SetTrigger("Death");
        dead = true;
        deathCooldown = 0.7f;

    } 

}
