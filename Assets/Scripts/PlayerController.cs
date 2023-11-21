using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float horsePower = 20.0f; // Amount of force applied to car when moving
	[SerializeField] float turnSpeed = 45.0f;
	[SerializeField] GameObject centerOfMass; // Determines where centre of mass for car is
	
	[SerializeField] TextMeshProUGUI speedometerText;
	[SerializeField] float speed; // Speed to be displayed
	[SerializeField] TextMeshProUGUI rpmText;
	[SerializeField] float rpm; // RPM to be displayed
	
    [SerializeField] List<WheelCollider> allWheels; // Gets a list of all wheel colliders
    [SerializeField] int wheelsOnGround;
	
	private float horizontalInput;
	private float forwardInput;
	private Rigidbody playerRb;

	void Start(){
		playerRb = GetComponent<Rigidbody>();
		playerRb.centerOfMass = centerOfMass.transform.localPosition;
	}

	// Updates text on screen with speed and RPM
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
		
	    if (IsOnGround()) // Only applies forces if all 4 wheels ar on ground
	    	{
	  		   // Move the vehicle forward
	           playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
	           
			   // Turning the vehicle
	           transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

	           // Print speed
	           speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f);
	           speedometerText.SetText("Speed: " + speed + " mph");

	           // Print RPM
	           rpm = Mathf.Round((speed % 30) * 40);
	           rpmText.SetText("RPM: " + rpm);
	       	}
		}

	// Checks if all 4 wheel colliders are colliding with ground and returns a bool
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
           }
	       else {
 	  	       return false;
           }
       }
}