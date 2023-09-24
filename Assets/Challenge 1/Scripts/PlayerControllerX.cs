// Control's the plane's movement and handles input from player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed; // Adjustable variable for plane speed
    public float rotationSpeed; // Controls how quickly the plane titls up or down
	
	// Variable assigned for receiving input from player, based on Unity's input API
    public float verticalInput;

    // Update is called once per frame
    void FixedUpdate()
    {
		
	    // Update the plane's direction based on the user's vertical input
		// Controls are Up/Down keys, or W/S
	    verticalInput = Input.GetAxis("Vertical");
		
        // Move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed);

        // Tilt the plane up/down based on keys pressed
		// Up/W tilt upward, Down/S tilt downward
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);
    }
}
