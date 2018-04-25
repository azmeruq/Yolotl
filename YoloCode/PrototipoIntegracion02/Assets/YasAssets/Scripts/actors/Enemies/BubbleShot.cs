using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShot : MonoBehaviour {

	//public float healthAmount;
	//public float damageAmount;
	public float speed;
	private GameObject player;
	private EnemyHealth enemy;
	private SpriteRenderer sr;
	public float timeDelay;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		enemy = GetComponent <EnemyHealth> ();
		sr = GetComponent<SpriteRenderer> ();
		Invoke ("DestroyWithDelay", timeDelay);
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		isAlive ();
		SetFlipX ();
	}

	public void isAlive(){
		if (!enemy.GetIsAlive ()) {
			Destroy (gameObject);
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
			SFXCtrl.instance.ShowEnemyExplosion (transform.position);
			Destroy (gameObject);
		}else if ((!other.gameObject.CompareTag ("Enemy")&&!other.gameObject.CompareTag ("Camera"))&&(!other.gameObject.CompareTag ("EnemyAttack")&& !other.gameObject.CompareTag ("Ground"))) {
			Destroy (gameObject);
		}
	}
		
}
