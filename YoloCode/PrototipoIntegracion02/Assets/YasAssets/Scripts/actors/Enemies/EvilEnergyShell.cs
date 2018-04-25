using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEnergyShell : MonoBehaviour {
	private float maxHealth;
	public float healthAmount;
	private bool isAlive;
	public float damageAmount;

	private SpriteRenderer sr;
	private CircleCollider2D circle2D;

	// Use this for initialization
	void Start () {
		isAlive = true;
		maxHealth = healthAmount;
		sr = GetComponent <SpriteRenderer> ();
		circle2D = GetComponent <CircleCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetHealth(float value){

		healthAmount = Mathf.Clamp (healthAmount-value, 0f, maxHealth);
		//healthAmount = healthAmount - value;
		if (healthAmount == 0f){
			//Destroy(gameObject);
			isAlive = false;
			SFXCtrl.instance.ShowEnemyExplosion (transform.position);
			sr.enabled = false;
			circle2D.enabled = false;
			//EnemyDies ();


		}
	}

	public bool GetIsAlive(){
		return isAlive;
	}
		
	public void SetInActive(){
		isAlive = false;
		sr.enabled = false;
		circle2D.enabled = false;
	}

	public void HanddleDead(){
		healthAmount = maxHealth;
		isAlive = true;
		sr.enabled = true;
		circle2D.enabled = true;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			other.SendMessage("SetHealth", damageAmount);
			other.SendMessage ("EnemyKnockBack", transform.position.x);
			//Destroy (gameObject);
		}

		//Debug.Log ("Col");
	}
}
