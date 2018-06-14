using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObstacle : MonoBehaviour {
	public float maxHealth;
	private float healthAmount;
	public float damageAmount;
	public float horizontalSpeed;
	public float verticalSpeed;
	private Rigidbody2D rb;

	//private GameObject player;
	//public float timeDelay;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		healthAmount = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	public void SetHealth(float value){
		//Debug.Log (healtAmount);
		healthAmount = Mathf.Clamp (healthAmount-value, 0f, maxHealth);
		if (healthAmount == 0) {
			SFXCtrl.instance.ShowEnemyExplosion (transform.position);
			Destroy (gameObject);
		}
	} 

	public void Move(){
		rb.velocity = new Vector2(horizontalSpeed, verticalSpeed);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")||other.gameObject.CompareTag ("Ground")) {
			other.SendMessage("SetHealth", damageAmount);
			other.SendMessage ("EnemyKnockBack", transform.position.x);
			SFXCtrl.instance.ShowEnemyExplosion (transform.position);
			Destroy (gameObject);
		}
	}
		
}
