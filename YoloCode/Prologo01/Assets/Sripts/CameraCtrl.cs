using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {
	public Transform player;
	public float yOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//player.position.y+ yOffset
		transform.position = new Vector3 (player.position.x, transform.position.y,transform.position.z);
	}
}
