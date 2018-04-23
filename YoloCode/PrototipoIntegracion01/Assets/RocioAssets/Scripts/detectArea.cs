using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectArea : MonoBehaviour {

	public GameObject cosa;
	private Rigidbody2D rid;
	public GameObject destroyThis;
	private float waitSeconds = 15;
	// Use this for initialization
	void Start () {
		//pico = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			//Debug.Log("hola");
			cosa.gameObject.AddComponent<Rigidbody2D> ();

			Destroy (destroyThis, waitSeconds);
			//pico.gameObject.AddComponent<Rigidbody2D> ().freezeRotation = false;
		}
	}
}
