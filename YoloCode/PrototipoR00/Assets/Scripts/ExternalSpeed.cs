using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalSpeed : MonoBehaviour {

	private Player player;
	public float speed; 
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			//player.setExternalSpeed (speed);
		}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			//player.setExternalSpeed (0f);
		}

	}


}
