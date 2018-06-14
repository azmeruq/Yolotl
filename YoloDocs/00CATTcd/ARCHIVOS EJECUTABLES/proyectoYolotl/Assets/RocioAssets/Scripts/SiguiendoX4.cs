using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiguiendoX4 : State {
	
	public State morir;
	public State estocada;
	public State sablazo;
	public State filo;
	private Player player;
	public float speed;
	private Boss boss;
	//public float speed;

	//public float vida;

	private float timeToChange;

	private float timeToExit;
	private float ran; 

	void OnEnable()
	{

		player = FindObjectOfType<Player> ();
		timeToExit = 0;
		timeToChange = 4;
		boss = FindObjectOfType<Boss> ();
		ran = Random.Range (0, 1);

			
	}

	void Update()
	{
		timeToExit += Time.deltaTime;
		transform.Translate(Vector3.Normalize(player.transform.position - transform.position) * speed * Time.deltaTime);

	}

	public override void CheckExit()
	{
		ran = Random.Range (-1, 1);
		if (boss.getHealth() <= 0 && timeToExit >= timeToChange)
		{
			stateMachine.ChangeState(morir);
		}
		else if(Vector3.Distance(player.transform.position, transform.position) < 3 && timeToExit >= timeToChange ){
			stateMachine.ChangeState (sablazo);
		}
		else if(Vector3.Distance(player.transform.position, transform.position) >= 3 && timeToExit >= timeToChange && ran >= 0){
			stateMachine.ChangeState (filo);
		}
		else if(Vector3.Distance(player.transform.position, transform.position) >= 3 && timeToExit >= timeToChange && ran < 0){
			stateMachine.ChangeState (estocada);
		}

	}

}
