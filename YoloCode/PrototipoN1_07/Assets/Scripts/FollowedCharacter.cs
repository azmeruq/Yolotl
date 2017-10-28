using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowedCharacter : MonoBehaviour {
	private Transform playerPosition;
	private Transform characterPosition;
	private Animator characterAnimator;
	private GameObject[] wayPoints;
	//private int sizeWayPoints;
	int controlWayPoints;

	// Use this for initialization
	void Start () {
		playerPosition = (GameObject.FindWithTag("Player")).GetComponent <Transform>();
		characterPosition = GetComponent <Transform> ();
		characterAnimator = GetComponent <Animator> ();
		wayPoints = GameObject.FindGameObjectsWithTag("XolotlJump");
		//sizeWayPoints = wayPoints.Length;
		controlWayPoints = wayPoints.Length -1;
		//nextPosXLim = ;
		//Debug.Log (sizeWayPoints);

	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(characterPosition.position.x - playerPosition.position.x) <= 12.258f) {
			if (characterPosition.position == wayPoints [controlWayPoints].GetComponent<Transform> ().position) {
				upDateControlWayPoints ();
			}
			MoveCharacterHorizontal ();
			
		} else {
			stopMoving ();
		}
	}

	public void MoveCharacterHorizontal(){
		characterAnimator.SetInteger ("State", 1);
		//characterRD.velocity = new Vector2(5.0f, characterRD.velocity.y);
		transform.position = Vector3.MoveTowards(transform.position, wayPoints [controlWayPoints].GetComponent<Transform> ().position, 5.0f*Time.deltaTime);
	}

	public void stopMoving(){
		//characterRD.velocity = new Vector2(0f, characterRD.velocity.y);
		characterAnimator.SetInteger ("State", 0);
	}
		
	public void upDateControlWayPoints (){
		if (controlWayPoints > 0) 
			controlWayPoints --;
	}
		
}
