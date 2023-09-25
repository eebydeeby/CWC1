// Simple control to move opposing vehicles down toward player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleControl : MonoBehaviour
{
	public float speed;
	
    void Update()
    {
		// Moves the vehicle back (opposite to player) based on vertical input
		transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
