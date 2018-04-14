using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filo : State {

	public State siguiendoX4;

	private bool once;
	public GameObject objetoPrefab1;
	public GameObject objetoPrefab2;
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
			Vector2 pos1 = new Vector2 (this.gameObject.transform.position.x - 1.5f, this.gameObject.transform.position.y);
			Vector2 pos2 = new Vector2 (this.gameObject.transform.position.x + 1.5f, this.gameObject.transform.position.y);

			Instantiate (objetoPrefab1, pos1, Quaternion.identity);
			Instantiate (objetoPrefab2, pos2, Quaternion.identity);
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