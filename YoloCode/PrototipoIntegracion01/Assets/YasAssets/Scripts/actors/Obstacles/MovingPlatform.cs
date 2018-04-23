using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	public Transform pos01, pos02, startPos;
	public float distance;
	private float speed;
	Vector3 nextPos;
	private GameObject player;
	// Use this for initialization
	void Start () {
		speed = 3.0f;	
		nextPos = startPos.position;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (CanMove ())
			Move ();
	}

	public void Move(){
		if(transform.position == pos01.position){
			nextPos = pos02.position;
		}
		if(transform.position == pos02.position){
			nextPos = pos01.position;
		}
		transform.position = Vector3.MoveTowards(transform.position, nextPos, speed*Time.deltaTime);
	}

	public bool CanMove(){
		float dist = Vector3.Distance (player.transform.position, transform.position);
		if (dist <= distance)
			return true;
		else
			return false;
	}
	void OnDrawGizmos() {
		//Gizmos.DrawWireSphere(transform.position, visionRadius);
		Gizmos.DrawLine (pos01.position, pos02.position);

	}
}
