using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Bullet02 : MonoBehaviour {

	public Vector2 speed;
	Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = speed;
	}

	// Update is called once per frame
	void Update () {
		rb.velocity = speed;
	}

	void OnCollisionEnter2D(Collision2D other){
		//Debug.Log ("ok");
		if (other.gameObject.CompareTag ("Enemy")) {
			//Debug.Log ("ok");
			GameCtrl.instance.PlayerDiedAnimation (gameObject);		
		}
	}
}
