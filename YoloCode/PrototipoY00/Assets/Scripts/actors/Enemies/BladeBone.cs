using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeBone : MonoBehaviour {
	[Tooltip("Transform array,  than represents the movement line")]
	public Transform[] movingPositions;
	[Tooltip("Float value, than represents the speed movement")]
	public float speed;
	[Tooltip("Float value, than represents the damage value")]
	public float damage;

	private bool isActive;
	private Vector3 nextPos;
	private int controlNumber;

	// Use this for initialization
	void Start () {
		nextPos = movingPositions [0].position;
		controlNumber = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			Move ();
		}
	}
	/// <summary>
	/// Move this instance.
	/// </summary>
	public void Move(){
		if(transform.position == nextPos){
			//Debug.Log (controlNumber);
			if(controlNumber == movingPositions.Length-1 && nextPos==movingPositions[0].position){
				controlNumber = 0;
				nextPos = movingPositions [1].position;
				isActive = false; 
			}
			if (controlNumber == movingPositions.Length-1) {
				nextPos = movingPositions [0].position;
			} else {
				controlNumber++;	
				nextPos = movingPositions [controlNumber].position;
			}
		}
		transform.position = Vector3.MoveTowards(transform.position, nextPos, speed*Time.deltaTime);
	}

	public void SetIsActive(bool value){
		isActive = value;
	}

	public bool GetIsActive(){
		return isActive;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			other.SendMessage("SetHealth", damage);
			other.SendMessage ("EnemyKnockBack", transform.position.x);
			//Destroy (gameObject);
		}

		//Debug.Log ("Col");
	}
}
