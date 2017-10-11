using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
	private float velocidadHorizontal;
	private Rigidbody2D rb;
	private Player jugador;
	private float tiempoParaDestruirse;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		jugador = FindObjectOfType<Player> ();
		AsignarVelocidad ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2(velocidadHorizontal, rb.velocity.y);
	}

	public void AsignarVelocidad(){
		if(jugador.GetIsFacingRight()){
			velocidadHorizontal = 7f;
		}else{
			velocidadHorizontal = -7f;
		}
	}
}
