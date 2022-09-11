/*
 * CIS 350 
 * Simfara Ranjit
 * Prototype2 
 * This script makes the animal and food prefabs move forward.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40;


    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
