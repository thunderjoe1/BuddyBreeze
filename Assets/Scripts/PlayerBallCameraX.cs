using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallCameraX : MonoBehaviour
{
//	Transform currentPosition;
	float rotationX; //How much the camera is rotating on the X axis.
//	float rotationY; //How muxh the camera is rotating on the Y axis.
	Transform tf; //The transform of this object.

	//public GameObject playerBall;
	//public Vector3 cameraPosition;

	void Start ()
	{
		tf = transform;
	}

	void FixedUpdate ()
	{
		rotationX = Input.GetAxis ("VerticalRight");
//		rotationY = Input.GetAxis ("HorizontalRight");
	
		tf.Rotate (new Vector3 (rotationX * -1f,0.0f,0.0f) * 100 * Time.deltaTime);
	}
}