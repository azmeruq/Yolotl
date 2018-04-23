using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scratchGround : MonoBehaviour {
	private Transform thisTransform;
	//public Player player;
	//public Collider2D isCollider;
	private BoxCollider2D coll;
	private CircleCollider2D isCollider;

	// Use this for initialization
	void Start () {
		//player = FindObjectOfType<Player> ();
		coll = GetComponent<BoxCollider2D> ();
		isCollider = GetComponent<CircleCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void desaparecer(){
		//Debug.Log ("voy a desaparecer");
		if(coll.isTrigger == false){
			StartCoroutine(activarTrigger());

			StartCoroutine(desactivarTrigger());
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log ("choco");
		if (other.tag == "Player") {
			//Debug.Log("toco al player");
			desaparecer ();
		}
	}

	IEnumerator desactivarTrigger(){
		//print(Time.time + "segundo");
		yield return new WaitForSeconds(3);
		//print(Time.time + "segundo");

		coll.isTrigger = false;
		//Debug.Log("trigger es falso");
	}


	IEnumerator activarTrigger(){
		//print(Time.time + "segundo");
		yield return new WaitForSeconds(1);
		//print(Time.time + "segundo");

		coll.isTrigger = true;
		//Debug.Log ("trigger es verdadero");
	}

}
