using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//estas son las variables de alto del brinco y velocidad de movimiento
	public float moveSpeed;
	public float jumpHeight;

	//se usarán para detectar si se esta en el suelo y asi evitar el salto infinito
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	//para doble salto
	private bool doubleJumped;

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {

		//verifica si se esta tocando el "suelo"
		if (grounded) 
		{
			//si se esta en el piso entonces el brinco doble no esta disponible
			//(se tendria que estar en el aire)
			doubleJumped = false;
		}

		//instruccion de SALTO
		//mientras se oprima la tecla se detectará un solo cambio --> GetKeyDown
		//verifica si se esta tocando el "suelo"
		if (Input.GetKeyDown (KeyCode.Space) && grounded) 
		{
			//el brinco es en el eje y con la variable --> jumpHeight, null en el eje x
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, jumpHeight);
			Jump();
		}

		//instruccion de DOBLE SALTO
		//si se oprime space y el doble salto NO ha sido activado y NO se esta en el "suelo"
		if (Input.GetKeyDown (KeyCode.Space) && !doubleJumped && !grounded) 
		{
			//entonces se hace un salto
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, jumpHeight);
			Jump();
			//y se ha activado el doble salto
			doubleJumped = true;
		}

		//instrucciones de movimiento en eje x
		//movimiento a la DERECHA
		//se detecta si la tecla esta siendo oprimida --> GetKey
		if (Input.GetKey (KeyCode.D)) 
		{
			//en el eje x se agrega la variable de movimiento --> moveSpeed
			//para agregar y respetar el brinco mas movimiento (hacer diagonales)...
			//... se obtendra el componente actual con rigidbody2D en el eje y(salto)
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		}
		//movimiento a la IZQUIERDA
		if (Input.GetKey(KeyCode.A)) 
		{
			//ya que estamos en un eje de coordenadas
			//para moverse a la izquierda debe ser una velocidad "negativa" --> -moveSpeed
			GetComponent<Rigidbody2D> ().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		}		
	}

	//despues de experimentar...
	//creamos un metodo brincar (y asi sustituimos en el códifo varias lineas)
	public void Jump()
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}
}
