using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {
	public float speed = 6f;
	Vector3 movement;

    Vector3 lastMovement;

	Animator anim;
	Rigidbody playerRigidbody;

	int floorMask;
	float camRayLength = 100f;

	void Awake() {
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	// normal update runs with..
	// fires every physics update
	void FixedUpdate() {
		// will have value of -1, 0, or 1
		// immediately snap to full speed
		// axis is input
		// Horizontal axis a and d keys
		// left and right arrows
		/// vertical axis w and s keys, up and down
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
		//Turning ();
		Animating (h, v);
	}

    //void Move(float h, float v) {
    //	movement.Set (h, 0f, v); // translate to lateral movement in the game
    //	// normalize diagonal movement, make sure that the size is always 1
    //	// make sure that the player moves at the same speed no matter 
    //	// which direction

    //	movement = movement.normalized * speed * Time.deltaTime;

    //	playerRigidbody.MovePosition (transform.position + movement);
    //}

    void Move(float h, float v)
    {
        Vector3 movement = new Vector3(h, 0.0f, v);
        lastMovement = new Vector3(h, 0.0f, v);
        // transform.rotation = Quaternion.LookRotation(movement);

        if (h != 0f || v != 0f) { 
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        } else
        {

        }
    }


    // trying to keep players rotation int he same direction
    // as the mouse is facing
    void Turning() {
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			playerRigidbody.MoveRotation (newRotation);
		}
	}

	void Animating(float h, float v) {
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}
}
