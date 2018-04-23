using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MictlantecuhtliHand : MonoBehaviour {
	[Tooltip("Transform array,  than represents the movement line")]
	public Transform[] movingPos;
	[Tooltip("Float value, than represents the speed movement")]
	public float speed;

	/*
	 * Atributtes for the Move method
	*/
	private Vector3 nextPos;
	private int controlNumber;
	private bool isMovingRight;

	private EnemyHealth enemy;
	private SpriteRenderer sr;
	private BoxCollider2D box2D;
	// Use this for initialization
	void Start () {
		enemy = GetComponent<EnemyHealth> ();
		sr = gameObject.GetComponent <SpriteRenderer> ();
		box2D = gameObject.GetComponent <BoxCollider2D> ();
		nextPos = movingPos [0].position;
		controlNumber = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy.GetIsAlive ()) {
			Move ();
		} else {
			HanddleDeath ();
		}
	}

	public void Move(){
		if(transform.position == nextPos){
			if (controlNumber == movingPos.Length-1) {
				nextPos = movingPos [0].position;
				controlNumber = 0;
			} else {
				controlNumber++;	
				nextPos = movingPos [controlNumber].position;
			}
		}
		transform.position = Vector3.MoveTowards(transform.position, nextPos, speed*Time.deltaTime);
	}

	public void HanddleDeath(){
		sr.enabled = false;
		box2D.enabled = false;
		//StopMoving ();
	}
}
