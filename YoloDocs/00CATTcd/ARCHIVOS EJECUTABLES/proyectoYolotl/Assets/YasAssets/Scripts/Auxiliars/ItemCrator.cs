using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCrator : MonoBehaviour {
	[Tooltip("Game Object who represents a Item, this could be a Cacao prefab or a Vainilla")]
	public GameObject item;
	[Tooltip("Float value which represents de delay between a Item an other one")]
	public float delayTime;
	private bool canCreateItem;
	// Use this for initialization
	void Start () {
		canCreateItem = false;
		Invoke ("ReActivateCanCreateItem", delayTime);
	}
	
	// Update is called once per frame
	void Update () {
		if(canCreateItem){
			canCreateItem = false;
			Instantiate (item, transform.position, Quaternion.identity);
			Invoke ("ReActivateCanCreateItem", delayTime);
		}
	}

	public void ReActivateCanCreateItem(){
		canCreateItem = true;
	}
}
