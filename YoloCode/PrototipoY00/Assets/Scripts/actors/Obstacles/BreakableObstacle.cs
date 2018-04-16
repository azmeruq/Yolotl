using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObstacle : MonoBehaviour {
	public float maxHealth;
	private float healthAmount;
	public float speed;
	public Transform pos1, pos02;
	//private Vector3 initialPos;
	private bool spoted;
	Vector3 initialPosition;
	[Tooltip("float value. This value represnts the position where the bullet will be created when the enemy shoots")]
	public float visionRadius;
	private GameObject player;
	private Vector3 nextPos;

	//private GameObject player;
	//public float timeDelay;
	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		healthAmount = maxHealth;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Raycasting ();
		if (spoted) {
			Move ();
		}
		
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
		if(transform.position == pos1.position){
			nextPos = pos02.position;
		}
		if(transform.position == pos02.position){
			nextPos = pos1.position;
		}
		transform.position = Vector3.MoveTowards(transform.position, nextPos, speed*Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Player")||other.gameObject.CompareTag ("Ground")) {
			SFXCtrl.instance.ShowEnemyExplosion (transform.position);
			Destroy (gameObject);
		}
	}

	public void Raycasting(){
		Vector3 target = initialPosition;

		// Pero si la distancia hasta el jugador es menor que el radio de visión el objetivo será él
		float dist = Vector3.Distance(player.transform.position, transform.position);
		if (dist < visionRadius) { 
			target = player.transform.position;
			spoted = true;
		} else {
			spoted = false;
		}
		// Y podemos debugearlo con una línea
		Debug.DrawLine(transform.position, target, Color.green);

	}

	// Podemos dibujar el radio de visión sobre la escena dibujando una esfera
	void OnDrawGizmos() {

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, visionRadius);
		Gizmos.DrawLine (pos1.position, pos02.position);

	}
		
}
