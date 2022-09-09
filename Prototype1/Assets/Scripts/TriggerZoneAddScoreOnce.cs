/*
 * CIS 350 
 * Simfara Ranjit
 * Prototype1 
 * Script to increment score when the player enters the trigger zone!
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this to a triggerzone
public class TriggerZoneAddScoreOnce : MonoBehaviour
{

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            ScoreManager.score++;
        }
    }
}
