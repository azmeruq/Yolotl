using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonalliRecoveryItem : MonoBehaviour {
	[Tooltip("Positive value. This value is tha amount of tonalli than will be restored")]
	public float recoveryTonalliAmount;

	void Start () {
		if (recoveryTonalliAmount < 0) {
			recoveryTonalliAmount = recoveryTonalliAmount * -1f;
		} else if (recoveryTonalliAmount == 0) {
			recoveryTonalliAmount = 5f;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.GetComponent<PlayerManager> ().SetTonalli (recoveryTonalliAmount);
			Destroy (gameObject);
		}
	}
}
