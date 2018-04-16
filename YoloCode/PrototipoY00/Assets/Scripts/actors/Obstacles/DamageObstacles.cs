using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObstacles : MonoBehaviour {
	public float damageAmount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.GetComponent<Player>().SetHealth(damageAmount); 
			other.gameObject.GetComponent<Player>().EnemyKnockBack(transform.position.x);
		}
	}
}
