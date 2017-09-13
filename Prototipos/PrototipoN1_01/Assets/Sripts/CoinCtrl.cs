using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the coin behavior when the player  interacts with it
/// </summary>

public class CoinCtrl : MonoBehaviour {

	public enum CoinFX{
		Vanish,
		Fly
	}

	public CoinFX coinFX;
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			if(coinFX == CoinFX.Vanish)
				Destroy (gameObject);
		}
		
	}
}
