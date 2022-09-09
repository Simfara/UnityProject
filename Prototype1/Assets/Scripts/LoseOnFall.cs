/*
 * CIS 350 
 * Simfara Ranjit
 * Prototype1 
 * Script to make the player lose if they fall of the road.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to the player
public class LoseOnFall : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1)
        {
            ScoreManager.gameOver = true;
        }
    }
}
