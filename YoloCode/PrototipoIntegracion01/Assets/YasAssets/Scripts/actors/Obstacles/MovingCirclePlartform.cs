using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Moving circle plartform.
/// </summary>
public class MovingCirclePlartform : MonoBehaviour {
	[Tooltip("Transform array for the movement")]
	public Transform[] movingPos;
	[Tooltip("Float value for the speed movement")]
	public float speed;
	/// <summary>
	/// The next position.
	/// </summary>
	private Vector3 nextPos;
	/// <summary>
	/// The control number for the next movement.
	/// </summary>
	private int controlNumber;

	// Use this for initialization
	void Start () {
		ReStartMovement ();
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	/// <summary>
	/// Move this instance.
	/// </summary>
	public void Move(){
		if(transform.position == nextPos){
			//Debug.Log (controlNumber);
			if (controlNumber == movingPos.Length-1) {
				ReStartMovement ();
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
		nextPos = movingPos [0].position;
		controlNumber = 0;

	}
}
