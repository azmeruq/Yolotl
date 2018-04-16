using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusingObstacle : MonoBehaviour {
	private Rigidbody2D rb;
	public float horizontalSpeed;
	public float verticalSpeed;
	public Transform trans;
	// Use this for initialization
	void Start () {
		trans = GetComponent<Transform> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2(horizontalSpeed, verticalSpeed);
	}

	void SetVerticalSpeed(float newSpeed){
		verticalSpeed = newSpeed;
	}

	void SetHorizontalSpeed(float newSpeed){
		horizontalSpeed = newSpeed;
	}

	void SetRotationZ(float rotationZ){
		trans.Rotate (0, 0, rotationZ);
	}
}