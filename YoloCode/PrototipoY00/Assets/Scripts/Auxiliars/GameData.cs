using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// The Data Model for the game data
/// </summary>
[Serializable]
public class GameData{
	private float healthAmount;
	private float tonalliAmount;
	private float damageTonalli;
	private int scoreAmount;
	private bool[] levels; 

	/// <summary>
	/// Getters
	/// </summary>

	public float GetHealthAmount(){
		return healthAmount;
	}

	public float GetTonalliAmount(){
		return tonalliAmount;
	}

	public float GetDamageAmount(){
		return damageTonalli;
	}

	public int GetScoreAmount(){
		return scoreAmount;
	}

	public bool GetLevel(int value){
		return levels [value];
	}
	/// <summary>
	/// Setters	
	/// </summary>

	public void SetHealthAmount(float health){
		healthAmount = health;
	}

	public void SetTonalliAmount(float tonalli){
		tonalliAmount = tonalli;
	}

	public void SetDamageAmount(float damage){
		damageTonalli = damage;
	}

	public void SetScoreAmount(int score){
		scoreAmount = score;
	}

	public void SetLevelActive(int index){
		levels [index] = true; 
	}

	public void SetLevels(bool []lev){
		levels = lev;
	}
}
