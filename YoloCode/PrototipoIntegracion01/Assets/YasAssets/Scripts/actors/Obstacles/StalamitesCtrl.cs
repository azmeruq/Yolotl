using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalamitesCtrl : MonoBehaviour {
	public GameObject Stalamite01;
	public GameObject Stalamite02;
	public GameObject Stalamite03;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			Stalamite01.GetComponent<Stalagmite> ().SetIsActived ();
			Stalamite02.GetComponent<Stalagmite> ().SetIsActived ();
			Stalamite03.GetComponent<Stalagmite> ().SetIsActived ();
		}
	}
	
		/*void OnTriggerExit2D(Collider2D other){
			if (other.gameObject.CompareTag ("Player")) {
				Stalamite01.GetComponent<Stalagmite> ().ReSet();
				Stalamite02.GetComponent<Stalagmite> ().ReSet();
				Stalamite03.GetComponent<Stalagmite> ().ReSet();
			}*/
		//Debug.Log ("Col");
	//}
}
