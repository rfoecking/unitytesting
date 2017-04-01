using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WowCameraFollow : MonoBehaviour {
    Transform target;

    float distance = 10.0f;

    float xSpeed = 250.0f;
    float ySpeed = 120.0f;

    float yMinLimit = -20f;
    float yMaxLimit = 80f;

    float zoomRate = 20f;

    private float x = 0.0f;
    private float y = 0.0f;

    void Start()
    {
        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }

    void LateUpdate()
    {

        float test = 0f;

        if (target)
        {
            if (Input.GetMouseButton(0))
            {
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
                test = y;
            }
            distance += -(Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * zoomRate * Mathf.Abs(distance);
            if (distance < 2.5f)
            {
                distance = 2.5f;
            }
            if (distance > 20f)
            {
                distance = 20f;
            }


            y = ClampAngle(y, yMinLimit, yMaxLimit);

            //Debug.Log("y: "+y+" test: "+test);

            if (y == yMinLimit || test == yMinLimit)
        {
                // This is to allow the camera to slide across the bottom if the player is too low in the y
                distance += -(Input.GetAxis("Mouse Y") * Time.deltaTime) * 10 * Mathf.Abs(distance);
            }

            Quaternion rotation = Quaternion.Euler(y, x, 0f);
            Vector3 position = rotation * new Vector3(0.0f, 2.0f, -distance) + target.position;

            //Debug.Log("Distance: "+distance);
            transform.rotation = rotation;
            transform.position = position;
        }
    }

    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f)
            angle += 360f;
        if (angle > 360f)
            angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}

