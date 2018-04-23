using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls all the Player actions like jump, run, fire
/// this class is related with feetCtrl and MobileUICtrl
/// </summary>

public class PlayerManager : MonoBehaviour {

	//******************************************************
	/* 
	 * Player attributes
	 * First original attributes from the Player class 
	*/
	private float horizontalSpeed;
	private float verticalSpeed;
	private float health, maxHealth;
	private float tonalliAmount, maxtonalli;
	private int damage;
	private int score;

	/*
	 * Theses attributes help to control what actions the player can do or
	 * 
	*/
	private bool isFacingRight;
	private bool canDoubleJump;
	private bool isJumping;
	private bool isTalking;
	private bool isAlive;
	private bool canMove;
	private bool canFire;

	/*
	 * Those attributes allows knowing which bottom is pressed
	*/
	private bool leftPressed;
	private bool rightPressed;
	private bool firePressed;
	private bool jumpPressed;

	/* 
	 * Second attributes from unity classes 
	*/
	private Animator anim;
	private Rigidbody2D rd;
	private SpriteRenderer sr; // para voltear la orientacion del sprite y que pueda ver a la izquierda o a la derecha
	private BoxCollider2D box2D;

	/*
	 * These attributes are used for the fire action
	 * the Transform position is where the bullet will be created
	 * while the GameObject is which object will be created
	*/
	public Transform tonalliPositionRight;
	public Transform tonalliPositionLeft;
	public GameObject tonalliRight;
	public GameObject tonalliLeft;

	/*
	 * This attribute is used for updating the health bar and tonalli bar
	 */
	public HealthBar healthBar;

	//******************************************************


	//******************************************************
	/*
	 * Method: Start
	 * In unity Start is the class starter, which means in this method
	 * some attributes are inicialized
	*/
	void Start () {
		anim = GetComponent<Animator> ();
		rd = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		box2D = GetComponent <BoxCollider2D> ();
		verticalSpeed = 6.5f;
		isAlive = true;
		isJumping = false;
		isFacingRight = true;
		score = 0;
		canMove = true;
		canFire = true;

		maxHealth = (GameDataCtrl.instance.GetGameData()).GetHealthAmount();
		Debug.Log ("Maxhealth Player" + maxHealth);
		if(maxHealth==0f){
			maxHealth = 50f;
		} 
		//Debug.Log ("Maxhealth " + maxHealth);
		//maxHealth = 50f;
		health = maxHealth;
		maxtonalli = (GameDataCtrl.instance.GetGameData()).GetTonalliAmount();
		//Debug.Log ("Maxtonalli " + maxtonalli);
		if(maxtonalli==0f){
			maxtonalli = 30f;
		} 
		//tonalliAmount = maxtonalli
		//maxtonalli = 30f;
		//Debug.Log ("Maxtonalli Player" + maxtonalli);
		tonalliAmount = maxtonalli;
		//horizontalSpeed = 5f;
	}
	//******************************************************


	//******************************************************
	/*
	 * Method: Update
	 * 
	*/
	void Update () {
		/*
			GetAxisRaw returns 1, 0 o -1 depending on the movement in an axis, in
			this case Horizontal axis. 
			So if the player is moving in the right, GetAxisRaw returns 1
			if the player is moving in the left, GetAxisRaw returns -1
			and if the player is not moving in, GetAxisRaw returns 0.

			5f is the true value of the velocity so if you want to make the player
			faster o slower change that value.
		*/ 
		if (canMove) {
			if(isAlive){
				horizontalSpeed = 6f * (Input.GetAxisRaw ("Horizontal"));
				if(horizontalSpeed != 0){
					moveHorizontal ();
				}else{
					stopMoving ();
				}

				if (Input.GetKeyDown(KeyCode.UpArrow)) {
					jump ();
				}


				if(Input.GetKeyDown (KeyCode.Space))
				{
					Fire ();
				}


				showFaling ();


			}
			//Update the GUI

			if(leftPressed){
				horizontalSpeed = -6F;
				moveHorizontal ();
			}

			if(rightPressed){
				horizontalSpeed = 6F;
				moveHorizontal ();
			}
		}
		//checkGrounded ();
	}	
	//******************************************************


	//******************************************************
	/*
	 * Method: stopMoving
	 * Stops the movement and avoid the on ice movement when the player is 
		stoping
	*/
	public void stopMoving(){
		rd.velocity = new Vector2(0f, rd.velocity.y);
		if (!isJumping) {
			anim.SetInteger ("state", 0);
		}
	}
	//******************************************************


	//******************************************************
	public void moveHorizontal(){
		//send the volocity to the player in order to move it.
		if(canMove){
			rd.velocity = new Vector2(horizontalSpeed, rd.velocity.y);

			//Change the orientation of the sprite 
			if(horizontalSpeed < 0){
				/*
				If the player is moving to the left the sprite is facing the lef
				otherwise is facing the right
			*/ 
				sr.flipX = false;
				isFacingRight = false;
			}else if (horizontalSpeed > 0){
				sr.flipX = true;
				isFacingRight = true;
			}

			/* 
		 * In case the player is not jumping the states machine
		 * will show the running state
		*/ 
			if (!isJumping) {
				anim.SetInteger ("state", 1);
			}
		}
	}
	//******************************************************


	//******************************************************
	void showFaling(){
		/*
		 * If the vertical velocity is negative the Player must be
		 * falling so the states machine will set the falling state
		*/
		if (rd.velocity.y < 0) {
			anim.SetInteger ("state", 3);
		}
	}
	//******************************************************


	//******************************************************
	public void jump(){
		if(!isJumping){
			isJumping = true;
			//rd.AddForce (new Vector2(0f, verticalSpeed));
			//rd.AddForce (Vector2.up * verticalSpeed, ForceMode2D.Impulse);
			rd.velocity  = new Vector2(0f, verticalSpeed);
			anim.SetInteger ("state", 2);
			canDoubleJump = true;
		}else if (canDoubleJump) {
			//rd.AddForce (new Vector2(0f, verticalSpeed));
			//rd.AddForce (Vector2.up * verticalSpeed, ForceMode2D.Impulse);
			rd.velocity  = new Vector2(0f, verticalSpeed);
			anim.SetInteger ("state", 2);
			canDoubleJump = false;
		}
	}
	//******************************************************


	//******************************************************
	public void Fire(){
		if(canFire){
			if (tonalliAmount > 0) {
				if (isFacingRight) {
					Instantiate (tonalliRight, tonalliPositionRight.position, Quaternion.identity);
				} else {
					Instantiate (tonalliLeft, tonalliPositionLeft.position, Quaternion.identity);
				}
				tonalliAmount = Mathf.Clamp (tonalliAmount-2f, 0f, maxtonalli);
				healthBar.UpDateTonalliBar (tonalliAmount/maxtonalli);
				//tonalliAmount = tonalliAmount - 2;
				//Debug.Log (tonalliAmount);
			}
		}
	}
	//******************************************************

	//******************************************************
	public void EnemyKnockBack(float enemyPos){
		isJumping = true;
		float side =  Mathf.Sign (enemyPos - transform.position.x);
		rd.AddForce (Vector2.up * verticalSpeed/3f, ForceMode2D.Impulse);
		rd.AddForce (Vector2.left * side * verticalSpeed/3f, ForceMode2D.Impulse);
		canMove = false;
		canFire = false;
		sr.color = Color.red;
		Invoke ("EnableMovement", 0.5f);
	}


	void EnableMovement(){
		canMove = true;
		canFire = true;
		isJumping = false;
		sr.color = Color.white;
	}

	//******************************************************
	public void UpDateScore(){
		//Debug.Log (score);
		score = score +1;
		//Debug.Log (score);
	}
	//******************************************************

	//******************************************************
	public void HandleDead(){
		GameOverCtrl.instance.setActive (false);
		transform.position = CheckPoint.GetActivePosition ();
		health = maxHealth;
		tonalliAmount = maxtonalli;
		isJumping = false;
		canMove = true;
		isAlive = true;
		sr.enabled = true;
		box2D.enabled = true;
		rd.bodyType = RigidbodyType2D.Dynamic;
		healthBar.UpDateHealthBar (1);
		healthBar.UpDateTonalliBar (1);
	}

	//******************************************************

	//******************************************************
	public void PausedForReviving(){
		//yield return new WaitForSeconds (1.5f);
		Invoke ("HandleDead", 1f);
	}

	//******************************************************


	//******************************************************
	void OnCollisionEnter2D(Collision2D other){
		
	}
	//******************************************************

	//******************************************************
	void OnTriggerEnter2D(Collider2D other){
		switch (other.gameObject.tag) {
		case "Collectable":{
			SFXCtrl.instance.ShowCoinSparkle (other.gameObject.transform.position);
			break;
		}
		case "CollectableKey":{
			SFXCtrl.instance.ShowCoinSparkle (other.gameObject.transform.position);
			UpDateScore ();
			HUBCtrl.instance.UpDateKeys (score);
			break;
		}
		case "CollectableDog":
			{
				SFXCtrl.instance.ShowCoinSparkle (other.gameObject.transform.position);
				UpDateScore ();
				HUBCtrl.instance.UpDateDogScore (score);
				break;
			}
	
		default:
			break;
		}
	}
	//******************************************************
	public void SetHealth(float value){
		health = Mathf.Clamp (health-value, 0f, maxHealth);
		//Debug.Log (health);
		healthBar.UpDateHealthBar(health/maxHealth);
		if (health == 0f) {
			
			isAlive = false;
			sr.enabled = false;
			rd.bodyType = RigidbodyType2D.Kinematic;
			box2D.enabled = false;
			stopMoving ();
			SFXCtrl.instance.ShowEnemyExplosion (transform.position);
			GameOverCtrl.instance.setActive (true);
		}
	}

	public void SetTonalli(float value){
		tonalliAmount = Mathf.Clamp (tonalliAmount + value, 0f, maxtonalli);
		//Debug.Log (health);
		healthBar.UpDateTonalliBar(tonalliAmount/maxtonalli);
	}

	public void SetIsJumping(bool aux){
		isJumping = aux;		
		//Debug.Log (isJumping);
	}

	public void SetIsAlive(bool value){
		isAlive = value;
	}
		
	public void SetAnimationState(int aux){
		anim.SetInteger ("state", aux);		
	}

	public bool GetIsFacingRight(){
		return isFacingRight;
	}

	public bool GetIsJumping(){
		return isJumping;
	}

	public float GetMaxHealth(){
		return maxHealth;
	}

	public int GetScore (){
		return score;
	}

	public bool GetIsAlive(){
		return isAlive;
	}

	//Methods for GUI
	public void MobileMoveLeft (){
		if(isAlive)
		leftPressed = true;
	}

	public void MobileMoveRight (){
		if(isAlive)
		rightPressed = true;
	}

	public void MobileMoveStop (){
		leftPressed = false;
		rightPressed = false;
		stopMoving ();
	}

	public void MobileMoveJump (){
		if(isAlive)
			jump ();
	}

	public void MobileFire(){
		//firePressed = true;
		if(isAlive)
			Fire ();
	}

}
