using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float horsePower = 20.0f;
	[SerializeField] float turnSpeed = 45.0f;
	[SerializeField] GameObject centerOfMass;
	[SerializeField] TextMeshProUGUI speedometerText;
	[SerializeField] float speed;
	[SerializeField] TextMeshProUGUI rpmText;
	[SerializeField] float rpm;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
	private float horizontalInput;
	private float forwardInput;
	private Rigidbody playerRb;

	void Start(){
		playerRb = GetComponent<Rigidbody>();
		playerRb.centerOfMass = centerOfMass.transform.localPosition;
	}

	void Update(){
		speed = Mathf.Round(playerRb.velocity.magnitude);
		speedometerText.SetText("Speed: " + speed + " mph");
		rpm = Mathf.Round( (speed % 30) * 10);
		rpmText.SetText("RPM: " + rpm);
	}

    void FixedUpdate()
    {
		// Sets up input parameters using Unity input API
		horizontalInput = Input.GetAxis("Horizontal");
		forwardInput = Input.GetAxis("Vertical");
		
		// Moves the vehicle forward based on vertical input
		//playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
		
		//Rotates the car based on horzontal input
		//transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
		
	    if (IsOnGround())
	           {

	               //Move the vehicle forward
	               //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
	               playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
	               //Turning the vehicle
	               transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

	               //print speed
	               speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f);
	               speedometerText.SetText("Speed: " + speed + " mph");

	               //print RPM
	               rpm = Mathf.Round((speed % 30) * 40);
	               rpmText.SetText("RPM: " + rpm);
	           }
	       }

	       bool IsOnGround()
	       {
	           wheelsOnGround = 0;
	           foreach (WheelCollider wheel in allWheels)
	           {
	               if (wheel.isGrounded)
	               {
	                   wheelsOnGround++;
	               }
	           }
	           if (wheelsOnGround == 4)
	           {
	               return true;
	           } else
	           {
	               return false;
	       }
	   }
}