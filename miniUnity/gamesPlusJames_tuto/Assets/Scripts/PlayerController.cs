using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//estas son las variables de alto del brinco y velocidad de movimiento
	public float moveSpeed;
	public float jumpHeight;
	//variable de velocidad de movimiento, el player se va deslizando por agregarle material (no friccion)
	private float moveVelocity;

	//se usarán para detectar si se esta en el suelo y asi evitar el salto infinito
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	//para doble salto
	private bool doubleJumped;

	//variable de animacion del player
	private Animator anim;

	// Use this for initialization
	void Start () {
		//igualamos la variable al componente Animator
		anim = GetComponent<Animator> ();

		
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
		//aqui con la variable anim que controla la animacion preguntamos si esta o no en el suelo para la animacion de salto
		anim.SetBool ("Grounded", grounded);

		//instruccion de SALTO
		//mientras se oprima la tecla se detectará un solo cambio --> GetKeyDown
		//verifica si se esta tocando el "suelo"
		if (Input.GetKeyDown (KeyCode.W) && grounded) 
		{
			//el brinco es en el eje y con la variable --> jumpHeight, null en el eje x
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, jumpHeight);
			Jump();
		}

		//instruccion de DOBLE SALTO
		//si se oprime space y el doble salto NO ha sido activado y NO se esta en el "suelo"
		if (Input.GetKeyDown (KeyCode.W) && !doubleJumped && !grounded) 
		{
			//entonces se hace un salto
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, jumpHeight);
			Jump();
			//y se ha activado el doble salto
			doubleJumped = true;
		}

		//antes de oprimir una tecla de movimiento horizontal, la velocidad será 0
		//asi se detendrá si no oprimimos ninguna tecla
		moveVelocity = 0f;

		//instrucciones de movimiento en eje x
		//movimiento a la DERECHA
		//se detecta si la tecla esta siendo oprimida --> GetKey
		if (Input.GetKey (KeyCode.D)) 
		{
			//en el eje x se agrega la variable de movimiento --> moveSpeed
			//para agregar y respetar el brinco mas movimiento (hacer diagonales)...
			//... se obtendra el componente actual con rigidbody2D en el eje y(salto)
			/*Esta linea se modifica por el material que se ha agregado al player 
			 * entonces ahora se manejará una variable para su movimiento
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
			*/
			moveVelocity = moveSpeed;
		}
		//movimiento a la IZQUIERDA
		if (Input.GetKey(KeyCode.A)) 
		{
			//ya que estamos en un eje de coordenadas
			//para moverse a la izquierda debe ser una velocidad "negativa" --> -moveSpeed
			/*Esta linea se modifica por el material que se ha agregado al player 
			 * entonces ahora se manejará una variable para su movimiento
			GetComponent<Rigidbody2D> ().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
			*/
			moveVelocity = -moveSpeed;
		}		

		//Ya que se haya obtenido el valor de movimiento al presionar las teclas
		//se pasa a la velocidad del player
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);

		//en la variable de animacion para obtener la velocidad se sustrae su valor
		//ademas como no puede tener velocidad negativa se convierte en su valor absoluto
		anim.SetFloat ("Speed", Mathf.Abs(GetComponent<Rigidbody2D> ().velocity.x));

		//en la animacion para crear efectos hacia la izquierda o derecha
		//en este caso la animacion de brincar solo se escala hacia un lado positivo o negativo
		if (GetComponent<Rigidbody2D> ().velocity.x > 0) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} 
		else if (GetComponent<Rigidbody2D> ().velocity.x < 0) {
			transform.localScale = new Vector3 (-1f, 1f, 1f); 
			//solo el primer valor coordenada "x" es negativo, que es la direccion que queremos cambiar
		}
	}

	//despues de experimentar...
	//creamos un metodo brincar (y asi sustituimos en el códifo varias lineas)
	public void Jump()
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}
}
