using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	public Transform pos01, pos02, startPos;
	private float speed;
	Vector3 nextPos;
	// Use this for initialization
	void Start () {
		speed = 3.0f;	
		nextPos = startPos.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position == pos01.position){
			nextPos = pos02.position;
		}
		if(transform.position == pos02.position){
			nextPos = pos01.position;
		}
		transform.position = Vector3.MoveTowards(transform.position, nextPos, speed*Time.deltaTime);
	}
}
