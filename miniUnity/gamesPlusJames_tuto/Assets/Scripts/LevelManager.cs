using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	//objeto checkpoint
	public GameObject currentCheckpoint;

	//objeto player de la clase PlayerController
	private PlayerController player;

	//variables de control de particulas
	public GameObject deathParticle;
	public GameObject respawnParticle;

	//variable de pausa en tiempo para reaparecer
	public float respawnDelay;


	// Use this for initialization
	void Start () {
		//donde esta el player
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//metodo para controlar tiempo del reaparecimiento
	public void RespawnPlayer()
	{
		//manda a llamar un metodo en IEnumerator
		StartCoroutine ("RespawnPlayerCo");
	}

	//metodo para reaparecer que esta en un IEnumerator para controlar su tiempo
	public IEnumerator RespawnPlayerCo()
	{
		//aqui se manda a llamar las particulas de muerte, donde esta posicionado el player, con su rotacion del player
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		//ya que hay un retraso de tiempo para reaparecer, el player sigue siendo visible en es lapso y puede moverse
		//deshabilitaremos en ese tiempo al player para corregirlo
		player.enabled = false;
		player.GetComponent<Renderer> ().enabled = false;
		//para arreglar el desliz de la camara cuando el personaje se muere...
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		//texto en consola de que ha reaparecido el player
		Debug.Log ("Player Respawn");

		//funcion para realizar un retardo entre lo que esta arriba y debajo de ella
		yield return new WaitForSeconds (respawnDelay);

		//la posicion del "player" será en la posicion de currentCheckPoint
		player.transform.position = currentCheckpoint.transform.position;
		//antes hemos deshabilitado el player, ya que ha reaparecido vamos a habilitarlo
		//y hacerlo visible
		player.enabled = true;
		player.GetComponent<Renderer> ().enabled = true;
		//aqui se manda a llamar las particulas de reaparecer, donde se encuentra el checkpoint activo, con su rotacion del checkpoint
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
	}
}
