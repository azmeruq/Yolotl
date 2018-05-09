using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the audio in the game 
/// </summary>
public class AudioCtrl : MonoBehaviour {
	public static AudioCtrl instance; // For calling the methods in this script
	public PlayerAudio playerAudio; // for accessing player audio effects
	//public AudioFX audioFX; // For accessing non player audio
	public Transform playerPosition; //The player position is needed for using its audio effects
	//[Tooltip("soundOn is used to toggle sound on/off from the inspector")]
	//public bool soundOn;
	// Use this for initialization
	void Start () {
		if (instance==null) {
			instance = this;
		}
	}
	
	public void PlayerShoot(Vector3 playerPos){
		AudioSource.PlayClipAtPoint (playerAudio.PlayerShoot, playerPos);
	}

	public void ItemPickup(Vector3 playerPos){
		AudioSource.PlayClipAtPoint (playerAudio.ItemPickup, playerPos);
	}

	public void CollectablePickup(Vector3 playerPos){
		AudioSource.PlayClipAtPoint (playerAudio.CollectablePickup, playerPos);
	}

	public void PlayerDies(Vector3 playerPos){
		AudioSource.PlayClipAtPoint (playerAudio.PlayerDies, playerPos);
	}

	public void EnemyDies(Vector3 enemyPos){
		AudioSource.PlayClipAtPoint (playerAudio.EnemyExplosion, enemyPos);
	}
}
