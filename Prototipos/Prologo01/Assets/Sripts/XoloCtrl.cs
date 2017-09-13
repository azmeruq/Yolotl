using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XoloCtrl : MonoBehaviour {

	public enum XoloFX{
		Vanish,
		Fly
	}

	public XoloFX xoloFX;
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			if(xoloFX == XoloFX.Vanish)
				Destroy (gameObject);
		}

	}
}
