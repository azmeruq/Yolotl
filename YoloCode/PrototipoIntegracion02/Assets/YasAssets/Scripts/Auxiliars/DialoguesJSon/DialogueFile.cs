using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;


public class DialogueFile : MonoBehaviour
{
	string filePath;
	string jsonString;
	[Tooltip("String value, this is the name of the file of the scene dialogues")]
	public string fileJasonName;
	public Dialogues dialogues;
	private bool firstDialogueDisplayed;

	void Awake(){
		//filePath = Path.Combine (Application.streamingAssetsPath, "/Scripts/Auxiliars/DialoguesJSon/" + fileJasonName);

		// for android
		/*if (Application.platform == RuntimePlatform.Android) {
			// Android
			filePath = Path.Combine (Application.streamingAssetsPath, "/Scripts/Auxiliars/DialoguesJSon/" + fileJasonName);
			WWW reader = new WWW(filePath);
			while (!reader.isDone) { }

			jsonString= reader.text;
		} else {
			filePath = Application.dataPath + "/Scripts/Auxiliars/DialoguesJSon/" + fileJasonName;
			jsonString = File.ReadAllText (filePath);
		}

		dialogues = JsonUtility.FromJson<Dialogues> (jsonString);*/
		firstDialogueDisplayed = false;
		//dialogues.printDialogues ();

	}

	void Update () {
		if (!firstDialogueDisplayed) {
			FindObjectOfType<DialogueCtrl> ().StartDialogues (dialogues);
			firstDialogueDisplayed =  true;
		}
	}

	public void TriggerDialogues(){
		FindObjectOfType<DialogueCtrl> ().DisplayNextDialogue (dialogues);
		/*if (!firstDialogueDisplayed) {
			FindObjectOfType<DialogueCtrl> ().StartDialogues (dialogues);
			firstDialogueDisplayed =  true;
		} else {
			FindObjectOfType<DialogueCtrl> ().DisplayNextDialogue (dialogues);
		}*/
	}

	public Dialogues GetDialogues(){
		return dialogues;
	}

}

[System.Serializable]
public class Dialogue{
	public string name;
	public List<string> dialogues;

	public override string ToString ()
	{
		return string.Format ("{0} : {1}", name, dialogues);
	}
}

[System.Serializable]
public class Dialogues{
	public List<Dialogue> dialogues;

	public void printDialogues(){
		foreach (Dialogue dialogue in dialogues) {
			Debug.Log (dialogue.name);
			Debug.Log (dialogue.dialogues [0]);
		}
	}

	public Dialogue GetDialogue(int index){
		return	dialogues [index];
	}
}
