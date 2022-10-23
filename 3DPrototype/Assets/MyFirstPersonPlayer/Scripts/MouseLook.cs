using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public GameObject player;
    private float verticalLookRotation = 0f;

    //hIDE AND LOCK OUR CURSOR IN THE MIDDLE OF THE GAME
    private void OnApplicationFocus(bool focus)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Get mouse ipmut and assign it to two floats
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Rotate player GameObject with horizontal mouse input
        player.transform.Rotate(Vector3.up * mouseX);

        //Rotate camera around the x axis with vertical mouse input
        verticalLookRotation -= mouseY;

        //Clamp the rotation so the player does not over rotate
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        //apply rotation to camera based on clamp output 
        transform.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);


    }
}
