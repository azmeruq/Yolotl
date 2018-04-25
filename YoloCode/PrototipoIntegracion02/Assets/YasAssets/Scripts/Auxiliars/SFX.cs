using System;
using UnityEngine;

/// <summary>
/// Groups the particle effects used in the game
/// </summary>


[Serializable]
public class SFX{
	[Tooltip("the particle effect to show when player picks the collectable")]
	public GameObject sfx_coin_pickup;
	[Tooltip("the particle effect to show when player destroys an enemy")]
	public GameObject sfx_enemy_explosion;
		

}
