using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Controls the dimensions of the Health and Tonalli bars
/// </summary>
public class HealthBar : MonoBehaviour {
	[Tooltip("Image than represents the Health Amount")]
	public Image health;
	[Tooltip("Image than represents the tonalli Amount")]
	public Image tonalli;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Updates the health bar proportion.
	/// </summary>

	public void UpDateHealthBar(float proportion){
		health.transform.localScale = new Vector2 (proportion, 1);
	}

	/// <summary>
	/// Updates the tonalli bar proportion.
	/// </summary>

	public void UpDateTonalliBar(float proportion){
		tonalli.transform.localScale = new Vector2 (proportion, 1);
	}
		
}
