using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : State {
	
		public State estaticoX4;

		private Player player;
		private Boss boss;
		public GameObject prefab;
		//public float speed;

		//public float vida;

		
		private float timeToChange;

		private float timeToExit;
		private bool once;

		void OnEnable()
		{
			//normalColor = renderer.material.color;
			timeToExit = 0;
			timeToChange = 2;

			player = FindObjectOfType<Player> ();
			boss = FindObjectOfType<Boss> ();
			once = false;
		}

		void Update()
		{
			timeToExit += Time.deltaTime;

			if (!once)
			{
				for (int i = 0; i < 5; i++) 
				{
					Vector2 position = new Vector2(Random.Range(-20, 3), 5.5f);
					Instantiate(prefab, position, Quaternion.identity);
				}
				once = true;
			}
		}

		public override void CheckExit()
		{
			if(timeToExit >= timeToChange)
			{
				stateMachine.ChangeState (estaticoX4);
			}
			
		}
}

