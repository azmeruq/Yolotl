using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sablazo : State {

	public State siguiendoX4;

	private bool once;
	public GameObject objetoPrefab;

	private float timeToChange;
	private float timeToExit;


	void OnEnable()
	{

		timeToChange = 1;

		once = false;

	}

	void Update()
	{
		timeToExit += Time.deltaTime;

		if (!once) 
		{
			Vector2 pos1 = new Vector2 (this.gameObject.transform.position.x + 1.5f, this.gameObject.transform.position.y);

			Instantiate (objetoPrefab, pos1, Quaternion.identity);

			once = true;
		}

	}

	public override void CheckExit()
	{
		if (timeToExit > timeToChange)
		{
			stateMachine.ChangeState(siguiendoX4);
		}
	}

}