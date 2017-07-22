using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public LevelManager levelManager;

	// Use this for initialization
	void Start () {
		//asignamos de la clase LevelManager a el objeto
		levelManager = FindObjectOfType<LevelManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//metodo de reconocimiento que el "player" ha pasado por el "checkpoint"
	void OnTriggerEnter2D(Collider2D other)
	{
		//si el collider2D del CHECKPOINT ha chocado con el collider2D del PLAYER
		//name --> nombre del objeto
		if (other.name == "Player") 
		{
			//llama la variable <currentCheckpoint> del objeto <levelManager>
			//y ahora asigna el nuevo checkpoint a este actual GAMEOBJECT
			levelManager.currentCheckpoint = gameObject;
			//mensaje de que checkpoint esta siendo usado
			Debug.Log ("Checkpoint activado en coordenadas:" + transform.position);
		}
	}
}
