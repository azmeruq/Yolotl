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
	private PlayerManager player;
	private BoxCollider2D box2D;
	/* 
	 * Layer where it will compare if the box is overlaped with the
	 * ground or not
	*/
	//private LayerMask whatIsGround;

	/*
	 * This method draws a box in order to guide us about it size
	 * otherwise we will not be able to see what is overlaping
	 * and what is not.
	*/

	void Start(){
		player = FindObjectOfType<PlayerManager> ();
		box2D = GetComponent <BoxCollider2D> ();
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

	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Platform")) {
			player.transform.parent = null;
		}
	}

	public void FitBoxCollider(float offsetx, float offsety, float sizex, float sizey){
		Vector2 box2DOffSet = new Vector2();
		Vector2 box2DSize = new Vector2();

		box2DOffSet.x = offsetx;//2.811507f
		box2DOffSet.y = offsety; // 0.1881718f
		box2DSize.x = sizex; // 3.880423f
		box2DSize.y = sizey; //1.821438f
		box2D.offset = box2DOffSet;
		box2D.size = box2DSize;
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
