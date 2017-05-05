using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

	/// <summary>
    /// Instantiates the CameraMovement script object
    /// </summary>
	void Start ()
    {
        oldPosition = this.transform.position;
	}

    public Vector3 oldPosition;

	/// <summary>
    /// Is called once per frame to update the Camera
    /// </summary>
	void Update ()
    {
		if(this.transform.position != oldPosition)
        {
            oldPosition = this.transform.position;

            HexComponent[] hexes = GameObject.FindObjectsOfType<HexComponent>();
            foreach(HexComponent hex in hexes)
            {
                hex.UpdatePosition();
            }
        }
	}
}
