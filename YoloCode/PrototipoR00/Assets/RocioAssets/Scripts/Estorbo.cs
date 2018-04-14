using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estorbo : MonoBehaviour {

	private DialogueManager dMan;
	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (dMan.getContador() >= 5) {
			Destroy (this.gameObject);
		}


	}
}
