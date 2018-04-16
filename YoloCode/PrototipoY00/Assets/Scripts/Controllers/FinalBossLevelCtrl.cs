﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossLevelCtrl : MonoBehaviour {

	[Tooltip("This GameObject is Complete Level panel from the GUI")]
	public GameObject completeLevelpanel;
	[Tooltip("This GameObject is player botons panel from the GUI")]
	public GameObject playerGUI;
	[Tooltip("This GameObject is boss from this level")]
	public GameObject boss;
	[Tooltip("Float value than will be save as the player health amount")]
	public float healthAmount;
	[Tooltip("Float value than will be save as the player tonalli amount")]
	public float tonalliAmount;
	[Tooltip("Float value than will be save as the player damage amount")]
	public float damageAmount;
	[Tooltip("Int value than represents the index of the level than will be unlocked at the end of the boss battle")]
	public int indexLevel;
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (!boss.GetComponent<MictlantecuhtliPhase02> ().IsAlive ()) {
			Invoke("ShowLevelCompletePanel", 1.2f);
			GameDataCtrl.instance.SaveData (healthAmount, tonalliAmount, damageAmount, 0, indexLevel);
		}
	}

	void OnEnable(){
		//GameDataCtrl.instance.ResetData ();
		GameDataCtrl.instance.LoadData ();
	}

	/// <summary>
	/// Shows the level complete panel.
	/// </summary>
	public void ShowLevelCompletePanel(){
		playerGUI.SetActive(false);
		completeLevelpanel.SetActive (true);
	}
}
