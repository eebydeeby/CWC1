// Script for handling player camera input and moving camera based on distance (offset) from player 2 vehicle's position

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer2 : MonoBehaviour
{
    public GameObject player; // Public variable for handling which object to follow
    private Vector3 offset; // Handles how far to distance camera away from player object
    private float cameraInput; // Handles player input for camera controls

    void LateUpdate()
    {
        // Variable for handling camera control input
		// Jump (.) key is used to move camera
        cameraInput = Input.GetAxis("Jump 2");
		
        // Checks if player is holding down the jump key
        if (cameraInput == 0)
        {
            // Moves camera offset to behind and above the vehicle
            offset = new Vector3(0, 5, -7);
        }
        else
        {
            // Moves camera offset to the front of the vehicle
            offset = new Vector3(0f, 3f, 10f);
        }
		
        // Updates the camera position and rotation with the current camera offset and vehicle rotation
        transform.position = player.transform.position + offset;
		transform.rotation = player.transform.rotation;
    }
}