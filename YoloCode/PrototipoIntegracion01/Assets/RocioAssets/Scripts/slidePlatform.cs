using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidePlatform : MonoBehaviour {
	public Player player;
	public float slideValue;

	// Use this for initialization
	void Start () {
		slideValue = slideValue;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log ("choco");
		if (other.tag == "Player") {
			//Debug.Log("toco al player");
			slide(slideValue);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
			noSlide(slideValue);
		}
	}

	private void slide(float value)
	{
		player.setHorizontalSpeed(value);
	}

	private void noSlide(float value)
	{
		player.setHorizontalSpeed(5f);
	}


}
