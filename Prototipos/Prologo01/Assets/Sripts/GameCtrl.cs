using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


/// <summary>
/// Manages  the important gameplay features like keeping  the score,  restarting levels,
/// saving, loading data, updating  the HUD, etc
/// </summary>
public class GameCtrl : MonoBehaviour {
	//public string sceneName;
	public static GameCtrl instance;
	public float restartDelay;
	public int enemyValue;
	public GameData data;

	public UI ui;

	public enum Item{
		Enemy
	}


	string dataFilePath;
	BinaryFormatter bf;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
		bf = new BinaryFormatter ();
		dataFilePath = Application.persistentDataPath + "/game.dat";

		Debug.Log (dataFilePath);
	}

	void Start () {
		HandleFirstBoot ();
		UpdateHearts ();
	}
	

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
			ResetData ();
	}

	public void SaveData(){
		FileStream fs = new FileStream (dataFilePath, FileMode.Create);
		bf.Serialize (fs, data);
		fs.Close ();//
	}

	public void LoadData(){
		if(File.Exists(dataFilePath)){
			FileStream fs = new FileStream (dataFilePath, FileMode.Open);
			data = (GameData)bf.Deserialize (fs);
			//Debug.Log ("Numer of dogs=" + data.xoloCount);
			ui.txtXoloCount.text = "x" + data.xoloCount;
			ui.txtScore.text = "Score: " + data.score;
			fs.Close ();
		}
	}

	void OnEnable(){
		Debug.Log ("Data Loaded");
		LoadData ();
	}

	void OnDisable(){
		Debug.Log ("Saved Data");
		SaveData ();
	}

	void ResetData(){
		FileStream fs = new FileStream (dataFilePath,FileMode.Create); 
		data.xoloCount = 0;
		ui.txtXoloCount.text = "x" + data.xoloCount;
		data.score = 0;
		ui.txtScore.text = "Score: " + data.score;
		data.lives = 3;
		UpdateHearts ();
		bf.Serialize (fs, data);
		fs.Close ();
		Debug.Log ("Data reset");
	}
	/// <summary>
	/// restarts the level when player dies
	/// </summary>
	public void PlayerDied(GameObject player){
		player.SetActive (false);
		CheckLives ();
		Invoke ("RestartLevel", restartDelay);
	}



	public void PlayerDiedAnimation(GameObject player){
		Rigidbody2D rb = player.GetComponent<Rigidbody2D> ();
		//throw the player back in the air
		rb.AddForce (new Vector2(-150f, 400f));
		//rotate the player a bit
		player.transform.Rotate (new Vector3 (0,0,45f));
		// Disable the PlayerManayer script 
		player.GetComponent<PlayerManager> ().enabled = false;
		// disable the colliders attached to the player so the player can 
		//fall through the air
		foreach(Collider2D c2D in player.transform.GetComponents<Collider2D>()){
			c2D.enabled = false;
		}
		//disable the child object attached to the player
		foreach(Transform child in player.transform){
			child.gameObject.SetActive (false);
		}

		//Disable the camera attached to the player
		Camera.main.GetComponent<CameraCtrl>().enabled = false;

		// set the velocity to the cat to zero
		rb.velocity = Vector2.zero;

		//reStar the leve
		StartCoroutine("PausedBeforeReload", player);
	}

	IEnumerator PausedBeforeReload(GameObject player){
		yield return new WaitForSeconds (1.5f);
		PlayerDied (player);
	}

	public void UpdateXoloCount(){
		data.xoloCount += 1;
		ui.txtXoloCount.text = "x" + data.xoloCount;
	}

	public void UpdateScore(Item item){
		int itemValue = 0;

		switch (item) {
		case Item.Enemy:
			itemValue = enemyValue;
			break;
		default:
			break;
		}
		data.score += itemValue;
		ui.txtScore.text = "Score: " + data.score;
	}

	public void BulletHitEnemy(Transform enemy){
		//Shows the enemy explosion SFX
		Vector3 pos = enemy.position;
		pos.z = 20f;
		SFXCtrl.instance.EnemyExplosion (pos);
		//destroy the enemy
		Destroy(enemy.gameObject);

		//update the score
		UpdateScore(Item.Enemy);

	}
	/// <summary>
	/// This will iniciate all the values for the data variables
	/// lives = 3
	/// number of dogs =0
	/// score=0
	/// </summary>
	public void HandleFirstBoot (){
		if (data.isForstBoot) {
			data.lives = 3;
			data.xoloCount = 0;
			data.score = 0;
			data.isForstBoot = false;
		}
	}

	public void UpdateHearts (){
		if(data.lives==3){
			ui.heart3.sprite = ui.fullHeart;
			ui.heart2.sprite = ui.fullHeart;
			ui.heart1.sprite = ui.fullHeart;
		}

		if(data.lives==2){
			ui.heart1.sprite = ui.emptyHeart;
		}

		if(data.lives==1){
			ui.heart1.sprite = ui.emptyHeart;
			ui.heart2.sprite = ui.emptyHeart;
		}

	}

	public void CheckLives(){
		int updatedLives = data.lives;
		updatedLives -= 1;
		data.lives = updatedLives;

		if (data.lives == 0) {
			
			data.lives = 3;
			SaveData ();
			Debug.Log ("vic");
			Invoke ("GameOver", restartDelay);
		} else {
			SaveData ();
			Invoke ("RestarLevel", restartDelay);
		}
	}

	public void GameOver(){
		Debug.Log ("vic02");
		ui.panelGameOver.SetActive (true);
	}
	public void RestartLevel(){
		SceneManager.LoadScene ("level01");
	}
}
