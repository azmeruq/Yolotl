using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy behavior than allows to follows the palayer and if the enemy catches it then the enemy
/// explotes
/// </summary>

public class Vulture : MonoBehaviour {
	[Tooltip("float value. Radius of the active enemy's")]
	public float visionRadius;
	private float speed;

	// Variable para guardar al jugador
	GameObject player;

	// Variable para guardar la posición inicial
	Vector3 initialPosition;
	private EnemyHealth enemy;
	private CapsuleCollider2D cap2D;
	private SpriteRenderer sr;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		initialPosition = transform.position;
		speed = 6f;
		enemy = GetComponent<EnemyHealth> ();
		cap2D = GetComponent<CapsuleCollider2D> ();
		sr = GetComponent<SpriteRenderer> ();
	}

	void Update () {
		if ((!enemy.GetIsAlive ()) && (!(player.GetComponent <PlayerManager> ()).GetIsAlive ())) {
			sr.enabled = true;
			cap2D.enabled = true;
			enemy.HanddleDead ();

		} else if (!enemy.GetIsAlive ()) {
			sr.enabled = false;
			cap2D.enabled = false;
		} else {
			// Por defecto nuestro objetivo siempre será nuestra posición inicial
			Vector3 target = initialPosition;
			SetFlipX ();
			// Pero si la distancia hasta el jugador es menor que el radio de visión el objetivo será él
			float dist = Vector3.Distance (player.transform.position, transform.position);
			if (dist < visionRadius)
				target = player.transform.position;

			// Finalmente movemos al enemigo en dirección a su target
			float fixedSpeed = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target, fixedSpeed);

			// Y podemos debugearlo con una línea
			Debug.DrawLine (transform.position, target, Color.green);
		}
	}

	// Podemos dibujar el radio de visión sobre la escena dibujando una esfera
	void OnDrawGizmos() {

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, visionRadius);

	}

	public void SetFlipX ()
	{
		if (Mathf.Sign (transform.position.x - player.transform.position.x) == 1)
			sr.flipX = true;
		else if (Mathf.Sign (transform.position.x - player.transform.position.x) == -1)
			sr.flipX = false;

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			enemy.SetHealth (enemy.maxHealth);
		}
	}
}
