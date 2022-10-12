/*
 * CIS 350 
 * Simfara Ranjit
 * Prototype5A 
 * Script when the player hits the end of the level/ finish zone
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public bool triggered = false;

   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("before the if statement");
        if (other.CompareTag("Player") && !triggered)
        {
            Debug.Log("test");
            triggered = true;
  
        }
    }
}
