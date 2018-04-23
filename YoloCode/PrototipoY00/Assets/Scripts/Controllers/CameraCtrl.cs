using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {

	public Transform player;
	public float yOffset;
	private bool CanMove;

	// Use this for initialization
	void Start () {
		//yOffset = 1f;
	}

	// Update is called once per frame
	void Update () {
		checkPlayer ();
		//player.position.y+ yOffset
		//CheckPosition();
		if (CanMove) {
			MoveCameraHorizontal ();
			MoveCameraVertical ();
		} 



	}

	public void MoveCameraHorizontal(){
		transform.position = new Vector3 (player.position.x, player.position.y+ yOffset,transform.position.z);
	}

	public void MoveCameraVertical(){
		transform.position = new Vector3 (transform.position.x, player.position.y+ yOffset,transform.position.z);
	}

	public void checkPlayer(){
		if (player.GetComponent<PlayerManager> ().GetIsAlive ()) {
			CanMove = true;
		} else {
			CanMove = false;
		}

	}

	/*public void CheckPosition(){
		
		if (player.position.x - Mathf.Abs (limitLeft.position.x) > -7.52) {
			CanMove = true;
		}
	}*/

	/*void OnTriggerStay2D(Collider2D other){
		//Debug.Log ("posicion player"+ limitLeft.position.x );
		if (other.gameObject.CompareTag ("Limit")) {
			//limit = other.gameObject.transform ;
			Debug.Log ("colission");
			CanMove = false;
			MoveCameraVertical ();
		}
	}*/
	

}
