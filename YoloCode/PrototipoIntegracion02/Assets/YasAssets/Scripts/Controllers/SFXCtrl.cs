using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// SFX ctrl.
/// This class controls the particles effects
/// </summary>
public class SFXCtrl : MonoBehaviour {
	public static SFXCtrl instance; //Allows other scripts to acces publict methods
	public SFX sfx;//the particle effec to show when player picks the collectable

	void Awake(){
		if (instance == null)
			instance = this;
	}

	/// <summary>
	/// Shows the coin sparkle effect when the player collects a collectable or Item.
	/// </summary>
	public void ShowCoinSparkle(Vector3 pos){
		Instantiate (sfx.sfx_coin_pickup, pos, Quaternion.identity);
	}

	public void ShowEnemyExplosion(Vector3 pos){
		Instantiate (sfx.sfx_enemy_explosion, pos, Quaternion.identity);
	}
}
