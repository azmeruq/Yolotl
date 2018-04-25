using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level04Ctrl : MonoBehaviour {
	[Tooltip("This GameObject is Complete Level panel from the GUI")]
	public GameObject completeLevelpanel;
	[Tooltip("This GameObject is player botons panel from the GUI")]
	public GameObject playerGUI;

	void Start () {
		//Enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		//player = (GameObject.FindWithTag("Player")).GetComponent <Player>();
	}
	
	// Update is called once per frame
	void Update () {
		//if (!player.GetIsAlive ()) {
			
		//}
	}

	void OnEnable(){
		//GameDataCtrl.instance.SaveData (60f, 40f, 5f, 0, 7);
		GameDataCtrl.instance.LoadData ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) { 
			Debug.Log (other.gameObject.GetComponent<PlayerManager>().GetScore());
			if(other.gameObject.GetComponent<PlayerManager>().GetScore()== 4){
				GameDataCtrl.instance.SaveData (60f, 40f, 5f, 0, 7);
				Invoke("ShowLevelCompletePanel", 1.2f);
			}

		}
	}

	/// <summary>
	/// Shows the level complete panel.
	/// </summary>
	public void ShowLevelCompletePanel(){
		playerGUI.SetActive(false);
		completeLevelpanel.SetActive (true);
	}
}
