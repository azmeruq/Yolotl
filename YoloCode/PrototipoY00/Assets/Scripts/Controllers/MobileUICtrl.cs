using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Routes the mobile input to the correct methods in the player script
/// </summary>
public class MobileUICtrl : MonoBehaviour {
	public GameObject player;
	PlayerManager playerCtrl;
	// Use this for initialization

	/*
	 * Obtain the components and the baheviors of the class Player
	*/
	void Start () {
		playerCtrl = player.GetComponent<PlayerManager> ();
	}

	/*
	 * Functions than 
	*/
	public void MobileMoveLeft(){
		playerCtrl.MobileMoveLeft ();
	} 

	public void MobileMoveRight(){
		playerCtrl.MobileMoveRight ();
	}

	public void MobileMoveStop(){
		playerCtrl.MobileMoveStop ();
	}

	public void MobileMoveJump(){
		playerCtrl.MobileMoveJump ();
	}

	public void MobileFire(){
		playerCtrl.MobileFire ();
	}
}
