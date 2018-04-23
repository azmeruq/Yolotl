using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XolotlColibri : MonoBehaviour {
	private bool playerFirstJump;
	Vector3 initialPosition;
	public float speed;
	private Vector3 nextPos;
	public Transform[] positions;
	private int controlNumber;
	public PlayerManager player;
	// Use this for initialization
	void Start () {
		//initialPosition = transform.position;
		nextPos = positions[1].position;
		controlNumber = 0;
		playerFirstJump = false;
	}

	// Update is called once per frame
	void Update () {
		if (playerFirstJump)
			Move ();
		if (!player.GetIsAlive ()) {
			reStarPositions ();
		}
	}

	public void Move(){
		
		if(transform.position == nextPos){
			//Debug.Log (controlNumber);
			if (controlNumber == positions.Length-1) {
				
			} else {
				controlNumber++;	
				nextPos = positions [controlNumber].position;
			}
		}
		transform.position = Vector3.MoveTowards(transform.position, nextPos, speed*Time.deltaTime);
	}

	public void reStarPositions (){
		controlNumber = 1;
		transform.position = positions[0].position;
		nextPos = positions [controlNumber].position;
		playerFirstJump = false;
	}

	public void SetPlayerFirtsJump(bool value){
		playerFirstJump = value;
	}

	public int GetControlNumber(){
		return controlNumber;
	}

	public int GetArraySize(){
		return positions.Length;
	}

	public bool isOnLastPosition(){
		if(transform.position == positions[positions.Length-1].position)
			return true;
		else
			return false;
	}
	void OnDrawGizmos ()
	{
		int i;
		//Gizmos.DrawLine (positions [0].position, initialPosition);
		for(i=0; i<positions.Length-1; i++)
			Gizmos.DrawLine (positions[i].position, positions[i+1].position);
	}

}
