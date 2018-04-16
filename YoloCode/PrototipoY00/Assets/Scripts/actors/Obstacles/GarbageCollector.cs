using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){		
		if (other.gameObject.CompareTag ("Player")) {
			
			if(other.gameObject.GetComponent<Player>().GetIsAlive()){
				float damageAmount = other.gameObject.GetComponent<Player> ().GetMaxHealth ();
				other.gameObject.GetComponent<Player>().SetHealth(damageAmount); 
			}
		}else if(((!other.gameObject.CompareTag ("Ground")&&!other.gameObject.CompareTag ("Playerfeet"))&&(!other.gameObject.CompareTag ("Collectable")&&!other.gameObject.CompareTag ("Limit")))&&!other.gameObject.CompareTag ("Camera")){
			Destroy (other.gameObject);
		}
	}
}
