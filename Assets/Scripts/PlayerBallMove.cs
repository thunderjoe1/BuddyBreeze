using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallMove : MonoBehaviour 
{
	private Rigidbody rb; //The player's rigidbody.

	float moveHorizontal;
	float moveVertical;
	Vector3 movement; //The directions the object is moving in.

	public float moveSpeed; //Multiplier to the magnitude at which ball form adds forces to itself.

	void Start ()
	{
		rb = gameObject.GetComponent<Rigidbody> ();
	}

	void FixedUpdate () 
	{
		moveHorizontal = Input.GetAxis ("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");

		movement = new Vector3 (moveHorizontal , 0.0f , moveVertical);

		rb.AddForce(movement * moveSpeed);
	}
}