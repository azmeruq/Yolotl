using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUBCtrl : MonoBehaviour {
	public static HUBCtrl instance;
	public Text textObjetive;
	public Text textSecondObjetive;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpDateDogScore(int score){
		textObjetive.text = "x " + score;
		// 11f is the total amount of the Xolos
		float XochitonalPower = 1f + (((float)score)/11f);
		XochitonalPower = Mathf.Round (XochitonalPower * 100f) / 100f;
		textSecondObjetive.text = "x" + XochitonalPower;
	}

	public void UpDateKeys(int score){
		textObjetive.text = "x " + score + "/4";
	}
		
}
