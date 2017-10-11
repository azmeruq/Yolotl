using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys any object that comes in contact with it
/// </summary>

public class GarbageCtrl : MonoBehaviour {
	public string sceneName;	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			GameCtrl.instance.PlayerDied (other.gameObject);
		} else {
			Destroy (other.gameObject);
		}
	}
}
