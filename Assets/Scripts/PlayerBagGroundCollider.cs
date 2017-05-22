using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBagGroundCollider : MonoBehaviour 
{
	PlayerBagMove bagMoveScript; //The instance of the PlayerBallMove script on the player.

	public GameObject playerBag; //The gameobject holding the PlayerBallMove script.

	// Use this for initialization
	void Start () 
	{
		bagMoveScript = playerBag.GetComponent <PlayerBagMove> ();
	}

	// Update is called once per frame
	void OnTriggerEnter ()
	{
		bagMoveScript.onGround = true;
	}
	void OnTriggerExit ()
	{
		bagMoveScript.onGround = false;
	}
}