using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour {
	public float damageAmount;

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			other.SendMessage("SetHealth", damageAmount);
			other.SendMessage ("EnemyKnockBack", transform.position.x);
		}
	}
}
