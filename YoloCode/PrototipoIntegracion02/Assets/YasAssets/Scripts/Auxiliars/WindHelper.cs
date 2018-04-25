using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindHelper : MonoBehaviour {
	//For rayCasting
	Vector3 initialPosition;
	[Tooltip("float value. This value represnts the position where the bullet will be created when the enemy shoots")]
	public float visionRadius;
	public GameObject player;
	public windCreator windc;
	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Raycasting ();
	}

	public void Raycasting(){
		Vector3 target = initialPosition;

		// Pero si la distancia hasta el jugador es menor que el radio de visión el objetivo será él
		float dist = Vector3.Distance(player.transform.position, transform.position);
		if (dist < visionRadius) { 
			target = player.transform.position;
			windc.SetIsActive(true);
		} else {
			windc.SetIsActive(false);
		}
		// Y podemos debugearlo con una línea
		Debug.DrawLine(transform.position, target, Color.green);

	}

	void OnDrawGizmos() {

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, visionRadius);

	}
}
