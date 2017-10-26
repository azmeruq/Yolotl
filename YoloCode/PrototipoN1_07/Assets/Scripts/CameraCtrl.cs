using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {

	public Transform player;
	public Transform limitLeft;
	public Transform limitRight;
	private float yOffset = 0f;
	private bool CanMove;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//player.position.y+ yOffset
		//CheckPosition();

		MoveCameraHorizontal ();
		/*
		if (CanMove) {
			MoveCameraHorizontal ();
		} /*else {
			MoveCameraVertical ();
		}*/
	


	}

	public void MoveCameraHorizontal(){
		transform.position = new Vector3 (player.position.x, transform.position.y+ yOffset,transform.position.z);
	}

	public void MoveCameraVertical(){
		transform.position = new Vector3 (transform.position.x, player.position.y+ yOffset,transform.position.z);
	}

	/*
	public void CheckPosition(){
		
		if (player.position.x - Mathf.Abs (limitLeft.position.x) > -7.52) {
			CanMove = true;
		}
	}
	*/

	/*
	void OnTriggerStay2D(Collider2D other){
		//Debug.Log ("posicion player"+ limitLeft.position.x );
		if (other.gameObject.CompareTag ("Limit")) {
			//limit = other.gameObject.transform ;
			Debug.Log ("colission");
			CanMove = false;
			MoveCameraVertical ();
		}		
	}*/
	

}
