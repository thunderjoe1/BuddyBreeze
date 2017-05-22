using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBagMove : MonoBehaviour 
{
	Rigidbody rb; //The player's rigidbody.
	float moveHorizontal;
	float moveVertical;
	Vector3 movement; //The directions the object is moving in.
	bool jumpOver; //This variable is false when the script should stop reading the player's jump input(holding the button makes the player jump higher).
	float jumpTime = 0f; //The time, in seconds, the player has been jumping(applying upward force to itself).

	public float moveSpeed; //Multiplier to the magnitude at which bag form adds forces to itself.
	public GameObject camera; //The Object which determines the camera's Y axis rotation.
	public bool onGround; //This variable is true if the player can jump(is touching the ground).
	public float maxVelocity; //The max speed the player ball can move at.
	public float jumpStartForce; //The force applied to the player when it holds the jump button.
	public float jumpForce; //The force applied to the player as it holds the jump button.
	public float jumpTimeMax; //The time, in seconds, the player can hold to jump button to increase their jump height.
	public GameObject cameraY;

	void Start ()
	{
		rb = gameObject.GetComponent<Rigidbody> ();
		onGround = true;
		jumpOver = false;
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

		rb.AddForce (camera.transform.forward * moveVertical * moveSpeed);
		rb.AddForce (camera.transform.right * moveHorizontal * moveSpeed);

		if((rb.velocity.x >= maxVelocity)||(rb.velocity.x <= -1 * maxVelocity))
		{
			rb.AddForce (new Vector3(maxVelocity-rb.velocity.x,0f,0f));
		}
		if((rb.velocity.z >= maxVelocity)||(rb.velocity.z <= -1 * maxVelocity))
		{
			rb.AddForce (new Vector3(0f,0f,maxVelocity-rb.velocity.z));
		}

		if(Input.GetButtonDown ("Jump") && onGround == true)
		{
			rb.AddForce (0f,jumpStartForce,0f);
			jumpTime = 0f;
			jumpOver = false;
		} else if (Input.GetButton ("Jump") && jumpOver == false)
		{
			rb.AddForce (0f,jumpForce * Time.deltaTime,0f);
		}
			
	}

	void OnTriggerStay (Collider col)
	{
		if (col.GetComponent <EnvironmentWindScript> () && Input.GetButton ("Jump")) 
		{
			rb.AddForce (col.GetComponent <EnvironmentWindScript>().windForce * col.transform.up);
			rb.AddForce (new Vector3(0f,30f,0f));
		}else if(col.GetComponent <EnvironmentWindScript> ())
		{
			rb.AddForce (col.GetComponent <EnvironmentWindScript>().windForce * 0.05f * col.transform.up);
		}
	}
}