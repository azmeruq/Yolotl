using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the audio in the game 
/// </summary>
public class AudioCtrl : MonoBehaviour {
	public static AudioCtrl instance; // For calling the methods in this script
	public PlayerAudio playerAudio; // for accessing player audio effects
	public AudioFX audioFX; // For accessing non player audio
	public Transform playerPosition; //The player position is needed for using its audio effects
	[Tooltip("soundOn is used to toggle sound on/off from the inspector")]
	public bool soundOn;
	// Use this for initialization
	void Start () {
		if (instance==null) {
			instance = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
