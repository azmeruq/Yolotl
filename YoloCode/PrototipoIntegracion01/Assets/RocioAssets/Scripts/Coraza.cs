using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coraza : State {
	
	public State correr;
	public Color alertColor;

	private float timeToChange;

	private float timeToExit;

	private bool once;

	void Start(){
	}

	void OnEnable()
	{
		timeToExit = 0;
		timeToChange = 3;

	}

	void Update()
	{
		timeToExit += Time.deltaTime;

		if (!once)
		{
			this.gameObject.GetComponent<SpriteRenderer> ().color = alertColor;
			once = true;
		}

	}

	public override void CheckExit()
	{
		if (timeToExit >= timeToChange)
		{
			stateMachine.ChangeState(correr);
		}
	}
		
}
