using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	//objeto checkpoint
	public GameObject currentCheckpoint;

	//objeto player de la clase PlayerController
	private PlayerController player;


	// Use this for initialization
	void Start () {
		//donde esta el player
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//metodo para reaparecer
	public void RespawnPlayer()
	{
		//texto en consola
		Debug.Log ("Player Respawn");
		//la posicion del "player" será en la posicion de currentCheckPoint
		player.transform.position = currentCheckpoint.transform.position;
	}
}
