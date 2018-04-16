using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseCtrl : MonoBehaviour {
	private bool isActived;
	public GameObject pausedPanel;

	// Use this for initialization
	void Awake(){
		Time.timeScale = 1;
	}

	void Start () {
		pausedPanel.SetActive (false);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetGamePaused(){
		pausedPanel.SetActive (true);
		Time.timeScale = 0;
	}

	public void SetGameActive(){
		pausedPanel.SetActive (false);
		Time.timeScale = 1f;
	}
		
}
