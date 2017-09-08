using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedParticle : MonoBehaviour {

	//variable para controlar las particulas 
	private ParticleSystem thisParticleSystem;

	// Use this for initialization
	void Start () {
		//se iguala la variable con el componente de particulas
		thisParticleSystem = GetComponent<ParticleSystem>();
		
	}
	
	// Update is called once per frame
	void Update () {
		//si las particulas estan en funcionamiento... que lo hagan
		if (thisParticleSystem.isPlaying) 
		{
			return;
		}
		//despues de que las particulas hagan su funcion, que se destruyan
		Destroy (gameObject);
		
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}

}
