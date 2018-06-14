using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windCreator : MonoBehaviour {
	public GameObject wind;
	public float activeTime;
	public float delayTime;
	public float desactiveTime;
	private bool isActiveTime;
	private bool isActive;
	private bool canCreateWind;

	// Use this for initialization
	void Start () {
		isActiveTime= false;
		canCreateWind = true;
		isActive = true;
		isActive = false;

	}
	
	// Update is called once per frame
	void Update () {
		//Raycasting ();
		if (isActive) {
			if (isActiveTime) {
				//if (canCreateWind)
				createWind();
			} else {
				Invoke ("setEnable", desactiveTime);
			}
		}
	}

	public void setDisable(){
		isActiveTime = false;
	}

	public void setEnable(){
		isActiveTime = true;
	}

	public void EnablebleWindCreation(){
		canCreateWind = true;
	}

	public void SetIsActive(bool value){
		isActive = value;
	}

	public void createWind(){
		if (canCreateWind) {
			canCreateWind = false;
			Instantiate (wind, transform.position, Quaternion.identity);
			Invoke ("EnablebleWindCreation", delayTime);
			Invoke ("setDisable", activeTime);
		}
	
	}
		

}
