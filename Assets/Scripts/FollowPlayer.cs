using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	// Sets up the variable for the vehicle to be followed
	public GameObject player; 
	// Sets up camera position based on an offset from the position of the player object
	private Vector3 offset;
	
    void LateUpdate()
    {
		// Updates the camera position
		transform.position = player.transform.position + offset;
    }
}
