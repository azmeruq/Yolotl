using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEnergy : MonoBehaviour {
	public Transform[] movingPos;
	private Vector3 nextPos;
	private int controlNumber;
	private float timeBetweenAttacks;
	public float speed;
	private Vector3 initialPos;
	public float distance;
	public GameObject tlazolteolt;
	// Use this for initialization
	void Start () {
		initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	public void Move(){
		if(transform.position == nextPos){
			//Debug.Log (controlNumber);
			if (controlNumber == movingPos.Length-1) {
				speed = 0;
			} else {
				controlNumber++;	
				nextPos = movingPos [controlNumber].position;
			}
		}
		transform.position = Vector3.MoveTowards(transform.position, nextPos, speed*Time.deltaTime);
	}

	/// <summary>
	/// Restart the movement.
	/// </summary>
	public void ReStartMovement(){
		transform.position = initialPos;
		nextPos = movingPos [0].position;
		controlNumber = 1;

	}
		

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			speed = 0;
		}

		//Debug.Log ("Col");
	}
}
