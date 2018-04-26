using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loaderSceneR : MonoBehaviour {
	private string sceneName;
	public float valor1;
	public float valor2;
	public float valor3;
	public int valorA;
	public int valorB;
	// Use this for initialization
	public void changeScene(){
		GameDataCtrl.instance.SaveData (valor1, valor2, valor3, valorA, valorB);
		SceneManager.LoadScene (sceneName);
	}

	public void SetSceneName(string sceneN){
		sceneName = sceneN;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag ("Player")){
			changeScene ();
		}
	}
}