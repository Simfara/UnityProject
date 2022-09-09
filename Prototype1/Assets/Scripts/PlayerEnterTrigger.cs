/*
 * CIS 350 
 * Simfara Ranjit
 * Prototype1 
 * Script to increment the score when the player enters a triggerzone.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach this to the player
public class PlayerEnterTrigger : MonoBehaviour
{
 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerZone"))
        {
            ScoreManager.score++;
        }
    }

}
