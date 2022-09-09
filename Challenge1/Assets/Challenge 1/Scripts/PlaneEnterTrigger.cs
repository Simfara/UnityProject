using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this to trigger zone
public class PlaneEnterTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Plane") && !triggered)
        {
            triggered = true;
            ScoreManagerX.score++;
        }
    }
}
