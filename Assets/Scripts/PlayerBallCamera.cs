using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallCamera : MonoBehaviour
{
	Transform currentPosition;

	public GameObject playerBall;
	//public Vector3 cameraPosition;

	void Start ()
	{
		currentPosition = transform;
	}

	void Update ()
	{
		currentPosition.transform.position = playerBall.transform.position;
	}
}