using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {

	public Player player;
	public GameObject symbol;
	public int idDialogue;
	//public Text dText;
	//necesitamos al manejador de dialogo
	private DialogueManager dMan;

	//public string dialogue;
	//public bool dialogueActivated;
//	public bool playerIsCloseToTalk;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		dMan = FindObjectOfType<DialogueManager> ();

		//setDialogue (dialogue);
		//dialogue = " ";
		//dialogueActivated = false;
	//	setPlayerIsCloseToTalk(false);
		//playerIsCloseToTalk = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*
	void setDialogue(string dia){
		dialogue = dia;
	}

	string getDialogue(){
		return dialogue;
	}
	*/

	/*
	public void setPlayerIsCloseToTalk(bool what){
		playerIsCloseToTalk = what;
	}

	public bool getPlayerIsCloseToTalk(){
		return playerIsCloseToTalk;
	}
	*/

	void showSymbol(){
		 // Activar simbolo sobre cabeza de NPC
		symbol.SetActive (true);
	}

	void hideSymbol(){
		 // Desactivar simbolo sobre cabeza de NPC
		symbol.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player" )
		{
			showSymbol();

			//Debug.Log("SI puede activar el dialogo");
			//playerIsCloseToTalk = true;
			dMan.setPlayerIsCloseToTalk(true);
			//dMan.setActualDialogue(getDialogue());
			dMan.setActualDialogue(idDialogue);
			player.setIsTalking (true);
		} 
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.name == "Player" )
		{
			hideSymbol ();
			//playerIsCloseToTalk = false;
			dMan.setPlayerIsCloseToTalk(false);
			player.setIsTalking (false);
			//Debug.Log("NO puede activar el dialogo");
		} 
	}


}
