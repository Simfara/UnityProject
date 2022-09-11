using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//add this prefab to food and animal object
public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 20;
    public float bottomBound = -10;

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
            Debug.Log("GameOver!");

            Destroy(gameObject);
        }
        
    }
}
