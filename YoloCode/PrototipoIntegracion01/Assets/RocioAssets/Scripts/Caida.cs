using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caida : MonoBehaviour {

	public GameObject objetoPrefab;
	private float addedTime;
	public float changeRate;
	private float equis = 0;
	private Transform puntoLanza;
	// Use this for initialization
	void Start () {
		addedTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		addedTime += Time.deltaTime;
		if (addedTime >= changeRate) {
			equis = Random.Range (-11f, 11f);
			Vector2 pos = new Vector2 (this.gameObject.transform.position.x + equis, this.gameObject.transform.position.y);

			//Vector2 pos = new Vector2 (this.gameObject.transform.localPosition., 0f);
			Instantiate (objetoPrefab, pos, Quaternion.identity);
			addedTime = 0;
		}
	}
		
}
