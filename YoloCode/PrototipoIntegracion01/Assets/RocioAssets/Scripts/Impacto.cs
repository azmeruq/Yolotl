using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impacto : State {

	public State correr;
	public Color alertColor;

	private float timeToChange;
	private float changeRate;

	private float timeToExit;
	private float timeToWork;
	private float addedTime;

	private float addedTime1;
	private float addedTime2;
	private float changeRate1;
	private float changeRate2;


	private bool once;
	private Transform thisTransform;
	public GameObject objetoPrefab;

	void Start(){
		
	}

	void OnEnable()
	{
		timeToExit = 0;
		changeRate1 = 0.5f;
		changeRate2 = 1;
		addedTime1 = 0;
		addedTime1 = 0.5f;
		addedTime = 0;

		changeRate = 1;
		timeToChange = 2;

		thisTransform = transform;
		once = false;


	}

	void Update()
	{
		timeToExit += Time.deltaTime;
		addedTime += Time.deltaTime;
		addedTime1 += Time.deltaTime;
		addedTime2 += Time.deltaTime;


		if (addedTime <= 0.5f) 
		{
			Vector3 mover1 = new Vector3 (0f, 0.1f, 0f);
			thisTransform.Translate (mover1);

			addedTime1 = 0;
		} else if (addedTime > 0.5f && addedTime <= 1f) 
		{
			Vector3 mover2 = new Vector3 (0f, -0.1f, 0f);
			thisTransform.Translate (mover2);

			addedTime2 = 0.5f;
		} else if (!once && addedTime > 1f && addedTime <= 2f) 
		{
			Vector2 pos1 = new Vector2 (this.gameObject.transform.position.x - 2.5f, this.gameObject.transform.position.y);
			Vector2 pos2 = new Vector2 (this.gameObject.transform.position.x + 2.5f, this.gameObject.transform.position.y);

			Instantiate (objetoPrefab, pos1, Quaternion.identity);
			Instantiate (objetoPrefab, pos2, Quaternion.identity);

			this.gameObject.GetComponent<SpriteRenderer> ().color = alertColor;
			once = true;
		}
			
		/*
		if (!once && timeToExit > timeToChange)
		{
			/*
			Vector3 mover1 = new Vector3(0f, 1f, 0f);
			Vector3 mover2 = new Vector3 (0f, -1f, 0f);
			for (int i = 0; i < 5; i++) {
				thisTransform.Translate(mover1 * Time.deltaTime);
			}
			for (int j = 0; j < 5; j++) {
				thisTransform.Translate(mover2);
			}

			Vector2 pos1 = new Vector2 (this.gameObject.transform.position.x - 1.8f, this.gameObject.transform.position.y);
			Vector2 pos2 = new Vector2 (this.gameObject.transform.position.x + 1.8f, this.gameObject.transform.position.y);

			Instantiate (objetoPrefab, pos1, Quaternion.identity);
			Instantiate (objetoPrefab, pos2, Quaternion.identity);


			//thisTransform.Translate (Vector3 (0f, -10f, 0f) * Time.deltaTime);

			this.gameObject.GetComponent<SpriteRenderer> ().color = alertColor;
			once = true;
		}
	    */

	}

	public override void CheckExit()
	{
		if (timeToExit > timeToChange)
		{
			stateMachine.ChangeState(correr);
		}
	}

}
