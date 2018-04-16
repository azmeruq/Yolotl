using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
// this allow to use the BinaryFormatter for the gameData
using System.Runtime.Serialization.Formatters.Binary; 

public class GameDataCtrl : MonoBehaviour {
	public static GameDataCtrl instance = null;
	private float restartDelay;
	private GameData data;

	/*
	 * This 
	*/
	string dataFilePath;
	BinaryFormatter bf;
	//public Player player;

	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
		bf = new BinaryFormatter ();
		dataFilePath = Application.persistentDataPath + "/game.dat";
		Debug.Log (dataFilePath);
		data = new GameData (); 
		//data = new GameData ();
	}

	/*void OnEnable(){
		if (File.Exists (dataFilePath)) {
			LoadData ();
			Debug.Log ("Load");
		}
	}*/

	// int LevelIndex
	/// <summary>
	/// Saves the game data
	/// </summary>
	/// <param name="health"> Update Health amount. </param>
	/// <param name="tonalli"> Update Tonalli amount. </param>
	/// <param name="damage"> Update Damage amount. </param>
	/// <param name="score"> Update score amount. </param>
	public void SaveData(float health, float tonalli, float damage, int score, int index){
		FileStream fs = new FileStream (dataFilePath, FileMode.Create);
		data.SetHealthAmount (health);
		data.SetTonalliAmount (tonalli);
		data.SetDamageAmount (damage);
		data.SetScoreAmount (score);
		data.SetLevelActive (index);
		bf.Serialize (fs, data);
		fs.Close ();
	}


	/// <summary>
	/// Loads the data.
	/// </summary>
	public void LoadData(){
		if(File.Exists(dataFilePath)){
			FileStream fs = new FileStream (dataFilePath, FileMode.Open);
			data = (GameData) bf.Deserialize (fs);
			//Debug.Log (data.GetHealthAmount());
			fs.Close ();
		}
	}

	public void ResetData(){
		FileStream fs = new FileStream (dataFilePath, FileMode.Create);
		data.SetHealthAmount (50f);
		data.SetTonalliAmount (30f);
		data.SetDamageAmount (5f);
		data.SetScoreAmount (0);
		data.SetLevels (new bool[21]);
		//Debug.Log (data.GetHealthAmount ());
		//Debug.Log (data.GetTonalliAmount ());
		bf.Serialize (fs, data);
		fs.Close ();
	}

	public void CreateNewGameData(){
		//ResetData ();
			ResetData ();
	}

	// Update is called once per frame

	public GameData GetGameData(){
		return data;
	}
}
