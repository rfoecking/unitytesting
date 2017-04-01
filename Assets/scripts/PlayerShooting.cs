using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    LineRenderer line;
    Ray ray = new Ray();
    int shootableMask;
    public float shootRange;
    public float shootFromYValue;
    float timer;
    float effectsTimer;
    public float timeBetweenBullets;
    public float timeBeforeEffectsFade;
    bool justShot = false;

    public Vector3 shootOriginAdjustment;

	void Start () {
        line = GetComponent<LineRenderer>();
        shootableMask = LayerMask.GetMask("Shootable");
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (justShot)
            effectsTimer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
            justShot = true;
        }

        if (effectsTimer >= timeBeforeEffectsFade)
        {
            line.enabled = false;
            effectsTimer = 0;
        }
    }

    void Shoot () {
        ray.origin = transform.position + shootOriginAdjustment;
        line.SetPosition(0, ray.origin);
        ray.direction = transform.forward;
        RaycastHit hit;
       
        if (Physics.Raycast(ray, out hit, shootRange, shootableMask))
        {
            Debug.Log(hit.point);
            Debug.DrawLine(ray.origin, hit.point);
            line.SetPosition(1, hit.point);
            GameObject hitObject = hit.collider.gameObject;
            Destroy(hitObject);
        } else
        {
            line.SetPosition(1, ray.origin + ray.direction * shootRange);
        }
        line.enabled = true;
        timer = 0;
	}
}
