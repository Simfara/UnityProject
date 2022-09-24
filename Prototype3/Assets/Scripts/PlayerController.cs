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

    // Start is called before the first frame update
    void Start()
    {
        //set a refrence to our rigidbody component
        rb = GetComponent<Rigidbody>();

        //set reference to our Animator component
        playerAnimator = GetComponent<Animator>();

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
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GameOver!");
            gameOver = true;

            //PLay death animation
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int",1);
        }
    }
}
