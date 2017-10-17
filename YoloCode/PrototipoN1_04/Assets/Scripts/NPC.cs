using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

	private string dialogue;
	private bool dialogueActivated;
	private bool playerIsClose;

	// Use this for initialization
	void Start () {
		dialogue = " ";
		dialogueActivated = false;
		playerIsClose = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void setDialogue(string dialogue){
		dialogue = dialogue;
	}

	string getDialogue(){
		return dialogue;
	}

	void showSymbol(){
		/*
		 * Activar simbolo sobre cabeza de NPC
		*/
	}

	void hideSymbol(){
		/*
		 *  Desactivar simbolo sobre cabeza de NPC
		*/
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player" )
		{
			hideSymbol();
		} 
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.name == "Player" )
		{
			dialogueActivated = true;
			showSymbol ();
		} 
	}


}
