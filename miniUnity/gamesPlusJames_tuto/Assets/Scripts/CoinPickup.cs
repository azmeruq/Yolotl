using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//clase para obtener las monedas
public class CoinPickup : MonoBehaviour {
	//puntos que vale la moneda
	public int pointsToAdd;

	//metodo de colision
	void OnTriggerEnter2D(Collider2D other)
	{
		
		//si el otro componente 2d colisonado no es el player
		if (other.GetComponent<PlayerController> () == null) 
		{
			return;
		}

		//se manda a llamar el metodo de score para sumar puntos
		ScoreManager.AddPoints (pointsToAdd);

		//se destruye la moneda al colisionarla
		Destroy (gameObject);
	}

}
