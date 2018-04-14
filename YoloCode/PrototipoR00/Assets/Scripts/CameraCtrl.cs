using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {

	public Transform player;
	private float yOffset = 0f;
	// Use this for initialization
	public bool moveH;
	public bool moveV;
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (moveH) {
			MoveCameraHorizontal ();
		}

		if (moveV) {
			MoveCameraVertical ();
		}
	


	}

	public void MoveCameraHorizontal(){
		transform.position = new Vector3 (player.position.x, transform.position.y+ yOffset,transform.position.z);
	}

	public void MoveCameraVertical(){
		transform.position = new Vector3 (transform.position.x, player.position.y+ yOffset,transform.position.z);
	}


}
