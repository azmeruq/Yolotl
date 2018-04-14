using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCtrl : MonoBehaviour {
	private loaderScene loaderscene;
	public string scene;
	// Use this for initialization
	void Start () {
		loaderscene = gameObject.AddComponent<loaderScene>();
		// Cambiar para cinematica1
		loaderscene.SetSceneName (scene);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
