using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallCameraY : MonoBehaviour
{
	Transform currentTransform;
//	float rotationX; //How much the camera is rotating on the X axis.
	float rotationY; //How muxh the camera is rotating on the Y axis.
	Transform tf; //The transform of this object.

	public GameObject playerBall;

	void Start ()
	{
		tf = transform;
		currentTransform = transform;
	}

	void Update ()
	{
		currentTransform.position = playerBall.transform.position;
	}

	void FixedUpdate ()
	{
//		rotationX = Input.GetAxis ("VerticalRight");
		rotationY = Input.GetAxis ("HorizontalRight");
	
		tf.Rotate (new Vector3 (0.0f,rotationY,0.0f) * 100 * Time.deltaTime);
	}
}