using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueCtrl : MonoBehaviour
{
	private Queue<string> sentences;
	private int indexDialoguesCtrl;
	private string concurrentName;
	public float timeDelayBetweenScenes;
	public string nextNameScene;

	[Tooltip("UI text object where the character name will be displayed")]
	public Text nameText;
	[Tooltip("UI text object where the character dialogue will be displayed")]
	public Text dialogueText;

	void Start ()
	{
		sentences = new Queue<string> ();
		indexDialoguesCtrl = 0;
	}

	public void StartDialogues(Dialogues dialogues){
		//dialogues.printDialogues ();
		//Debug.Log ("Start Conversation with: " + dialogues.GetDialogue(0).name + dialogues.GetDialogue(0).dialogues[0]);
		StartDialogue (dialogues.GetDialogue(0));
		DisplayNextDialogue (dialogues);
	}

	public void StartDialogue(Dialogue dialogue){
		sentences.Clear ();
		//concurrentName = dialogue.name;
		//nameText.text = concurrentName;
		nameText.text = dialogue.name;
		foreach (string sentence in dialogue.dialogues) {
			sentences.Enqueue (sentence);
		}
		indexDialoguesCtrl++;
	}

	public void DisplayNextDialogue (Dialogues dialogues){
		if (sentences.Count == 0 && indexDialoguesCtrl > dialogues.dialogues.Count - 1) {
			EndDialogue ();
			return;
		} else if(sentences.Count == 0){
			StartDialogue (dialogues.GetDialogue (indexDialoguesCtrl));
		} 

		//string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentences(sentences.Dequeue ()));
		//dialogueText.text = sentence;
		//Debug.Log (concurrentName);
		//Debug.Log (sentence);
	}

	public void EndDialogue (){
		//Debug.Log ("End of conversation");
		Invoke("GoToNextScene", timeDelayBetweenScenes);
	}
	
	IEnumerator TypeSentences(string sentences){
		dialogueText.text = "";
		foreach(char letter in sentences.ToCharArray()){
			dialogueText.text += letter;
			yield return null;
		}
	}

	public void GoToNextScene(){
		SceneManager.LoadScene (nextNameScene);
	}
}

