using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstaticoX4i : State{

	public State manotazo;
	public State lava;
	public State morir;
	private State lluviaFlechas;
	private Boss boss;
	//public float speed;

	//public float vida;

	private float timeToChange;

	private float timeToExit;
	private float ran; 

	void OnEnable()
	{
		//normalColor = renderer.material.color;
		timeToExit = 0;
		timeToChange = 8;


		boss = FindObjectOfType<Boss> ();
	}

	void Update()
	{
		timeToExit += Time.deltaTime;

	}

	public override void CheckExit()
	{
		ran = Random.Range (-1, 2);
		if (boss.getHealth() <= 0 && timeToExit >= timeToChange)
		{
			stateMachine.ChangeState(morir);
		}
		else if(ran <= 0 && timeToExit >= timeToChange){
			stateMachine.ChangeState (manotazo);
		}
		else if(ran > 0 && ran <= 1 && timeToExit >= timeToChange){
			stateMachine.ChangeState (lava);
		}
		else if(ran > 1 && ran <= 2 && timeToExit >= timeToChange){
			stateMachine.ChangeState (lluviaFlechas);
		}

	}
}