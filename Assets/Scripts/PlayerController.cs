using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float horsePower = 20.0f;
	[SerializeField] float turnSpeed = 45.0f;
	private float horizontalInput;
	private float forwardInput;
	private Rigidbody playerRb;

	void Start(){
		playerRb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		// Sets up input parameters using Unity input API
		horizontalInput = Input.GetAxis("Horizontal");
		forwardInput = Input.GetAxis("Vertical");
		
		// Moves the vehicle forward based on vertical input
		playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
		
		//Rotates the car based on horzontal input
		transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
