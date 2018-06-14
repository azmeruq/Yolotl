using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the patroling behavior of the Amadillo enemy.
/// This enemy describes a horizontal patrol movement, it goes from left to right
/// then it waits a few seconds and procced to move from right to left and waits.
/// This class also implements a raycasting method tha allows to the enemy only
/// moves when the player is near.
/// </summary>

public class Armadillo : MonoBehaviour {
	//For Patroling
	private float speedPatrol;
	[Tooltip("Left patrol limit")]
	public Transform leftBound;
	[Tooltip("Right patrol limit")]
	public Transform rightBound;
	private Rigidbody2D rb;
	private EnemyHealth enemy;
	private CapsuleCollider2D cap2D;
	private SpriteRenderer sr;
	//private float maxDelay;
	private float minDelay;
	private bool canTurn;
	private float originalSpeed;
	GameObject player;
	public float distance;
	//For RayCasting
/*	private bool spoted;
	Vector3 initialPosition;
	[Tooltip("float value. This value represnts the position where the bullet will be created when the enemy shoots")]
	public float visionRadius;
	private GameObject player;
*/
	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody2D> ();
		sr = GetComponent <SpriteRenderer> ();
		enemy = GetComponent<EnemyHealth> ();
		player = GameObject.FindGameObjectWithTag("Player");
		cap2D = GetComponent<CapsuleCollider2D> ();
		speedPatrol = 2f;
	//	maxDelay = 4f;
		minDelay = 2f;
		canTurn = true;
		SetStartDirection ();
//		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update () {
		if ((!enemy.GetIsAlive ()) && (!(player.GetComponent <PlayerManager> ()).GetIsAlive ())) {
			sr.enabled = true;
			cap2D.enabled = true;
			enemy.HanddleDead ();

		} else if (!enemy.GetIsAlive ()) {
			sr.enabled = false;
			cap2D.enabled = false;
			StopMoving ();
		} else if(CanPatrol()){
			MovePatrol ();
			FlipOnEdges ();
		}
	}


	//Patroling methods
	public void FlipOnEdges(){
		// for Down vertical
		if ((!sr.flipX) && (transform.position.x >= rightBound.position.x)) {
			//sr.flipX = true;
			//speedPatrol = -speedPatrol;
			if (canTurn) {
				canTurn = false;
				originalSpeed = speedPatrol;
				speedPatrol = 0;
				StartCoroutine ("TurnLeft", originalSpeed);
			}
		// for up vertical
		}else if((sr.flipX)&&(transform.position.x <= leftBound.position.x)){
			//sr.flipX = false;
			//speedPatrol = -speedPatrol;
			if (canTurn) {
				canTurn = false;
				originalSpeed = speedPatrol;
				speedPatrol = 0;
				StartCoroutine ("TurnRight", originalSpeed);
			}
		}

	}

	IEnumerator TurnLeft(float originalSpeed){
		yield return new WaitForSeconds (minDelay);
		sr.flipX = true;
		speedPatrol = -originalSpeed;
		canTurn = true;
	}

	IEnumerator TurnRight(float originalSpeed){
		yield return new WaitForSeconds (minDelay);
		sr.flipX = false;
		speedPatrol = -originalSpeed;
		canTurn = true;
	}

	void SetStartDirection(){
		if (speedPatrol > 0) {
			sr.flipX = false;
		}else if (speedPatrol < 0) {
			sr.flipX = true;
		}
	}

	public void MovePatrol(){
		Vector2 temp = rb.velocity;
		temp.x = speedPatrol;
		rb.velocity = temp;
	}

	public void StopMoving(){
		rb.velocity = new Vector2(0f, 0f);
	}
		

	void OnDrawGizmos(){
		Gizmos.DrawLine (leftBound.position, rightBound.position);
	}

	public bool CanPatrol(){
		float dist = Vector3.Distance (player.transform.position, transform.position);
		if (dist <= distance)
			return true;
		else
			return false;
	}

	/*public void Raycasting(){
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

	}*/


}
