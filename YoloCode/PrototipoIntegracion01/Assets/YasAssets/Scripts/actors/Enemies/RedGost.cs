using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the Red Gost enemy behavior. This enemy 
/// makes a vetical patrol and shoots every two seconds. The enemy 
/// behavior is only actictived when the player is near to its vision
/// radius, whitch means a raycasting is implemented too.
/// </summary>

public class RedGost : MonoBehaviour {
	//public int healtAmount;
	//For the rayCast
	[Tooltip("Transfomr value. Position where the bullet will be created when the enemy shoots")]
	public Transform sightStart;
	private bool spoted;
	Vector3 initialPosition;
	[Tooltip("float value. This value represnts the position where the bullet will be created when the enemy shoots")]
	public float visionRadius;



	//For the patroling
	private bool isUp;
	private float speedPatrol;
	private Rigidbody2D rb;
	[Tooltip("Up patrol limit")]
	public Transform upBound;
	[Tooltip("Down patrol limit")]
	public Transform downBound;

	//For Shooot
	private float timeDelay;
	private bool canShoot;
	private bool isFacingRight;
	[Tooltip("GameObject for the right bullet")]
	public GameObject bulletRight;
	[Tooltip("GameObject for the left bullet")]
	public GameObject bulletLeft;
	private SpriteRenderer sr;
	private GameObject player;

	private BoxCollider2D box2D;
	private EnemyHealth enemy;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		box2D = GetComponent<BoxCollider2D> ();
		enemy = GetComponent<EnemyHealth> ();
		speedPatrol = 5.0f;
		spoted = false;
		SetStartDirection ();
		timeDelay = 2;
		canShoot = true;
		initialPosition = transform.position;
		player = GameObject.FindGameObjectWithTag("Player");
	}

	
	// Update is called once per frame
	void Update () {
		if((!enemy.GetIsAlive())&&(!(player.GetComponent <PlayerManager>()).GetIsAlive())){
			sr.enabled = true;
			box2D.enabled = true;
			enemy.HanddleDead ();
			StopMoving ();
		}else if (!enemy.GetIsAlive ()) {
			sr.enabled = false;
			box2D.enabled = false;
			StopMoving ();
		}else{
			Raycasting ();
			if (spoted) {
				MovePatrol ();
				FlipOnEdges ();
				SetFlipX ();
				Fire ();
			} else {
				StopMoving ();
			}
		}


	}

	public void Raycasting(){
		Vector3 target = initialPosition;

		// Pero si la distancia hasta el jugador es menor que el radio de visión el objetivo será él
		float dist = Vector3.Distance(player.transform.position, transform.position);
		if (dist < visionRadius) { 
			target = player.transform.position;
			spoted = true;
		} else {
			spoted = false;
		}
		// Y podemos debugearlo con una línea
		Debug.DrawLine(transform.position, target, Color.green);

	}

	// Podemos dibujar el radio de visión sobre la escena dibujando una esfera
	void OnDrawGizmos() {

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, visionRadius);

	}
		

	public void FlipOnEdges(){
		// for Down vertical
		if ((isUp) && (transform.position.x == upBound.position.x && transform.position.y >= upBound.position.y)) {
			isUp = false;
			speedPatrol = -speedPatrol;
			// for up vertical
		}else if((!isUp)&&(transform.position.x == downBound.position.x && transform.position.y <= downBound.position.y)){
			isUp = true;
			speedPatrol = -speedPatrol;
		}

	}

	void SetStartDirection(){
		if (speedPatrol > 0) {
			isUp = true;
		}else if (speedPatrol < 0) {
			isUp = false;
		}
	}


	public void MovePatrol(){
		Vector2 temp = rb.velocity;
		temp.y = speedPatrol;
		rb.velocity = temp;
	}

	public void StopMoving(){
		rb.velocity = new Vector2(0f, 0f);
	}

	public void Fire(){
		if(canShoot){
			canShoot = false;
			Invoke ("ReFire", timeDelay);
			if (sr.flipX) {
				Instantiate (bulletRight, sightStart.position, Quaternion.identity);
			} else {
				Instantiate (bulletLeft, sightStart.position, Quaternion.identity);
			}
		}
	}

	public void ReFire(){
		canShoot = true;
	}

	public bool GetIsFacingRight(){
		return GetComponent<SpriteRenderer> ().flipX;
	}

	public void SetFlipX(){
		if (Mathf.Sign (transform.position.x - player.transform.position.x) == 1)
			sr.flipX = false;
		else if (Mathf.Sign (transform.position.x - player.transform.position.x) == -1)
			sr.flipX = true;
		
	}


}
