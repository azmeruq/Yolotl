using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingPlatform : MonoBehaviour {

	// Use this for initialization
	private float DroppingDelay;
	private Rigidbody2D rb;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		//player = FindObjectOfType<Player> ();
		DroppingDelay = 0.3f;
	}
		

	public void StartDropping(){
		rb.bodyType = RigidbodyType2D.Dynamic;
	}

	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log ("op");
		if (other.gameObject.CompareTag ("Playerfeet")) {
			//Debug.Log ("op2");
			//player.SetIsJumping (false);
			Invoke ("StartDropping", DroppingDelay);
		}
	}
}
