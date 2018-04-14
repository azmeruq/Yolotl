using System.Collections;
using UnityEngine;
using System;

public class DropPlat : MonoBehaviour {


	public GameObject hitoAbajo;
	public float veloA;
	public GameObject hitoOriginal;
	public float veloO;
	private bool caerse;

	//variables privadas
	private Transform thisTransform;


	private void irHaciaHito(Vector3 PosicionHito, float Velocidad)
	{
		//Calcula la distancia entre el punto y el objeto
		//Vector3 VectorHaciaObjetivo = PosicionHito - thisTransform.position;

		thisTransform.transform.position = Vector3.Lerp (thisTransform.transform.position, PosicionHito, 1f * Time.deltaTime);
		//thisTransform.Translate(VectorHaciaObjetivo * Time.deltaTime, Space.World);
	}

	void Start () {
		thisTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (caerse == true) {
			thisTransform.transform.position = Vector3.Lerp (thisTransform.transform.position, hitoAbajo.transform.position, 1f * Time.deltaTime);
		} else if (caerse == false) {
			thisTransform.transform.position = Vector3.Lerp (thisTransform.transform.position, hitoOriginal.transform.position, 1f * Time.deltaTime);
		} 
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			//Debug.Log ("me caigo");
			caerse = true;
			//irHaciaHito(hitoAbajo.transform.position, veloA);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			//Debug.Log ("me subo");
			caerse = false;
			//irHaciaHito (hitoOriginal.transform.position, veloO);
		}
	}

}

