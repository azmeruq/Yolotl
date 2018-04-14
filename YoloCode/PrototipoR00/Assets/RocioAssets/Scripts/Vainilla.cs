using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vainilla : MonoBehaviour {

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
			player.setMana (player.getMana () + 15);
			Destroy (this.gameObject);
		} 
	}
}
