/*
 * CIS 350 
 * Simfara Ranjit
 * Prototype5B
 * Script thats displays "you win" when player enters the end trigger zone!
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTriggerZone : MonoBehaviour
{
    private bool triggered = false;
    public Text textbox;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerZone") && !triggered)
        {
            triggered = true;
            textbox.text = "You Win!";
        }
    }
}
