using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCtrl : MonoBehaviour {
	public static GameOverCtrl instance;
	private loaderScene loader;
	public PlayerManager player;
	public GameObject gameoverPanel;
	public string SceneName;
	public string nextSceneName;
	// Use this for initialization
	void Awake(){
		loader = gameObject.AddComponent<loaderScene>();
		if (instance == null) {
			instance = this;
		}
	//	gameover.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GotoLevelSelection(){
		loader.SetSceneName ("00_LevelSelector");
		loader.changeScene ();
	}

	public void Retry(){
		player.PausedForReviving();
	}

	public void setActive(bool value){
		gameoverPanel.SetActive (value);
	}

	public void quitAplication(){
		Application.Quit ();
	}

	public void RestartSinceBegining(){
		loader.SetSceneName (SceneName);
		loader.changeScene ();
	}

	public void GoToNextScene(){
		loader.SetSceneName (nextSceneName);
		loader.changeScene ();
	}
}
