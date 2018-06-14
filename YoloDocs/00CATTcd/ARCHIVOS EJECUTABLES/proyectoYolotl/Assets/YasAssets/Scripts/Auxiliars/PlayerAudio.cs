using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Contains audio clips related to the player 	
/// </summary>

[Serializable]
public class PlayerAudio{
	public AudioClip CollectablePickup;
	public AudioClip ItemPickup;
	public AudioClip PlayerShoot;
	public AudioClip EnemyExplosion;
	public AudioClip PlayerDies;
}
