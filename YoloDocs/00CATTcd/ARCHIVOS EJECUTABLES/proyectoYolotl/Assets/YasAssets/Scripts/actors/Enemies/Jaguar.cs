using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jaguar : MonoBehaviour {
	//For Patroling
	private float speedPatrol;
	[Tooltip("Left patrol limit")]
	public Transform leftBound;
	[Tooltip("Right patrol limit")]
	public Transform rightBound;
	private Rigidbody2D rb;
	private Animator anim;
	private SpriteRenderer sr;
	//private float maxDelay;
	private float minDelay;
	private bool canTurn;
	private float originalSpeed;

	private GameObject player;
	private BoxCollider2D box2D;
	private EnemyHealth enemy;

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
		anim = GetComponent <Animator> ();
		box2D = GetComponent<BoxCollider2D> ();
		enemy = GetComponent<EnemyHealth> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		anim.SetInteger ("state", 1);
		speedPatrol = 4f;
		//	maxDelay = 4f;
		minDelay = 1f;
		canTurn = true;
		SetStartDirection ();
		//		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update () {
		if ((!enemy.GetIsAlive ()) && (!(player.GetComponent <PlayerManager> ()).GetIsAlive ())) {
			sr.enabled = true;
			box2D.enabled = true;
			enemy.HanddleDead ();
			//StopMoving ();
		} else if (!enemy.GetIsAlive ()) {
			sr.enabled = false;
			box2D.enabled = false;
			//StopMoving ();
		} else if(CanPatrol()){
			MovePatrol ();
			FlipOnEdges ();
		}
	}


	//Patroling methods
	public void FlipOnEdges(){
		// for Down vertical
		if ((sr.flipX) && (transform.position.x >= rightBound.position.x)) {
			//sr.flipX = true;
			//speedPatrol = -speedPatrol;
			if (canTurn) {
				canTurn = false;
				originalSpeed = speedPatrol;
				speedPatrol = 0;
				StartCoroutine ("TurnLeft", originalSpeed);
			}
			// for up vertical
		}else if((!sr.flipX)&&(transform.position.x <= leftBound.position.x)){
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
		anim.SetInteger ("state", 0);
		//Debug.Log (anim.GetInteger ("state"));
		yield return new WaitForSeconds (minDelay);
		anim.SetInteger ("state", 1);
		sr.flipX = false;
		speedPatrol = -originalSpeed;
		canTurn = true;
	}

	IEnumerator TurnRight(float originalSpeed){
		anim.SetInteger ("state", 0);
		//Debug.Log (anim.GetInteger ("state"));
		yield return new WaitForSeconds (minDelay);
		anim.SetInteger ("state", 1);
		sr.flipX = true;
		speedPatrol = -originalSpeed;
		canTurn = true;
	}

	void SetStartDirection(){
		if (speedPatrol > 0) {
			sr.flipX = true;
		}else if (speedPatrol < 0) {
			sr.flipX = false;
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

	public bool CanPatrol(){
		float dist = Vector3.Distance (player.transform.position, transform.position);
		if (dist <= distance) {
			anim.SetInteger ("state", 1);
			return true;
		} else {
			anim.SetInteger ("state", 0);
			StopMoving ();
			return false;
		}
	}
		

	void OnDrawGizmos(){
		Gizmos.DrawLine (leftBound.position, rightBound.position);
	}
}
