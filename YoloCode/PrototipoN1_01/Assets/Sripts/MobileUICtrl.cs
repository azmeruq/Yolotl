using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileUICtrl : MonoBehaviour {
	public GameObject player;
	PlayerManager playerCtrl;
	//playerManager  
	// Use this for initialization
	void Start () {
		playerCtrl = player.GetComponent<PlayerManager> ();

	}
	
	public void MobileMoveLeft(){
		playerCtrl.  WalkLeft();
	}

	public void MobileMoveRight(){
		playerCtrl.WalkRight();
	}

	public void MobileStop(){
		playerCtrl.StopMoving ();
	}

	public void MobileJump(){
		playerCtrl.Jump ();
	}

	public void MobileShot(){
		playerCtrl.Fire();
	}
}
