using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private Player player;
	public GameObject toDistroy;
	public bool distroyOther;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
			player.setHealth (player.getHealth () - 1);
		} else if (other.tag == "Tonalli") {
			if (distroyOther) {
				Destroy (toDistroy);
			} else {
				Destroy (this.gameObject);
			}
		}
	}
}
