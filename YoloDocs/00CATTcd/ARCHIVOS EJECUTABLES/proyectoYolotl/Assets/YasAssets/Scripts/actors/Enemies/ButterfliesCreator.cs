using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterfliesCreator : MonoBehaviour {
	public GameObject butterfly;
	public float activeTime;
	public float delayTime;
	private bool isActive;
	private bool canCreateButterflies;
	//private bool isActiveTime;


	// Use this for initialization
	void Start () {
		isActive = false;
		canCreateButterflies = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			CreateButterflies ();
		} 
	}

	public void CreateButterflies(){
		if (canCreateButterflies) {
			Instantiate (butterfly, transform.position, Quaternion.identity);
			canCreateButterflies = false;
			Invoke ("EnablebleWindCreation", delayTime);
			Invoke ("setDisable", activeTime);
		}
	}

	public void setDisable(){
		isActive = false;
	}

	public void EnablebleWindCreation(){
		canCreateButterflies = true;
	}
		
	//public void

	public void SetIsActive(bool value){
		isActive = value;
	}
}
