using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
	public float speedX;
	public float jumpSpeedY;
	public float delayBeforeDoubleJump;
	public GameObject leftBullet, rightBillet;
	public bool SFXOn;

	bool facingRight, Jumping, isGrounded, canDoubleJump;
	float speed;
	Transform firePos;

	Animator anim;
	Rigidbody2D rd;

	//UI Mobile
	bool leftPressed, rightPressed;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rd = GetComponent<Rigidbody2D> ();
		facingRight = true;

		firePos = transform.Find ("firePot");
	}
	
	// Update is called once per frame
	void Update () {
		//Handling the running - idle state change
		/*
		 * If the user is pressing the keycode R the character will be
		 * running (GetKeyDown) but if the user stop pressing the keycode
		 * (GetKeyUp) the character will come back to the default animation.
		*/
		/*if (Input.GetKeyDown (KeyCode.R)) { 
			anim.SetInteger ("State", 1);
		}
		if (Input.GetKeyUp (KeyCode.R)) {
			anim.SetInteger ("State", 0);
		}
		//Handling the walking - idle state change
		if (Input.GetKeyDown (KeyCode.W)) {
			anim.SetInteger ("State", 2);
		}
		if (Input.GetKeyUp (KeyCode.W)) {
			anim.SetInteger ("State", 0);
		}

		if (Input.GetKeyDown (KeyCode.J)) {
			anim.SetInteger ("State", 3);
		}
		if (Input.GetKeyUp (KeyCode.J)) {
			anim.SetInteger ("State", 0);
		}*/
		
		MovePlayer (speed);
		HandleJumpAndFall ();
		Flip ();

		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			speed = -speedX;
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow)) {
			speed = 0;
		}
		
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			speed = speedX;
		}
		if (Input.GetKeyUp(KeyCode.RightArrow)) {
			speed = 0;
		}
		
		//Jump
		if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) {
			Jump ();
		}
		
		//Double jump
		if (Input.GetKeyDown(KeyCode.UpArrow) && canDoubleJump) {
			Jump ();
		}
		
		//Shut
		if (Input.GetKeyDown(KeyCode.Space)){
			Fire ();	
		}
		

	}

	void MovePlayer (float playerSpeed){
		// code for player movement
		
		if(playerSpeed<0 && !Jumping || playerSpeed>0 && !Jumping){
			anim.SetInteger ("State", 1);
		}
		if (playerSpeed == 0 && !Jumping) {
			anim.SetInteger ("State", 0);
		}

		rd.velocity = new Vector3(speed, rd.velocity.y, 0);
		
	}
	
	void HandleJumpAndFall(){
		if (Jumping) {
			if(rd.velocity.y > 0){
				anim.SetInteger ("State", 3);
			}
			else{
				anim.SetInteger ("State", 2);

			}
		}
	}

	void Flip(){
	if(speed>0 && !facingRight || speed<0 && facingRight){
			facingRight = !facingRight;
			Vector3 temp = transform.localScale;
			temp.x *= -1;
			transform.localScale = temp;
	}

	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "GROUND" || other.gameObject.tag == "BOX") {
				isGrounded = true;
				canDoubleJump = false;
				Jumping = false;
				anim.SetInteger ("State", 0);
			}
	if (other.gameObject.CompareTag ("Enemy")||other.gameObject.CompareTag ("Rock")) {
			GameCtrl.instance.PlayerDiedAnimation (gameObject);		
		}
	}

	public void WalkLeft(){
		speed = -speedX;
	}
	
	public void WalkRight(){
		speed = speedX;
	}
	public void StopMoving(){
		speed = 0;
	}

	public void Jump(){
		// single jump
		if (isGrounded) {
			Jumping = true;
			isGrounded = false;
			rd.AddForce(new Vector2(rd.velocity.x, jumpSpeedY));
			anim.SetInteger ("State", 3);
			Invoke ("EnableDoubleJump", delayBeforeDoubleJump);
		}
		
	// double jump
		if (canDoubleJump) {
			canDoubleJump = false;
			rd.AddForce(new Vector2(rd.velocity.x, jumpSpeedY));
			anim.SetInteger ("State", 3);
		}

	}

	void EnableDoubleJump(){
		canDoubleJump = true;
	}
	
	public void Fire(){
		if(facingRight)
			Instantiate (rightBillet, firePos.position, Quaternion.identity);
		if(!facingRight)
			Instantiate (leftBullet, firePos.position, Quaternion.identity);
	}

	void OnTriggerEnter2D(Collider2D other){
		switch (other.gameObject.tag) {
		case "Coin":
			if(SFXOn)
				SFXCtrl.instance.ShowCoinSparkle (other.gameObject.transform.position);
			break;
		case "Dog":
			if (SFXOn) {
				SFXCtrl.instance.ShowCoinSparkle (other.gameObject.transform.position);
				GameCtrl.instance.UpdateXoloCount ();
			}
				
			break;
		default:
			break;
		}
	}
	/*
	// for Mobile UI
	public void MobileMoveLeft(){
		leftPressed = true;
	}

	public void MobileMoveRight(){
		rightPressed = true;
	}

	public void MobileStop(){
		leftPressed = false;
		rightPressed = false;
		StopMoving ();
	}*/
}
