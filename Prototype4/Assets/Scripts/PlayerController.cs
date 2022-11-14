using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5.0f;

    private float forwardInput;

    private GameObject focalPoint;

    public bool hasPowerUP;

    private float powerUpStrength = 15.0f;

    public GameObject powerUpIndicator;

    public bool loss;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
       forwardInput = Input.GetAxis("Vertical");

        //move our powerup Indicator to the gorund below the player

        powerUpIndicator.transform.position = transform.position + new Vector3(0, -.05f, 0);


        if (transform.position.y < -10)
        {
            loss=true;
        }

    }
    private void FixedUpdate()
    {
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            hasPowerUP = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDownRoutine());
            powerUpIndicator.gameObject.SetActive(true);
         
        }
    }

    IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUP = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUP)
        {
            Debug.Log("Player Collided with" + collision.gameObject.name + "with powerUp set to " + hasPowerUP);

            //get a local refernce to the eney rb

            Rigidbody enemeyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            //set a vector 3 with  adirection away from the player

            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            //add force away from player
            enemeyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
}
