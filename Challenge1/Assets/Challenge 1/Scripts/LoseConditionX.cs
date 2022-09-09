/*
 * CIS 350 
 * Simfara Ranjit
 * Challenge1 
 * Script that contins the losing condition of the game.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this to plane
public class LoseConditionX : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // if player.transform.position.y is above 80 
        //or below -51 and if so, display game over text.

        if (transform.position.y > 80 || transform.position.y < -51)
        {
            ScoreManagerX.gameOver = true;
        }
    }
}
