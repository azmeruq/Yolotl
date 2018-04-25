using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02Ctrl : MonoBehaviour {
	public GameObject CompleteLevelpanel;
	public GameObject PlayerGUI;
	// Use this for initialization
	void Awake(){
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable(){
		GameDataCtrl.instance.LoadData ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) { 
			//int score = other.gameObject.GetComponent<Player> ().GetScore ();
			Invoke("ShowLevelCompletePanel", 1.2f);
			GameDataCtrl.instance.SaveData (50f, 30f, 5f, other.gameObject.GetComponent<PlayerManager> ().GetScore (), 3);

		} 

		//Debug.Log ("Col");
	}

	public void ShowLevelCompletePanel(){
		PlayerGUI.SetActive(false);
		CompleteLevelpanel.SetActive (true);
	}

}
