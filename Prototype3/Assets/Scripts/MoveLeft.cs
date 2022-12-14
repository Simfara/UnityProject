/*
 * CIS 350 
 * Simfara Ranjit
 * Prototype3 
 * This script moves the obstacle and the background to the left
 * giving it the effect that the player is running forward
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;
    private float leftBound = -15;

    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
       if(playerControllerScript.gameOver == false)
       {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
       }
       
        //destroy obstacles out of bounds off screen to the left
       if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
       {
            Destroy(gameObject);

       }
    }
}
