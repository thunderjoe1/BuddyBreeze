using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallGroundCollider : MonoBehaviour 
{
	PlayerBallMove ballMoveScript; //The instance of the PlayerBallMove script on the player.

	public GameObject playerBall; //The gameobject holding the PlayerBallMove script.

	// Use this for initialization
	void Start () 
	{
		ballMoveScript = playerBall.GetComponent <PlayerBallMove> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter ()
	{
		ballMoveScript.onGround = true;
	}
	void OnTriggerExit ()
	{
		ballMoveScript.onGround = false;
	}
}