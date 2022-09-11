/*
 * CIS 350 
 * Simfara Ranjit
 * Prototype2 
 * Script to destroy the game object ( food and animals) when they go out of bounds. 
 * TakeDamage method called when animal object go out of bound!
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//add this prefab to food and animal object
public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 20;
    public float bottomBound = -10;

    private HealthSystem healthSystemScript;

    private void Start()
    {
        healthSystemScript = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        //if food goes out of bounds
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < bottomBound)
        {
            // Debug.Log("GameOver!");

            //grab health system script and call the takeDamage()
            healthSystemScript.TakeDamage();

            Destroy(gameObject);
        }
        
    }
}
