using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MANTENER DIALOGO
//

public class dialogHolder : MonoBehaviour {

	//variable del texto a escribir en el cuadro 
	public string dialogue;
	//objeto de DIALOGUEMANAGER
	private DialogueManager dMan;
	//variable gameobject a manipular, globo
	public GameObject globe;
	//variable de activacion del globo
	public bool globeActive;

	//objeto PLAYERCONTROLLER, player
	public PlayerController player;
	//variable de rango de detecccion del player
	public float playerRange;


	void Start () {
		//asignamos el objeto DIALOGUEMANAGER a dMan
		dMan = FindObjectOfType<DialogueManager> ();
		//globe.SetActive (false);
		//globeActive = false;
		
	}


	void Update () {
		//linea visible para visualizar el rango de detección del player, 
		Debug.DrawLine (new Vector3 (transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3 (transform.position.x + playerRange, transform.position.y, transform.position.z));
		if (player.transform.position.x < transform.position.x + playerRange && player.transform.position.x > transform.position.x - playerRange) 
		{
			globe.SetActive (true);
			globeActive = true;
		} 
		else 
		{
			globe.SetActive (false);
			globeActive = false;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.name == "Player" && Input.GetKeyUp (KeyCode.K) )
		{
				dMan.ShowBox (dialogue);			
			
		} 
			
	}
}
