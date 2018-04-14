using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls all the Player actions like jump, run, shoot
/// </summary>

public class Player : MonoBehaviour {


	// Player attributes
	// First original attributes from the Player class 
	private float horizontalSpeed;
	private float verticalSpeed;

	//private float externalSpeed;

	private int health;
	private int damage;
	private bool isFacingRight;
	//private bool isGrounded;
	private bool canDoubleJump;
	private bool isJumping;
	private bool isTalking;
	//private bool leftPressed;
	//private bool rightPressed;

	//Second attributes from unity classes
	private Animator anim;
	private Rigidbody2D rd;
	private SpriteRenderer sr; // para voltear la orientacion del sprite y que pueda ver a la izquierda o a la derecha

	private MobileUICtrl mob;

	// Classes
	//private Feet feet;

	// Para el disparo
	//private GameObject tonalliPosition;
	//private GameObject tonalli;
	private Transform tonalliPosition;
	public GameObject tonalli;

	private int mana;
	private loaderScene loaderscene;

	//AQUIIIIIIIIIIIIIIIIIII
	//se usarán para detectar si se esta en el suelo y asi evitar el salto infinito
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	//para doble salto
	private bool doubleJumped;

	//Comunicación con el DIALOGUEMANAGER
	private DialogueManager dMan;

	//private NPC npc;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogueManager>();
		anim = GetComponent<Animator> ();
		rd = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		tonalliPosition = ((GameObject.FindWithTag("Player")).transform.Find ("TonalliReference").gameObject).GetComponent <Transform>();
		mob = FindObjectOfType<MobileUICtrl> ();
		//tonalliPosition = GameObject.FindGameObjectWithTag ("ReferenciaTonalli");
		//feet = FindObjectOfType<Feet> ();
		//tonalli = GameObject.FindGameObjectWithTag ("Tonalli");
		//verticalSpeed = 600f;
		//horizontalSpeed = 5f;
		isTalking  = false;
		//setIsTalking(false);
		isJumping = false;
		isFacingRight = true;
		//horizontalSpeed = 5f;
		setHorizontalSpeed(5f);
		setVerticalSpeed (15f);
		//setExternalSpeed (0f);
		setHealth(15);
		setMana (50);
		loaderscene = gameObject.AddComponent<loaderScene>();
		// Cambiar para cinematica1



	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {
		if (grounded) {
			doubleJumped = false;
		}

		//anim.SetBool ("state", 1);

		if ( Input.GetKeyDown(KeyCode.UpArrow) && grounded) {
			Jump ();
		}
		if (Input.GetKeyDown (KeyCode.UpArrow) && !doubleJumped && !grounded) {
			Jump ();
			doubleJumped = true;
		}



		if (mob.getUpPressed () == true && grounded) {
			Jump ();
		}
		if (mob.getUpPressed () == true && !doubleJumped && !grounded) {
			Jump ();
			doubleJumped = true;
		}

		moveHorizontal(0f);

		if (mob.getRightPressed () == true || Input.GetKeyDown(KeyCode.RightArrow)) {
			//horizontalSpeed = 5f;
			moveHorizontal (getHorizontalSpeed());
		} 

		if (mob.getLeftPressed () == true  || Input.GetKeyDown(KeyCode.LeftArrow)) {
			//horizontalSpeed = -5f;
			moveHorizontal (-getHorizontalSpeed());
		}
		//anim.SetFloat("Speed", Math.Abs..........) linea 107
		//----------------

		if(Input.GetKeyDown (KeyCode.Space) && (dMan.getPlayerIsCloseToTalk () == false) && (getMana() != 0) )
		{
			Fire ();
		}

		if (mob.getShotPressed () == true && (dMan.getPlayerIsCloseToTalk () == false) && (getMana() != 0) ) {
			Fire ();
		}


		if(Input.GetKeyDown (KeyCode.Space) && (isTalking == false))
		{
			//Fire ();
		}

		if (mob.getShotPressed () == true && (isTalking == false)) {
			//Fire ();
		}
		//*******************************************************************



		showFaling ();

		if (mob.getLeftPressed () == false && mob.getRightPressed() == false) {
			stopMoving ();
		} 

		//checkGrounded ();

		////////////////////////////////////

		dead ();
	}	

	public void setIsTalking(bool what)
	{
		isTalking = what;
	}

	public bool getIsTalking()
	{
		return isTalking;
	}

	public void setHorizontalSpeed(float speed)
	{
		horizontalSpeed = speed;
	}

	public float getHorizontalSpeed()
	{
		return horizontalSpeed;
	}

	/*
	public void setExternalSpeed(float speed)
	{
		externalSpeed = speed;
	}

	public float getExternalSpeed()
	{
		return externalSpeed;
	}
	*/

	public void setVerticalSpeed(float speed)
	{
		verticalSpeed = speed;
	}

	public float getVerticalSpeed()
	{
		return verticalSpeed;
	}

	public void stopMoving(){
		rd.velocity = new Vector2(0f, rd.velocity.y);
		if (!isJumping) {
			anim.SetInteger ("state", 0);
		}
	}
		
	public void moveHorizontal(float speed){
		//send the volocity to the player in order to move it.
		rd.velocity = new Vector2(speed, rd.velocity.y);

		//Change the orientation of the sprite 
		if (speed < 0) {
			sr.flipX = false;
			isFacingRight = false;
		} else if (speed > 0) {
			sr.flipX = true;
			isFacingRight = true;
		}
			
		if (!isJumping) {
			anim.SetInteger ("state", 1);
		}
	}

	void showFaling(){
		if (rd.velocity.y < 0) {
			anim.SetInteger ("state", 3);
		}
	}

	public void jump(){
		//Debug.Log (isGrounded);
		//if(isGrounded)
		if(!isJumping){
			isJumping = true;
			rd.AddForce (new Vector2(0f, getVerticalSpeed() ) );
			anim.SetInteger ("state", 2);
			canDoubleJump = true;
			//isGrounded = false;
		}

		else if (canDoubleJump) {//canDoubleJump && !isGrounded
			rd.AddForce (new Vector2(0f, getVerticalSpeed() ) );
			anim.SetInteger ("state", 2);
			canDoubleJump = false;
		}
	}
		

	public void Fire(){
		Instantiate (tonalli, tonalliPosition.position, Quaternion.identity);
		setMana (getMana () - 1);
	}
		

	public void SetIsJumping(bool aux){
		isJumping = aux;		
		//Debug.Log (isJumping);
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

	public void Jump()
	{
		anim.SetInteger ("state", 2);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, verticalSpeed);
	}

	public void setHealth(int what)
	{
		health = what;
	}

	public int getHealth()
	{
		return health;
	}

	public void setMana(int what)
	{
		mana = what;
	}

	public int getMana()
	{
		return mana;
	}
	private void dead(){
		if (getHealth () == 0) {
			
			//Destroy (this.gameObject);
			loaderscene.SetSceneName ("0000");
			loaderscene.changeScene ();
		}
	}

}
