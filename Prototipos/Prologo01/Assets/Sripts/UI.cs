using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Groups all the user interface elements together for GameCtrl to use
/// </summary>
[Serializable]
public class UI {
	[Header("Text")]
	public Text txtXoloCount;
	public Text txtScore;

	[Header("Images/Sprites")]
	public Image heart1;
	public Image heart2;
	public Image heart3;
	public Sprite emptyHeart;
	public Sprite fullHeart;

	public GameObject panelGameOver;
}
