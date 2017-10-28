using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class allows us to verify is the player is grounded or not
/// without using a OnCollision fuction
/// 
/// </summary>

public class Feet : MonoBehaviour {
	// Box Size than it will check if the palyer is grounded or nor
	/*private float feetBoxWidth = 0.9f;
	private float feetBoxHeight = 0.02f;
	// Position where the box is
	private Transform feetPosition;*/
	private Player player;
	/* 
	 * Layer where it will compare if the box is overlaped with the
	 * ground or not
	*/
	private LayerMask whatIsGround;

	/*
	 * This method draws a box in order to guide us about it size
	 * otherwise we will not be able to see what is overlaping
	 * and what is not.
	*/

	void Start(){
		player = FindObjectOfType<Player> ();

		//feetPosition = GetComponent<Transform> ();
	}

	/*public void OnDrawGizmos(){
		feetPosition = GetComponent<Transform> ();
		Gizmos.DrawWireCube (feetPosition.position, new Vector3(feetBoxWidth, feetBoxHeight, 0f));
	}*/		

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Platform")) {
			player.SetIsJumping (false);
			player.transform.parent = other.gameObject.transform;
		}

		if (other.gameObject.CompareTag ("Ground")) {
			player.SetIsJumping (false);
			//player.SetIsGrounded (true);
			//Debug.Log(player.GetIsJumping());
		}

		if (other.gameObject.CompareTag ("HighGround")) {
			player.SetIsJumping (false);;
		}

	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Platform")) {
			player.transform.parent = null;
		}
	}

	/*
	 * Checks if the box is overlaping with what is on the laye Ground
	*/
	/*public void IsOverlaping(){
		bool isOverlapingAux;
		//feetPosition = GetComponent<Transform> ();

		isOverlapingAux = OverLapingMask("Ground");
		player.SetIsGrounded (isOverlapingAux);
		if (isOverlapingAux) {
			player.SetIsJumping (false);
			//player.SetAnimationState (0);
		}
	}
		

	public bool OverLapingMask(string Mask){
		whatIsGround = LayerMask.GetMask (Mask);
		return  Physics2D.OverlapBox (new Vector2(feetPosition.position.x, feetPosition.position.y), new Vector2(feetBoxWidth, feetBoxHeight), 360.0f, whatIsGround);
	}*/


}
