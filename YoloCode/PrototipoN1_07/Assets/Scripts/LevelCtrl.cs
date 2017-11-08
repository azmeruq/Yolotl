using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCtrl : MonoBehaviour {
	private loaderScene loaderscene;
	// Use this for initialization
	void Start () {
		loaderscene = gameObject.AddComponent<loaderScene>();
		// Cambiar para cinematica1
		loaderscene.SetSceneName ("01Level_01selva");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
