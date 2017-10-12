using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {

	public Transform player;
	private float yOffset = 1f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//player.position.y+ yOffset
		transform.position = new Vector3 (player.position.x, player.position.y+ yOffset,transform.position.z);
	}
}
