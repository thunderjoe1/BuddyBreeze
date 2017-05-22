using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTranformationManager : MonoBehaviour 
{
	public GameObject playerBallPrefab;
	public GameObject playerBagPrefab;
	public GameObject player; //The player gameObject.

	enum playerStates {Ball, Bag};
	playerStates playerState = playerStates.Bag;
	Transform currentLocation; //The current location of the player.
	GameObject oldPlayer; //The previous GameObject before it is deleted.

	void Update () 
	{
		if (Input.GetButtonDown ("Transform") && playerState == playerStates.Bag)
		{
			currentLocation = player.transform.GetChild (0).transform;
			oldPlayer = player;
			player = Instantiate (playerBallPrefab,currentLocation.position,Quaternion.identity) as GameObject;
			Destroy (oldPlayer);
			playerState = playerStates.Ball;
		} else if (Input.GetButtonDown ("Transform") && playerState == playerStates.Ball)
		{
			currentLocation = player.transform.GetChild (0).transform;
			oldPlayer = player;
			player = Instantiate (playerBagPrefab,currentLocation.position,Quaternion.identity) as GameObject;
			Destroy (oldPlayer);
			playerState = playerStates.Bag;
		}
	}
}