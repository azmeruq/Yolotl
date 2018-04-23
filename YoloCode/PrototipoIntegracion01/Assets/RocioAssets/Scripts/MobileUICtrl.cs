using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Routes the mobile input to the correct methods in the player script
/// </summary>
public class MobileUICtrl : MonoBehaviour {
	//public GameObject player;
	 //Player playerCtrl;
	private bool leftPressed;
	private bool rightPressed;
	private bool upPressed;
	private bool shotPressed;
	//private bool block;
	// Use this for initialization

	/*
	 * Obtain the components and the baheviors of the class Player
	*/
	void Start () {
		//playerCtrl = player.GetComponent<Player> ();
		//block = true;
	}

	/*
	 * Functions than 
	*/

	public void mobilePressLeft(){
		leftPressed = true;
	}

	public void mobilePressRight(){
		rightPressed = true;
	}

	public void mobileUnpressLeft(){
		leftPressed = false;

	}

	public void mobileUnpressRight(){
		rightPressed = false;
	}

	public void mobilePressUp(){
		StartCoroutine (waitUp ());
	}

	IEnumerator waitUp(){

		upPressed = true;	
		//yield return new WaitForSeconds(0.001f);
		yield return new WaitForEndOfFrame();
		//yield return new WaitForSecondsRealtime(0.001f);
		upPressed = false;
	}
		
	public void mobilePressShot(){
		//playerCtrl.Fire ();
		StartCoroutine(waitShot());

	}

	IEnumerator waitShot(){
		shotPressed = true;	
		yield return new WaitForEndOfFrame();
		shotPressed = false;
	}


	public void mobileUnpressUp(){
		
		upPressed = false;
	}


	public void mobileUnpressShot(){
		shotPressed = false;
	}



	public bool getLeftPressed(){
		return leftPressed;
	}

	public bool getRightPressed(){
		return rightPressed;
	}
		
	public bool getUpPressed(){
		return upPressed;
	}

	public bool getShotPressed(){
		return shotPressed;
	}

}
