using System.Collections;
using UnityEngine;
using System;

public class ComportamientoPatron : MonoBehaviour {

	//Variables publicas
	public bool Terrestre = false; //si se aplicarà gravedad o no
	public GameObject[] HitosPatronMovimiento; //los puntos que seguira el objeto
	public float[] VelocidadesPatronMovimiento; //a que velocidad irá a cada uno de los puntos

	//variables privadas
	private Transform thisTransform;
	private Rigidbody2D thisRigidbody;
	private int HitoSiguiente = 0;

	//indica si se puede avanzar al siguiente punto
	public bool CanGoToNextMilestone { get; set; }

	private bool IrHaciaHito(Vector3 PosicionHito, float Velocidad)
	{
		//Calcula la distancia entre el punto y el objeto
		Vector3 VectorHaciaObjetivo = PosicionHito - thisTransform.position;
		if(Terrestre)
		{
			//cálculo de distancia ignorando eje y
			VectorHaciaObjetivo = new Vector3(VectorHaciaObjetivo.x, 0, VectorHaciaObjetivo.z);
		}

		//comprobamos si no ha llegado al hito objetivo
		if(Math.Abs(VectorHaciaObjetivo.x) > 0.2F || Math.Abs(VectorHaciaObjetivo.y) > 0.2F || Math.Abs(VectorHaciaObjetivo.z) > 0.2F) 
		{
			//cáclculo del vector hacia el hito
			VectorHaciaObjetivo.Normalize();
			VectorHaciaObjetivo *= Velocidad;
			VectorHaciaObjetivo = new Vector3(VectorHaciaObjetivo.x, VectorHaciaObjetivo.y, VectorHaciaObjetivo.z);

			//movemos el objeto al hito
			thisTransform.Translate(VectorHaciaObjetivo * Time.deltaTime, Space.World);

			//el objeto aun no ha llegado al hito
			return false;
		} 
		else 
		{
			return true;
		}
	}

	void Start () {
		thisTransform = transform;
		thisRigidbody = GetComponentInParent<Rigidbody2D>();
		CanGoToNextMilestone = true;		
	}
	
	// Update is called once per frame
	void Update () {
		//activamos o desactivamos la gravedad que esta expresada en la variable terrestre
		//thisRigidbody.useGravity = Terrestre;

		//calcula la velocidad del siguiente hito
		//asumiremos que si es 0 en el hito quedara parado
		float VelocidadHaciaHito = 0;
		try
		{
			VelocidadHaciaHito = VelocidadesPatronMovimiento[HitoSiguiente];
		}
		catch 
		{
			VelocidadHaciaHito = 0;
		}
		if (CanGoToNextMilestone) 
		{
			try
			{
				//mueve el objeto hacia el siguiente hito
				if(IrHaciaHito(HitosPatronMovimiento[HitoSiguiente].transform.position, VelocidadHaciaHito))
				{
					//cuando se llegue al hito se detiene
					CanGoToNextMilestone = false;

					//se activa el script de comportamiento correspondiente cuando se llega al hito
					//(osea todos aquellos scripts que empiecen con "Patron")
					//wodades esta si esta interesante <--- investigar despues
					bool patronFound = false;
					MonoBehaviour[] milestoneScript = HitosPatronMovimiento[HitoSiguiente].GetComponents<MonoBehaviour>();
					foreach(MonoBehaviour script in milestoneScript)
					{
						if(script.GetType().Name.Contains("Patron"))
						{
							patronFound = true;
							script.enabled = true;
						}
					}

					//si no se encuentra ningun script de comportamiento...
					if(!patronFound)
					{
						CanGoToNextMilestone = true;
					}
					//calculamos cual será el proximo hito
					if(HitoSiguiente != HitosPatronMovimiento.Length - 1)
					{
						HitoSiguiente++;
					}
					else
					{
						HitoSiguiente = 0;
					}
				}
			}
			catch 
			{
				HitoSiguiente++;
			}
		}		
	}
}

