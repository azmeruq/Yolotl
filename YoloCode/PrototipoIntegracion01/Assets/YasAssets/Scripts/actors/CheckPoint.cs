using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows a Player to appear in a certain position after dying.
/// </summary>


public class CheckPoint : MonoBehaviour {
	private Animator anim;
	public bool isActive;
	public static GameObject[] checkPointsList;
	// Use this for initialization
	void Start () {
		//CheckPointList = (GameObject.FindWithTag ("Checkpoint")).GetComponentsInChildren<CheckPoint>();
		anim = GetComponent<Animator> ();
		checkPointsList = GameObject.FindGameObjectsWithTag ("Checkpoint");
	}

	private void ActivateCheckPoint(){
		foreach (GameObject cp in checkPointsList) {
			cp.GetComponent <CheckPoint> ().setIsActive (false);
		}
		isActive = true;
	} 

	private void setIsActive(bool value){
		isActive = value;	
	}

	private bool getIsActive(){
		return isActive;
	}

	public static Vector3 GetActivePosition(){
		Vector3 activePosition = new Vector3 (0f, 0f, 0f); 
		if (checkPointsList != null) {
			foreach (GameObject cp in checkPointsList) {
				if(cp.GetComponent <CheckPoint> ().getIsActive()){
					activePosition = cp.transform.position;
					break;
				}
			}
		} 
		return activePosition;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			anim.SetInteger ("state", 1);
			ActivateCheckPoint ();
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			anim.SetInteger ("state", 0);
		}
	}
}
