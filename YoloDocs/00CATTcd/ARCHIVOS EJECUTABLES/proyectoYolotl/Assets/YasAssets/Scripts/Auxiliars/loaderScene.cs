using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loaderScene : MonoBehaviour {
	public string sceneName;
	// Use this for initialization
	public void changeScene(){
		SceneManager.LoadScene (sceneName);
	}

	public void SetSceneName(string scene){
		sceneName = scene;
	}
}
