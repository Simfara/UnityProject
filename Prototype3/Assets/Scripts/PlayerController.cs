/*
 * CIS 350 
 * Simfara Ranjit
 * Prototype3 
 * This script contorls the characters and contains all the required animations particle effects and sound effects,
 * Ex: when the player hits space bar the player jumps (jump animation and sound effect is triggered)
 * when the player hits an obstacle the player dies ( death animation, death sound effect is triggered)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private Rigidbody rb;
    public float jumpForce;
    public float gravityModifier;
    public ForceMode forceMode;

    public bool isOnGround = true;
    public bool gameOver = false;

    public Animator playerAnimator;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        //set a refrence to our rigidbody component
        rb = GetComponent<Rigidbody>();

        //set reference to our Animator component
        playerAnimator = GetComponent<Animator>();

        //set refernce to audio source component
        playerAudio = GetComponent<AudioSource>();

        //START RUNNING ANIMATION ON START
        playerAnimator.SetFloat("Speed_f", 1.0f);

        forceMode = ForceMode.Impulse;

        //Modify gravity
        if(Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //jumping when player presses space
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, forceMode);
            isOnGround = false;

            //SET TRIGGER TO PLAY JUMP ANIMATION
            playerAnimator.SetTrigger("Jump_trig");
            
            //stop playing dirtparticle
            dirtParticle.Stop();

            //play jump sound effect
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            //play dirt particle when player hits the ground.
            dirtParticle.Play();
        }

        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GameOver!");
            gameOver = true;

            //PLay death animation
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int",1);

            //PLay Explosion particle
            explosionParticle.Play();

            //stop dirt particle
            dirtParticle.Stop();

            //play crash sound effect
            playerAudio.PlayOneShot(crashSound,1.0f);
        }
    }
}
