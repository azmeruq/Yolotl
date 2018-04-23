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
		//dMan = FindObjectOfType<DialogueManager> ();

	}


	void Update () {
	}

	/*void OnTriggerStay2D(Collider2D other)
	{
		dMan = FindObjectOfType<DialogueManager> ();
		if (other.gameObject.name == "Player" )
		{
			dMan.ShowBox(dialogue);			

		} 

	}*/
}