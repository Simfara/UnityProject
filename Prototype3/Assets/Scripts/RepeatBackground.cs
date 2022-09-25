/*
 * CIS 350 
 * Simfara Ranjit
 * Prototype3 
 * This script loops the background image
 * stops looping whne the game is over
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;


    // Start is called before the first frame update
    void Start()
    {
        //save the starting position of the bg to  a Vector2 Variable
        startPosition = transform.position;

        //set the repeatWidth to half of the bg using the BoxCollider
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //if the bg is further to the left than the repeat Width , reset it to startposition
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;

        }
    }
}
