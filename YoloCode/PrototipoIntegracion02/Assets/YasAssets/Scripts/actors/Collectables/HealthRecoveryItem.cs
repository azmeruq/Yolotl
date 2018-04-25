using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRecoveryItem : MonoBehaviour {
	[Tooltip("Positive value. This value is tha amount of health than will be restored")]
	public float recoveryHealthAmount;

	void Start () {
		if (recoveryHealthAmount < 0) {
			recoveryHealthAmount = recoveryHealthAmount * -1f;
		} else if (recoveryHealthAmount == 0) {
			recoveryHealthAmount = 5f;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.GetComponent<PlayerManager>().SetHealth(-recoveryHealthAmount); 
			Destroy (gameObject);
		}
	}
}
