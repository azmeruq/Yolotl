using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacao : MonoBehaviour {
	private Player player;
	// Use this for initialization
	void Start () {
		player  = FindObjectOfType<Player> ();

	}

	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
			player.setHealth (player.getHealth () + 1);
			Destroy (this.gameObject);
		} 
	}
}
