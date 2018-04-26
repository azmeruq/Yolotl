using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Contains audio clips related to the player 	
/// </summary>

[Serializable]
public class PlayerAudio{
	public AudioClip PlayerJumps;
	public AudioClip ItemPickup;
	public AudioClip CollectablePickup;
	public AudioClip EnemyExplosion;
	public AudioClip PlayerDies;
}
