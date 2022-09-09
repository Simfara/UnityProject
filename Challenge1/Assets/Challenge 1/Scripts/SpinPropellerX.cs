/*
 * CIS 350 
 * Simfara Ranjit
 * Challenge1 
 * Script to make the propellor object on the plane to spin.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
   
    public float rotationSpeed;
   

    // Update is called once per frame
    void FixedUpdate()
    {
       

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime );
    }
}
