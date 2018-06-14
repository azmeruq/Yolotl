using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Purple gost Controller
/// </summary>
/// 
public class PurpleGost : MonoBehaviour
{
	//Raycast
	private bool spoted;
	private bool canAttack;
	private bool isUp;
	private bool isLeft;
	Vector3 initialPosition;
	[Tooltip ("float value. Radius of the active enemy's area where it patrols")]
	public float visionRadius;
	[Tooltip ("float value. Radius of the active enemy's area where it attacks")]
	public float attackRadius;
	//private float speedAttackY;


	//Patrol
	//private Rigidbody2D rb;
	private SpriteRenderer sr;
	private BoxCollider2D box2D;
	private EnemyHealth enemy;
	public Transform upBound, downBound, attackBoundleft, attackBoundRight;
	private GameObject player;
	Vector3 nextPos;
	private float speedPatrol;
	private float speedAttack;
	//private float speedAttackX;
	//private float speedAttackY;


	// Use this for initialization
	void Start ()
	{
		//rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		box2D = GetComponent<BoxCollider2D> ();
		enemy = GetComponent<EnemyHealth> ();
		speedPatrol = 5.0f;
		speedAttack = 18.0f;
		//speedAttackX = 18.0f;
		//speedAttackY = -18.0f;
		canAttack = false;
		spoted = false;
		//SetStartDirection ();
		initialPosition = transform.position;
		nextPos = upBound.position;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update ()
	{if ((!enemy.GetIsAlive ()) && (!(player.GetComponent <PlayerManager> ()).GetIsAlive ())) {
			sr.enabled = true;
			box2D.enabled = true;
			enemy.HanddleDead ();
			//StopMoving ();
		} else if (!enemy.GetIsAlive ()) {
			sr.enabled = false;
			box2D.enabled = false;
			//StopMoving ();
		} else {
			Raycasting ();
			if (spoted) {
				//Attack();
				SetFlipX ();
				//MovePatrol ();
				//FlipOnEdges ();
				movingPatrol ();
			} else if (canAttack) {

				/*if (isLeft) {
				FlipOnVerticalLeftEdges ();
			} else {
				FlipOnVerticalRightEdges ();
			}*/
				Attack ();
			} 
		}
	}



	public void movingPatrol(){
		if(nextPos == attackBoundleft.position || nextPos == attackBoundleft.position){
			nextPos = downBound.position;
		} 

		if((transform.position.y == attackBoundleft.position.y)||(transform.position.y == attackBoundRight.position.y)){
			nextPos = downBound.position;
		}

		if(transform.position.y >= upBound.position.y){
			nextPos = downBound.position;
		}
		if(transform.position.y <= downBound.position.y){
			nextPos = upBound.position;
		}
		transform.position = Vector3.MoveTowards(transform.position, nextPos, speedPatrol*Time.deltaTime);
	}

	public void Attack(){
		if(nextPos == downBound.position){
			nextPos = upBound.position;
		}

		if (!sr.flipX) {
			if(transform.position.y >=  upBound.position.y){
				nextPos = attackBoundleft.position;
			}
			if(transform.position.y <=  attackBoundleft.position.y){
				nextPos = upBound.position;
			}
		} else {
			if(transform.position.y >=  upBound.position.y){
				nextPos = attackBoundRight.position;
			}
			if(transform.position.y <=  attackBoundRight.position.y){
				nextPos = upBound.position;
			}
		}


		transform.position = Vector3.MoveTowards(transform.position, nextPos, speedAttack*Time.deltaTime);
	}

	

	public void Raycasting ()
	{
		Vector3 target = initialPosition;

		// Pero si la distancia hasta el jugador es menor que el radio de visión el objetivo será él
		float dist = Vector3.Distance (player.transform.position, transform.position);

		if (dist < visionRadius && dist > attackRadius) { 
			target = player.transform.position;
			spoted = true;
			canAttack = false;
		} else if (dist < attackRadius) {
			spoted = false;
			canAttack = true;
		} else {
			spoted = false;
			canAttack = false;
		}
		// Y podemos debugearlo con una línea
		Debug.DrawLine (transform.position, target, Color.green);

	}

	void OnDrawGizmos ()
	{
		Gizmos.DrawLine (upBound.position, attackBoundleft.position);
		Gizmos.DrawLine (upBound.position, attackBoundRight.position);
		Gizmos.DrawLine (upBound.position, downBound.position);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, visionRadius);
		Gizmos.DrawWireSphere (transform.position, attackRadius);
	}

	public void SetFlipX ()
	{
		if (Mathf.Sign (transform.position.x - player.transform.position.x) == 1)
			sr.flipX = false;
		else if (Mathf.Sign (transform.position.x - player.transform.position.x) == -1)
			sr.flipX = true;

	}
}
