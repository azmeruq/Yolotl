using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){		
		if (other.gameObject.CompareTag ("Player")) {
			
			if(other.gameObject.GetComponent<PlayerManager>().GetIsAlive()){
				float damageAmount = other.gameObject.GetComponent<PlayerManager> ().GetMaxHealth ();
				other.gameObject.GetComponent<PlayerManager>().SetHealth(damageAmount); 
			}
		}else if(((!other.gameObject.CompareTag ("Ground")&&!other.gameObject.CompareTag ("Playerfeet"))&&(!other.gameObject.CompareTag ("Collectable")&&!other.gameObject.CompareTag ("Limit")))&&!other.gameObject.CompareTag ("Camera")){
			Destroy (other.gameObject);
		}
	}
}
