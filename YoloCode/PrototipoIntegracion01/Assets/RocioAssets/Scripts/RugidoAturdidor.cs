using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RugidoAturdidor : State {

	public State correrx4;
	public State lluviaRocas;
	public State morir;

	private Player player;
	private Boss boss;

	private bool once;
	public GameObject objetoPrefab;

	private float timeToChange;
	private float timeToExit;


	void OnEnable()
	{

		player = FindObjectOfType<Player> ();
		boss = FindObjectOfType<Boss> ();
		timeToChange = 2;

		once = false;

	}

	void Update()
	{
		timeToExit += Time.deltaTime;

		 if (!once) 
		{
			Vector2 pos1 = new Vector2 (this.gameObject.transform.position.x - 1.5f, this.gameObject.transform.position.y);

			Instantiate (objetoPrefab, pos1, Quaternion.identity);
			once = true;
		}
			
	}

	public override void CheckExit()
	{
		if (boss.getHealth() <= 0 && timeToExit > timeToChange)
		{
			stateMachine.ChangeState(morir);
		}
		else if((Vector3.Distance(player.transform.position, transform.position) < 5) && timeToExit > timeToChange)
		{
			stateMachine.ChangeState (correrx4);
		}
		else if( (Vector3.Distance(player.transform.position, transform.position) >= 5) && timeToExit > timeToChange)
		{
			stateMachine.ChangeState (lluviaRocas);
		}
	}

}
