/*
 * CIS 350 
 * Simfara Ranjit
 * Challenge1 
 * Script to increment score when plane enters a triggerzone.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this to trigger zone
public class PlaneEnterTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Plane") && !triggered)
        {
            triggered = true;
            ScoreManagerX.score++;
        }
    }
}
