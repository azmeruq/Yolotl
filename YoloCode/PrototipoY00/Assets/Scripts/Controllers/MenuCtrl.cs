using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour {

	public void changeScene(string sceneName){
		GameDataCtrl.instance.CreateNewGameData ();
		SceneManager.LoadScene (sceneName);
	}

	public void changeToLevel02Plt(string sceneName){
		GameDataCtrl.instance.SaveData (50f, 30f, 5f, 0, 2);
		SceneManager.LoadScene (sceneName);
	}

	public void changeToLevel04Plt(string sceneName){
		GameDataCtrl.instance.SaveData (60f, 40f, 15f, 0, 7);
		SceneManager.LoadScene (sceneName);
	}

	public void changeToLevel06Plt(string sceneName){
		GameDataCtrl.instance.SaveData (70f, 50f, 15f, 0, 10);
		SceneManager.LoadScene (sceneName);
	}

	public void changeToLevel08Plt(string sceneName){
		GameDataCtrl.instance.SaveData (80f, 60f, 20f, 0, 14);
		SceneManager.LoadScene (sceneName);
	}

	public void changeToLevel10Plt(string sceneName){
		GameDataCtrl.instance.SaveData (90f, 70f, 25f, 0, 18);
		SceneManager.LoadScene (sceneName);
	}
	

}
