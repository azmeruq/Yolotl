using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

//ADMINISTRADOR DE DIALOGO
//se encarga de activar o desactivar el cuadro de texto
//segun condicion de activacion y tecleo

public class DialogueManager : MonoBehaviour {

	//variable de caja de texto
	public GameObject dBox;
	//variable de texto
	public Text dText;
	private bool dialogueActivated;
	private string dialogue;
	public bool playerIsCloseToTalk;
	private string[] dialogueLine;
	private MobileUICtrl mob;
	private Player player;
	public GameObject buttonUp;
	public GameObject buttonLeft;
	public GameObject buttonRight;

	private int contador = 0;

	//para averiguar si el player esta cerca de un NPC
	//private NPC npc;

	void Start () {
		player = FindObjectOfType<Player> ();
		mob = FindObjectOfType<MobileUICtrl> ();
		//setActualDialogue (" ");
		setDialogueActivated (false);
		//instanciamos npc
		//npc = FindObjectOfType<NPC>();
		setPlayerIsCloseToTalk(false);
		dialogueLine = File.ReadAllLines ("Assets/Files/file.txt",Encoding.Default);
	}

	void Update () {

		if (Input.GetKeyDown (KeyCode.Space) && (getPlayerIsCloseToTalk () == true) ) 
		{
			if (getDialogueActivated () == false) {
				ShowBox ();
				player.setHorizontalSpeed (0f);
			}else {
				HideBox ();
				player.setHorizontalSpeed (5f);
			}
		}  

		if (mob.getShotPressed () == true && (getPlayerIsCloseToTalk () == true)) {
			if (getDialogueActivated () == false) {
				ShowBox ();
				//player.setHorizontalSpeed (0f);
				//player.setVerticalSpeed (0f);
				//buttonUp.GetComponent<Button>().enabled = false;
				buttonUp.SetActive(false);
				buttonLeft.SetActive(false);
				buttonRight.SetActive(false);

			}else {
				HideBox ();
				//player.setHorizontalSpeed (5f);
				//player.setVerticalSpeed (600f);
				//buttonUp.GetComponent<Button>().enabled = true;
				//buttonUp.GetComponent<Button>().interactable = true;
				buttonUp.SetActive(true);
				buttonLeft.SetActive(true);
				buttonRight.SetActive(true);
				contador++;

			}
		}
	}

	public void setPlayerIsCloseToTalk(bool what){
		playerIsCloseToTalk = what;
	}

	public bool getPlayerIsCloseToTalk(){
		return playerIsCloseToTalk;
	}

	public void setDialogueActivated(bool what){
		dialogueActivated = what;
	}

	public bool getDialogueActivated(){
		return dialogueActivated;
	}
	/*
	public void setActualDialogue(int idDialogo)
	{
		dialogue = dialogueLine[idDialogo-1]; 
	}

	public string getActualDialogue()
	{
		return dialogue; 
	}*/

	public void setActualDialogue(string dia)
	{
		//dialogue = dialogueLine[idDialogo-1]; 
		dialogue = dia;
	}

	public string getActualDialogue()
	{
		return dialogue; 
	}


	public void ShowBox()
	{
		//se escribe lo que se haya mandado
		//Debug.Log (getActualDialogue());
		dText.text = getActualDialogue();
		//se activa el cuadro de texto y la variable de activacion es verdadera para el contador
		//dialogueActivated = true;
		setDialogueActivated (true);
		//se activa cuadro de dialogo
		dBox.SetActive (true);

	}

	public void HideBox()
	{
		//Debug.Log ("entre al hideBox");
		setDialogueActivated (false);
		//se desactiva cuadro de dialogo
		dBox.SetActive (false);

	}

	public void setContador(int what){
		contador = what;
	}

	public int getContador(){
		return contador;
	}


}
