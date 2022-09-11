/*
 * CIS 350 
 * Simfara Ranjit
 * Prototype2 
 * This script Destroys the animal object,  when the food object collides with it.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach to food projectile prefab
public class DetectCollisions : MonoBehaviour
{ 
    private DisplayScore displayScoreScript;

    private void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
    }
    private void OnTriggerEnter(Collider other)
    {
        displayScoreScript.score++;
        //destroy animal
        Destroy(other.gameObject);
        //destroy food
        Destroy(gameObject);

    }
}
