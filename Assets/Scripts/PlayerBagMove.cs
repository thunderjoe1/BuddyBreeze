using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBagMove : MonoBehaviour 
{
	Rigidbody rb; //The player's rigidbody.
	float moveHorizontal;
	float moveVertical;
	Vector3 movement; //The directions the object is moving in.

	public float moveSpeed; //Multiplier to the magnitude at which bag form adds forces to itself.
	public GameObject cameraY; //The Object which determines the camera's Y axis rotation.
	public bool onGround; //This variable is true if the player can jump(is touching the ground).
	public float maxVelocity; //The max speed the player ball can move at.

	void Start ()
	{
		rb = gameObject.GetComponent<Rigidbody> ();
		onGround = true;
	}

	void Update()
	{
	}

	void FixedUpdate () 
	{
		moveHorizontal = Input.GetAxis ("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");

		//		movement = new Vector3 (moveHorizontal, 0.0f , moveVertical);

		//		rb.AddForce(movement * moveSpeed);

		rb.AddForce (cameraY.transform.forward * moveVertical * moveSpeed);
		rb.AddForce (cameraY.transform.right * moveHorizontal * moveSpeed);

		if((rb.velocity.x >= maxVelocity)||(rb.velocity.x <= -1 * maxVelocity))
		{
			rb.AddForce (new Vector3(maxVelocity-rb.velocity.x,0f,0f));
		}
		if((rb.velocity.z >= maxVelocity)||(rb.velocity.z <= -1 * maxVelocity))
		{
			rb.AddForce (new Vector3(0f,0f,maxVelocity-rb.velocity.z));
		}
	}

	void OnTriggerStay (Collider col)
	{
		print ("Wind!");
		if (col.GetComponent <EnvironmentWindScript> () && Input.GetButton ("Jump")) 
		{
			rb.AddForce (col.GetComponent <EnvironmentWindScript>().windForce * col.transform.up);
			rb.AddForce (new Vector3(0f,30f,0f));
		}
	}
}