using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMagicShot : MonoBehaviour {

	[Tooltip("Float value, than represents the max health value")]
	public float maxHealth;
	private float healthAmount;
	[Tooltip("Float value, than represents the max magic value")]
	public float damageMagicAmount;
	public float speed;
	private GameObject player;
	private SpriteRenderer sr;
	public float timeDelay;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		healthAmount = maxHealth;
		sr = GetComponent<SpriteRenderer> ();
		Invoke ("DestroyWithDelay", timeDelay);
	}

	// Update is called once per frame
	void Update () {
		Move ();
		SetFlipX ();
	}

	public void SetHealth(float value){

		healthAmount = Mathf.Clamp (healthAmount-value, 0f, maxHealth);
		if (healthAmount == 0f){
			SFXCtrl.instance.ShowEnemyExplosion (transform.position);
			Destroy(gameObject);
		}
	}

	public void Move (){
		Vector3 target = player.transform.position;
		float fixedSpeed = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target, fixedSpeed);
	}

	public void DestroyWithDelay(){
		SFXCtrl.instance.ShowEnemyExplosion (transform.position);
		Destroy (gameObject);
	}

	public void SetFlipX (){
		if (Mathf.Sign (transform.position.x - player.transform.position.x) == 1)
			sr.flipX = false;
		else if (Mathf.Sign (transform.position.x - player.transform.position.x) == -1)
			sr.flipX = true;
	}
		

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			other.SendMessage("SetTonalli", -damageMagicAmount);
			other.SendMessage ("EnemyKnockBack", transform.position.x);
			SFXCtrl.instance.ShowEnemyExplosion (transform.position);
			Destroy (gameObject);
		} else if ((!other.gameObject.CompareTag ("Enemy")&&!other.gameObject.CompareTag ("Camera"))&&(!other.gameObject.CompareTag ("EnemyAttack")&& !other.gameObject.CompareTag ("Ground"))) {
			Destroy (gameObject);
		}

	}
}
