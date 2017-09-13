using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileUICtrl : MonoBehaviour {
	public GameObject player;
	PlayerManager playerCtrl;
	public bool press;

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
		MobileUp (true);
	}

	public void MobileShot(){
		playerCtrl.Fire();
	}

	public bool MobileUp(bool press){
		if (press == true) {
			Debug.Log ("presionaste UP");
		}
		if (press == false) {
			Debug.Log ("no presionas UP");
		}
		return press;
	}
		
}
