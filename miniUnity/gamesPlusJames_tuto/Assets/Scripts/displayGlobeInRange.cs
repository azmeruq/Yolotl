using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayGlobeInRange : MonoBehaviour {

	public PlayerController player;
	public float playerRange;
	public GameObject globe;
	public bool globeActive;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine (new Vector3 (transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3 (transform.position.x + playerRange, transform.position.y, transform.position.z));

		if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange) 
		{
			
		} 
		if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange) 
		{

		} 
			
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") 
		{
			globe.SetActive (true);
			globeActive = true;
		} 
	}

}
