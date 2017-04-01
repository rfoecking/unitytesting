using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    // little bit of lag on the camera
    public float smoothing = 5f;

    private Vector3 offset;

    int degrees = 10;

    void Start()
    {
        offset = transform.position - target.position;
    }


    // physics update, following a physics update
    void FixedUpdate()
    {
        // place for camera to be up above the level
        Vector3 targetCamPos = target.position + offset;

       // offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
      //  transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
       // transform.LookAt(target.position);

       // transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, Time.deltaTime * smoothing);

        if (Input.GetMouseButton(0))
        {

            transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * degrees);
            //            transform.RotateAround (target.position, Vector3.left, Input.GetAxis ("Mouse Y")* dragSpeed);
        }
        //if (!Input.GetMouseButton(0))
        //    transform.RotateAround(target.position, Vector3.up, degrees * Time.deltaTime);
    }


    //void Start()
    //{
    //    offset = new Vector3(player.position.x, player.position.y + 8.0f, player.position.z + 7.0f);
    //}

    void LateUpdate()
    {
        //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * smoothing, Vector3.up) * offset;
        //transform.position = player.position + offset;
        //transform.LookAt(player.position);

      //k  transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, Time.deltaTime * smoothing);
    }


}
