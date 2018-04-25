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
			other.gameObject.GetComponent<PlayerManager>().SetHealth(damageAmount); 
			other.gameObject.GetComponent<PlayerManager>().EnemyKnockBack(transform.position.x);
		}
	}
}
