using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	//creamos objeto de la clase LevelManager
	public LevelManager levelManager;

	// Use this for initialization
	void Start () {
		//asignamos de la clase LevelManager a el objeto
		levelManager = FindObjectOfType<LevelManager> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//metodo si choca con cualquier otro <collider2D>
	void OnTriggerEnter2D(Collider2D other)
	{
		//name --> nombre del objeto
		if (other.name == "Player") 
		{
			//llama el metodo de mensaje en consola
			levelManager.RespawnPlayer ();
		}
	}

}
