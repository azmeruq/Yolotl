using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//MANTENER DIALOGO
//

public class Dialoguer : MonoBehaviour {

	//variable del texto a escribir en el cuadro 
	public string dialogue;
	//objeto de DIALOGUEMANAGER
	private DialogueManager dMan;

	//objeto PLAYERCONTROLLER, player
	public Player player;


	void Start () {
		//asignamos el objeto DIALOGUEMANAGER a dMan
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.name == "Player" )
		{
			dMan = FindObjectOfType<DialogueManager> ();
			dMan.ShowBox (dialogue);	
		} 

	}

	void OnTriggerExit2D(Collider2D other)
	{

		if (other.gameObject.name == "Player" )
		{
			dMan = FindObjectOfType<DialogueManager> ();
			dMan.HideBox ();	
		} 

	}
}