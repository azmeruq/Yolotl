using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalagmite : MonoBehaviour {
	public float speed;
	private bool isActived;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private BoxCollider2D box2D;
	private Vector3 initialPos;
	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		box2D = GetComponent<BoxCollider2D> ();
		isActived = false;
		initialPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		if(isActived){
			rb.velocity = new Vector2(0f, speed);
		}
	}

	public void SetIsActived(){
		isActived = true;
	}

	public void ReSet(){
		sr.enabled = true;
		box2D.enabled = true;
		transform.position = initialPos;
		isActived = false;
		//rb.velocity = new Vector2(0f, speed);
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Player")||other.gameObject.CompareTag ("Ground")) {
			SFXCtrl.instance.ShowEnemyExplosion (transform.position);
			sr.enabled = false;
			box2D.enabled = false;
			rb.velocity = new Vector2(0f, 0f);
			//Destroy (gameObject);
		}
	}
}

