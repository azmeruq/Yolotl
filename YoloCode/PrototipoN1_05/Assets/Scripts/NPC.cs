using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {

	public Player player;
	public GameObject symbol;
	//public Text dText;

	public string dialogue;
	public bool dialogueActivated;
	public bool playerIsClose;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		setDialogue (dialogue);
		//dialogue = " ";
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
		symbol.SetActive (true);
	}

	void hideSymbol(){
		/*
		 *  Desactivar simbolo sobre cabeza de NPC
		*/
		symbol.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player" )
		{
			showSymbol();
			Debug.LogError("se puede activar mi dialogo");
		} 
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.name == "Player" )
		{
			//dialogueActivated = true;

			hideSymbol ();
		} 
	}


}
