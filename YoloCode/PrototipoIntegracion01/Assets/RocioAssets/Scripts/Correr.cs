using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Correr : State {

	public State morir;
	public State impacto;

	private float timeToChange;
	private float timeToExit;
	private float addedTime;

	private bool once;

	public int vecesCorrer;
	private Player player;
	//public int vida;


	void Start(){
	}

	void OnEnable()
	{
		timeToExit = 0;
		timeToChange = 1;
		player = FindObjectOfType<Player> ();
	}

	void Update()
	{
		timeToExit += Time.deltaTime;

		transform.Translate(Vector3.Normalize(player.transform.position - transform.position) * 10 * Time.deltaTime);

	}

	public override void CheckExit()
	{
		if (player.getHealth() == 0)
		{
			stateMachine.ChangeState(morir);
		}
		else if(Vector3.Distance(player.transform.position, transform.position) < 2){
			stateMachine.ChangeState (impacto);
		}
	}

}
