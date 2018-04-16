using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Collectable ctrl.
/// This class controls all the collectable items like dogs or keys
/// </summary>
public class CollectableCtrl : MonoBehaviour{
	//private bool hasBeenCollected;

	void Start(){
		//hasBeenCollected = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			//other.gameObject.GetComponent<Player> ().UpDateScore ();
			//hasBeenCollected = true;
			Destroy (gameObject);
		}
	}
}
