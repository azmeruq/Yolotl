using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour {
	public GameObject enemy_shot;
	public Transform LaunchPoint;
	public float waitBetweenShots;
	private float shotCounter;

	// Use this for initialization
	void Start () {
		shotCounter = waitBetweenShots;
		
	}
	
	// Update is called once per frame
	void Update () {
		shotCounter -= Time.deltaTime;
		if (shotCounter < 0) 
		{
			Instantiate(enemy_shot, LaunchPoint.position, LaunchPoint.rotation);
			shotCounter = waitBetweenShots;
		}

	}
}
