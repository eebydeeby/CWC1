//A simple script for moving the camera based on the vehicle's position

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
	
	//Sets the camera's distance from the plane as an offset
    private Vector3 offset = new Vector3(50, 0, 0);

    void Update()
    {
		//Updates the camera's position using the set offset
        transform.position = plane.transform.position + offset;
    }
}
