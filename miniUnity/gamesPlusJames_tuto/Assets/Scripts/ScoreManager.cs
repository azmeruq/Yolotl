using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //biblioteca de uso de texto

//clase para el manejo del score en el juego
public class ScoreManager : MonoBehaviour {

	//variable del score
	public static int score;
	//variable paracontrolar el texto del score
	Text text;

	//al principio se inicializará la variable de texto y el score
	void Start()
	{
		text = GetComponent<Text> ();

		score =  0;
	}


	void Update()
	{
		//el score nunca será negativo (validación)
		if (score < 0) 
		{
			score = 0;
		}
		//aqui se agrega el texto el score
		text.text = "" + score;
	}

	//metodo para ir sumando score
	public static void AddPoints(int pointsToAdd)
	{
		score += pointsToAdd;
	}

	//metodo para resetearel score
	public static void Reset()
	{
		score = 0;
	}

}
