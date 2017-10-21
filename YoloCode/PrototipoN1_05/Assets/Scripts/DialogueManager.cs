using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ADMINISTRADOR DE DIALOGO
//se encarga de activar o desactivar el cuadro de texto
//segun condicion de activacion y tecleo

public class DialogueManager : MonoBehaviour {

	//variable de caja de texto
	public GameObject dBox;
	//variable de texto
	public Text dText;
	public bool dialogueActivated;
	private string dialogue;
	public bool playerIsCloseToTalk;

	//para averiguar si el player esta cerca de un NPC
	//private NPC npc;

	void Start () {
		setActualDialogue (" ");
		//instanciamos npc
		//npc = FindObjectOfType<NPC>();
		setPlayerIsCloseToTalk(false);
	}

	public void setPlayerIsCloseToTalk(bool what){
		playerIsCloseToTalk = what;
	}

	public bool getPlayerIsCloseToTalk(){
		return playerIsCloseToTalk;
	}

	public void setActualDialogue(string dia)
	{
		dialogue = dia; 
	}

	public string getActualDialogue()
	{
		return dialogue; 
	}

	public void ShowBox()
	{
		//se escribe lo que se haya mandado
		Debug.Log (getActualDialogue());
		dText.text = getActualDialogue();
		//se activa el cuadro de texto y la variable de activacion es verdadera para el contador
		dialogueActivated = true;
		//se activa cuadro de dialogo
		dBox.SetActive (true);

	}

	public void HideBox()
	{
		//se desactiva cuadro de dialogo
		dBox.SetActive (false);
	}
}
