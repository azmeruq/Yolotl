using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBossCtrl : MonoBehaviour {
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
	[Tooltip("String value for the next scene's name")]
	public string nextNameScene;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!boss.GetComponent<EnemyHealth> ().GetIsAlive ()) {
			Invoke("GoToNextScene", 1.2f);
			GameDataCtrl.instance.SaveData (healthAmount, tonalliAmount, damageAmount, 0, indexLevel);
		}
	}

	void OnEnable(){
		//GameDataCtrl.instance.ResetData ();
		GameDataCtrl.instance.LoadData ();
	}

	public void GoToNextScene(){
		SceneManager.LoadScene (nextNameScene);
	}

	/// <summary>
	/// Shows the level complete panel.
	/// </summary>
	public void ShowLevelCompletePanel(){
		playerGUI.SetActive(false);
		completeLevelpanel.SetActive (true);
	}
}
