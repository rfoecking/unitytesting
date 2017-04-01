using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WowWalk : MonoBehaviour {
    float turnSpeed = 5.0f;
    float moveSpeed = 10.0f;
    float mouseTurnMultiplier = 2;

    private float x;
    private float z;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // x is used for the x axis.  set it to zero so it doesn't automatically rotate
        x = 0;

        // check to see if the W or S key is being pressed.  
        z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        if (z != 0f)
        {
            animator.SetBool("IsWalking", true);
        } else
        {
            animator.SetBool("IsWalking", false);
        }

        // Move the character forwards or backwards
        transform.Translate(0, 0, z);

        // Check to see if the A or S key are being pressed
        if (Input.GetAxis("Horizontal") != 0f)
        {
            // Get the A or S key (-1 or 1)
            x = Input.GetAxis("Horizontal") * turnSpeed;
        }

        // Check to see if the right mouse button is pressed
        if (Input.GetMouseButton(1))
        {
            // Get the difference in horizontal mouse movement
            x = Input.GetAxis("Mouse X") * turnSpeed * mouseTurnMultiplier;
        }

        // rotate the character based on the x value
        transform.Rotate(0, x, 0);
    }
}
