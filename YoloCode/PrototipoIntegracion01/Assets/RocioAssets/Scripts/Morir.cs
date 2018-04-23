using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morir : State {
	public GameObject gane;
	public GameObject destruir;


	void Update()
	{
		gane.SetActive (true);
		Debug.Log ("falleci");
		Destroy (destruir);

	}
		
}
