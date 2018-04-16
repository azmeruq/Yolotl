using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
	public float horizontalSpeed;
	private Rigidbody2D rb;
	//private Player jugador;
	private float timeForDestroying;
	public float damageAmount;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		//damageAmount = 5f;
		damageAmount = (GameDataCtrl.instance.GetGameData ()).GetDamageAmount ();
		if(damageAmount==0f){
			damageAmount = 5f;
		}
		Debug.Log ("Damage amount Player" + damageAmount);
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
		if ((other.gameObject.CompareTag ("Enemy")||other.gameObject.CompareTag ("Obstacle"))||(other.gameObject.CompareTag ("EnemyShell"))) {
			//Debug.Log ("EnemyCol");
			other.SendMessage ("SetHealth", damageAmount);
			Destroy (gameObject);
		} else if ((!other.gameObject.CompareTag ("Player")&&!other.gameObject.CompareTag ("Camera"))&&(!other.gameObject.CompareTag ("Checkpoint"))) {
			Destroy (gameObject);
		}

		//Debug.Log ("Col");
	}

	/*public void AsignarVelocidad(){
		if(jugador.GetIsFacingRight()){
			horizontalSpeed = 7f;
		}else{
			horizontalSpeed = -7f;
		}
	}*/
}
