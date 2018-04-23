using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	private Player player;
	private int health;
	//public bool distroyOther;
	//public GameObject toDistroy;

	void Start () {
		
		player = FindObjectOfType<Player> ();

		setHealth(10);
	}


	public void setHealth(int what)
	{
		health = what;
	}

	public int getHealth()
	{
		return health;
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Tonalli") {
			this.setHealth (this.getHealth () - 1);
		} else if (other.name == "Player") {
			player.setHealth (player.getHealth () - 2);
		} 
	}
}
