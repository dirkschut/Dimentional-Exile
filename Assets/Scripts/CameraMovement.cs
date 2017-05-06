using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the Movement of the camera
/// </summary>
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

    public float CameraSpeed = 0.1f;

	/// <summary>
    /// Is called once per frame to update the Camera
    /// </summary>
	void Update ()
    {
        Vector3 cameraMovement = new Vector3(
            Input.GetAxis("Horizontal") * CameraSpeed,
            Input.GetAxis("Vertical") * CameraSpeed,
            0);

        transform.Translate(cameraMovement);

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
