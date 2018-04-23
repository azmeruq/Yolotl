using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class leeArchivos : MonoBehaviour {

	private string resultado;
	private string[] lineas;
	// Use this for initialization
	void Start () {
		resultado = " ";
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Q)){
			resultado = File.ReadAllText("file.txt");
			Debug.Log(resultado);
		}
		if(Input.GetKeyDown (KeyCode.W)){
			lineas = File.ReadAllLines ("file.txt");
			Debug.Log(lineas);
		}
	}


}
