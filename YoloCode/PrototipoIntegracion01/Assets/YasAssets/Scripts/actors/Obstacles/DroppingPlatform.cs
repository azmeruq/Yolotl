using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingPlatform : MonoBehaviour {

	// Use this for initialization
	public float DroppingDelay;
	private Rigidbody2D rb;
	private PlayerManager player;
	private Vector3 initialPos;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		player = FindObjectOfType<PlayerManager> ();
		//DroppingDelay = 0.3f;
		initialPos = transform.position;
	}
		
	void Update () {
		if (!player.GetIsAlive ()) {
			rb.velocity = new Vector2(0f, 0f);
			//rb.gravityScale = 0;
			rb.bodyType = RigidbodyType2D.Kinematic;
			transform.position = initialPos;
		}
	}

	public void StartDropping(){
		//rb.gravityScale = 1f;
		rb.bodyType = RigidbodyType2D.Dynamic;
	}

	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log ("op");
		if (other.gameObject.CompareTag ("Playerfeet")) {
			//Debug.Log ("op2");
			//player.SetIsJumping (false);
			Invoke ("StartDropping", DroppingDelay);
		}
		if (other.gameObject.CompareTag ("GarbageCollector")) {
			

		}
	}
}
