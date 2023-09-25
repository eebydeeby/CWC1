// Script to handle control and movement of player vehicle

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
	private float speed = 20.0f; // Movement speed of player vehicle
	private float turnSpeed = 45.0f; // How fast the vehicle turns
	private float horizontalInput; // Variable for receiving turn controls
	private float forwardInput; // Variable for receiving back/forth controls

    void Update()
    {
		// Sets up input parameters using Unity input API
		horizontalInput = Input.GetAxis("Horizontal 2");
		forwardInput = Input.GetAxis("Vertical 2");
		
		// Moves the vehicle forward based on vertical input
		transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
		
		//Rotates the car based on horzontal input
		transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
