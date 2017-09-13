using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 	Handles the particle  effects and others  special effects
/// </summary>
public class SFXCtrl : MonoBehaviour {
	// Allows other scripts to access public methods in this class without creating an object of this class
	public static SFXCtrl instance;
	//the particle effect to show  when the player picks the coins
	//public GameObject sfx_coin_pickup;

	public SFX sfx;
	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}


	/// <summary>
	/// Shows the coin sparkle effect when the player collects the coin 
	/// </summary>
	public void ShowCoinSparkle(Vector3 pos){
		Instantiate (sfx.sfx_coin_pickup, pos, Quaternion.identity);
	}

	/// <summary>
	/// Shows a explosion effect when the player bullet hits the enemy 
	/// </summary>
	public void EnemyExplosion(Vector3 pos){
		Instantiate (sfx.sfx_enemy_explosion, pos, Quaternion.identity);
	}
}
