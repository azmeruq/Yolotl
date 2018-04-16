using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColibriCollider : MonoBehaviour {
	public XolotlColibri xolo;

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Player")) {
			xolo.SetPlayerFirtsJump (true);
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.CompareTag ("Player")) {
			if(xolo.isOnLastPosition()){
				xolo.reStarPositions ();
			}
		}
	}
}
