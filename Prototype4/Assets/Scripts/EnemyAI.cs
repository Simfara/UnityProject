
/*
 * CIS 350 
 * Simfara Ranjit
 * Prototype4
 * Script that manages the enemy to move towards the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody enemyRb;
    public GameObject player;
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        //add force toward the direction from the player to the enemy

        //vector for direction from enemy to player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        //ADD FORCE TOWARD PLAYER
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

}
