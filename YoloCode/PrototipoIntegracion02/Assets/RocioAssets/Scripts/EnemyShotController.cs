using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotController : MonoBehaviour {
	
	public float speed;
	private Player player;
	//public GameObject enemyDeathEffect;
	//public GameObject impactEffect;
	//public int pointsForKill;
	public float rotationSpeed;
	private Rigidbody2D myrigidbody2D;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		myrigidbody2D = GetComponent<Rigidbody2D> ();

		/*
		if (player.transform.position.x < transform.position.x) 
		{
			speed = -speed;
			rotationSpeed = -rotationSpeed;
		}
		*/
		
	}
	
	// Update is called once per frame
	void Update () {
		myrigidbody2D.velocity = new Vector2 (speed, myrigidbody2D.velocity.y);
		myrigidbody2D.angularVelocity = rotationSpeed;		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.name == "Player") 
		{
			player.setHealth (player.getHealth () - 1);
			Destroy (this.gameObject);
		}
//		Instantiate (impactEffect, transform.position, transform.rotation);

	}
}
