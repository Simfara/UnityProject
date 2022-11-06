/*
 * CIS 350 
 * Simfara Ranjit
 * Prototype5B
 * Script thats works with RayCast to shoot the target
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWithRayCast : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera cam;

    public ParticleSystem muzzleFlash;

    public float hitForce = 10f;
     void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hitInfo;
        //if we hit somth with the ray
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.gameObject.name);

           

            //Get the target script off the hit object
            Target target = hitInfo.transform.gameObject.GetComponent<Target>();

            //if target script found make the target take damage
            if (target !=null)
            {
                target.TakeDamage(damage);
            }
            //If the shot hits a rigidbody, apply a force
            if (hitInfo.rigidbody !=null)
            {
                hitInfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            }
        }
    }
}
