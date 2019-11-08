using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GunScript : MonoBehaviour
{
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public Camera fpsCam;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            INT_Shootable shootable = hit.transform.GetComponentInChildren<INT_Shootable>();

            if (shootable != null)
            {
                shootable.WasShot();
                Debug.Log("Hit");
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }

        GameObject effect = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(effect, 2f);
    }
}
