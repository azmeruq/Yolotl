using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstaticoX4 : State {

	public State tornado;
	public State ventisca;
	public State morir;
	private Player player;
	private Boss boss;
	//public float speed;

	//public float vida;

	private float timeToChange;

	private float timeToExit;
	private bool once;

	void OnEnable()
	{
		//normalColor = renderer.material.color;
		timeToExit = 0;
		timeToChange = 8;

		player = FindObjectOfType<Player> ();
		boss = FindObjectOfType<Boss> ();
		once = false;
	}

	void Update()
	{
		timeToExit += Time.deltaTime;

	}

	public override void CheckExit()
	{
		if (boss.getHealth() <= 0 && timeToExit >= timeToChange)
		{
			stateMachine.ChangeState(morir);
		}
		else if(Vector3.Distance(player.transform.position, transform.position) < 5 && timeToExit >= timeToChange ){
			stateMachine.ChangeState (tornado);
		}
		else if(Vector3.Distance(player.transform.position, transform.position) >= 5 && timeToExit >= timeToChange){
			stateMachine.ChangeState (ventisca);
		}

	}
}
