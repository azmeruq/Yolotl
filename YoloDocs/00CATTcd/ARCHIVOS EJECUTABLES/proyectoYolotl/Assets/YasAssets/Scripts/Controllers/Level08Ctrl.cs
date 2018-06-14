using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level08Ctrl : MonoBehaviour {

	public GameObject CompleteLevelpanel;
	public GameObject PlayerGUI;
	// Use this for initialization
	void Awake(){

	}

	// Update is called once per frame
	void Update () {

	}

	void OnEnable(){
		//GameDataCtrl.instance.SaveData (70f, 50f, 15f, 0, 11);
		GameDataCtrl.instance.LoadData ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) { 
			//int score = other.gameObject.GetComponent<Player> ().GetScore ();
			Invoke("ShowLevelCompletePanel", 1.2f);
			GameDataCtrl.instance.SaveData (80f, 60f, 20f, 0, 15);

		} 

		//Debug.Log ("Col");
	}

	public void ShowLevelCompletePanel(){
		PlayerGUI.SetActive(false);
		CompleteLevelpanel.SetActive (true);
	}

}
