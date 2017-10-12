using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirConRetraso : MonoBehaviour {
	private float retrazo;
	void Start () {
		retrazo = 1.5f;
		Destroy (gameObject, retrazo);	
	}
}
