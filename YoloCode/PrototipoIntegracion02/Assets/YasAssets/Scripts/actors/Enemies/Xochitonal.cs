using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xochitonal : MonoBehaviour {
	private EnemyHealth enemy;
	private Animator anim;
	private BoxCollider2D box2D;
	private SpriteRenderer sr;
	private Rigidbody2D rb;
	/*
	 * This Array allows to control Xochitonal's attack patron
	 * whatCanDo [0] = true -> waitForAction
	 * whatCanDo [1] = true -> move
	 * whatCanDo [1] = true -> shot
	 */
	private bool[] whatCanDo;
	private bool canReShot;

	private Vector3 nextPos;
	private int controlNumber;
	public float speedPatrol;
	private float minDelay;
	private bool canTurn;
	private float originalSpeed;
	public Transform swimmingPos01;
	public Transform swimmingPos02;

	public Transform[] shotPos;
	public GameObject bubbleShot;
	private Vector3 initialPos;


	// Use this for initialization

	void Start () {
		anim = GetComponent<Animator> ();
		enemy = GetComponent<EnemyHealth> ();
		box2D = GetComponent <BoxCollider2D> ();
		sr = GetComponent <SpriteRenderer> ();
		rb  = GetComponent <Rigidbody2D> ();
		//speedPatrol = 2f;
		//	maxDelay = 4f;
		minDelay = 0f;
		canTurn = true;
		canReShot = true;
		whatCanDo = new bool[3];
		whatCanDo[0] = true;
		whatCanDo [1] = false;
		whatCanDo [2] = false;
		initialPos = transform.position;
		SetStartDirection ();
		//1f + (((float)score)/11f
		float damageAux = (1f + ((float)GameDataCtrl.instance.GetGameData().GetScoreAmount())/11f) * enemy.GetDamage();
		//Debug.Log (damageAux);
		enemy.SetDamage (damageAux);
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy.GetIsAlive()) {
			if (whatCanDo [0]) {
				//Debug.Log ("Espera");
				StartCoroutine (WaitForAction ());
			} else if (whatCanDo [1]) {
				//Debug.Log ("nada");
				MovePatrol ();
				FlipOnEdges ();
			} else if (whatCanDo [2]) {
				//Debug.Log ("dispara");
				Shot ();
			}
		} else {
			HanddleDeath ();
		}
	}

	public IEnumerator WaitForAction(){
		transform.position = initialPos;
		anim.SetInteger("state", 0);
		FitBoxCollider (-2.81f, 0.18f, 3.88f, 1.82f);
		yield return new WaitForSeconds (1.2f);
		ChangeAction (0, Random.Range(1,3));
	}
		

	public void FlipOnEdges(){
		// for Down vertical
		if ((!sr.flipX) && (transform.position.x >= swimmingPos02.position.x)) {
			if (canTurn) {
				canTurn = false;
				originalSpeed = speedPatrol;
				speedPatrol = 0;
				StartCoroutine ("TurnLeft", originalSpeed);
			}
			// for up vertical
		}else if((sr.flipX)&&(transform.position.x <= swimmingPos01.position.x)){
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
		ChangeAction (1, 0);
		StopMoving ();
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
		anim.SetInteger("state", 2);
		FitBoxCollider (0.132826f, -0.2757231f, 3.880422f, 0.8916478f);
		Vector2 temp = rb.velocity;
		temp.x = speedPatrol;
		rb.velocity = temp;
	}

	public void StopMoving(){
		rb.velocity = new Vector2(0f, 0f);
	}


	public void Shot(){
		StopAllCoroutines ();
		anim.SetInteger("state", 1);
		if (canReShot) {
			int i;
			canReShot = false;
			for (i= 0; i < shotPos.Length ; i++)
				Instantiate (bubbleShot, shotPos[i].position, Quaternion.identity);
			Invoke ("ReShot", 1.2f);
		}
		//ChangeAction (2, 0);
		Invoke ("MakeChagingAction", 1.2f);
	}

	public void ReShot(){
		canReShot = true;
	}

	public void ChangeAction(int indexPresentAction, int indexNextAction){
		whatCanDo[indexPresentAction] = false;
		whatCanDo[indexNextAction] = true;
	}

	public void MakeChagingAction(){
		ChangeAction (2, 0);
	}

	public void FitBoxCollider(float offsetx, float offsety, float sizex, float sizey){
		Vector2 box2DOffSet = new Vector2();
		Vector2 box2DSize = new Vector2();

		box2DOffSet.x = offsetx;//2.811507f
		box2DOffSet.y = offsety; // 0.1881718f
		box2DSize.x = sizex; // 3.880423f
		box2DSize.y = sizey; //1.821438f
		box2D.offset = box2DOffSet;
		box2D.size = box2DSize;
	}

	public void HanddleDeath(){
		sr.enabled = false;
		box2D.enabled = false;
		StopMoving ();
	}
}
