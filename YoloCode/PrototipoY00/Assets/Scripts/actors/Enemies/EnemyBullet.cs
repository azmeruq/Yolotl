using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
	public float horizontalSpeed;
	private Rigidbody2D rb;
	//private Player jugador;
	private float timeForDestroying;
	public float damageAmount;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		//jugador = FindObjectOfType<Player> ();
		//AsignarVelocidad ();
	}

	public float getDamage(){
		return damageAmount;
	}

	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			other.SendMessage("SetHealth", damageAmount);
			other.SendMessage ("EnemyKnockBack", transform.position.x);
			Destroy (gameObject);
		}else if(other.gameObject.CompareTag ("FlipCtrl")){
			
		} else if ((!other.gameObject.CompareTag ("Enemy")&&!other.gameObject.CompareTag ("EnemyAttack"))&&(!other.gameObject.CompareTag ("Camera"))) {
			Destroy (gameObject);
		}

		//Debug.Log ("Col");
	}
}
