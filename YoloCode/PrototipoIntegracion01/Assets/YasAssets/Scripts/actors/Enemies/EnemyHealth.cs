using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the health and Damage of a enemy, how those amounts changes
/// and also makes and explosion when the enemy dies
/// </summary>

public class EnemyHealth : MonoBehaviour { 
	[Tooltip("Float value, than represents the max health value")]
	public float maxHealth;
	private float healthAmount;
	[Tooltip("Float value, than represents the max damage value")]
	public float damageAmount;
	//private SpriteRenderer sr;
	private bool isAlive;
	//private GameObject player;

	// Use this for initialization
	void Start () {
		//sr = GetComponent<SpriteRenderer> ();
		healthAmount = maxHealth;
		//Debug.Log ("MaxHealth enemy" + maxHealth);
		//Debug.Log ("MaxDamage Enemy" + damageAmount);
		//player = GameObject.FindWithTag("Player");
		isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (healthAmount);
		//Debug.Log ((player.GetComponent <Player>()).GetIsAlive());
		/*if ((!((player.GetComponent <Player>()).GetIsAlive())) && healthAmount==0f) {
			HanddleDead ();
		}*/
	}

	public void SetHealth(float value){
		
		healthAmount = Mathf.Clamp (healthAmount-value, 0f, maxHealth);
		//healthAmount = healthAmount - value;
		if (healthAmount == 0f){
			//Destroy(gameObject);
			isAlive = false;
			SFXCtrl.instance.ShowEnemyExplosion (transform.position);
			//EnemyDies ();

			
		}
	}

	public bool GetIsAlive(){
		return isAlive;
	}

	public float GetDamage(){
		return damageAmount;
	}

	public void SetDamage(float damage){
		damageAmount = damage;
	}

	/*public void EnemyDies(){
		//isAlive = false;
		gameObject.SetActive (false);
		//Debug.Log (isAlive);
	}
	

	public void SetFlipX(bool value){
		sr.flipX = value;
	}*/

	public void HanddleDead(){
		healthAmount = maxHealth;
		isAlive = true;
		//Debug.Log (healthAmount);

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
