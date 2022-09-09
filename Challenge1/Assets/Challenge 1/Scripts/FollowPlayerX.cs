/*
 * CIS 350 
 * Simfara Ranjit
 * Challenge1 
 * Script to make the Main Camera follow the plane object as it moves.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset = new Vector3(30, 0, 10);


    // Update is called once per frame
    void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}
