/*
 * CIS 350 
 * Simfara Ranjit
 * Prototype3 
 * This script moves the player 
 * if the player collides with the money the score increment
 * if the player collides with the bomb it;s game Over
 * if the player collides with the ground it bounces.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;
    public bool islowEnough;

    private float lowerBound = 2;
    private float upperBound = 10;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;
    public ForceMode forceMode;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;

    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        
        
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        forceMode = ForceMode.Impulse;
        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, forceMode);

        islowEnough = false;

        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerRb.transform.position.y >= upperBound)
        {
            islowEnough = false;
        }
        else if(playerRb.transform.position.y >= lowerBound)
        {
            islowEnough = true;
        }
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && islowEnough && !gameOver )
        {
            playerRb.AddForce(Vector3.up * floatForce,forceMode);

        }
       
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            scoreManager.score++;
            Destroy(other.gameObject);
            

        }
        //if player collides with ground, bounce
        else if (other.gameObject.CompareTag("Ground"))
        {
            playerRb.AddForce(Vector3.up * 10, forceMode);
            playerAudio.PlayOneShot(bounceSound, 1.0f);
        }

    }

}
