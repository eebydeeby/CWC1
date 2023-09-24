// A script for rotating the propeller's object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSpin : MonoBehaviour
{	
	
    // Rotates the propeller along the z axis every frame
    void Update()
    {
		transform.Rotate(0, 0, 5);
    }
}
