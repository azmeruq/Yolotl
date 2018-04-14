using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slide : MonoBehaviour {

	public GameObject camera;

	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;
	public GameObject obj4;
	public GameObject obj5;
	public GameObject obj6;
	public GameObject obj7;
	public GameObject obj8;
	public GameObject obj9;
	public GameObject obj10;

	private int contador = 1;

	// Use this for initialization
	void Start () {
		
	}
	

	public void right_click ()
	{
		if (contador == 1) {
			contador = 10;
		} else {
			contador--;
		}
		switch (contador) {
		case 1:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj1.transform.position, 1f * Time.deltaTime);
			break;
		case 2:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj2.transform.position, 1f * Time.deltaTime);
			break;
		case 3:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj3.transform.position, 1f * Time.deltaTime);
			break;
		case 4:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj4.transform.position, 1f * Time.deltaTime);
			break;
		case 5:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj5.transform.position, 1f * Time.deltaTime);
			break;
		case 6:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj6.transform.position, 1f * Time.deltaTime);
			break;
		case 7:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj7.transform.position, 1f * Time.deltaTime);
			break;
		case 8:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj8.transform.position, 1f * Time.deltaTime);
			break;
		case 9:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj9.transform.position, 1f * Time.deltaTime);
			break;
		case 10:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj10.transform.position, 1f * Time.deltaTime);
			break;
		default:
			break;

		}
	}

	public void left_click ()
	{
		if (contador == 10) {
			contador = 1;
		} else {
			contador++;
		}
		switch (contador) {
		case 1:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj1.transform.position, 1f * Time.deltaTime);
			break;
		case 2:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj2.transform.position, 1f * Time.deltaTime);
			break;
		case 3:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj3.transform.position, 1f * Time.deltaTime);
			break;
		case 4:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj4.transform.position, 1f * Time.deltaTime);
			break;
		case 5:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj5.transform.position, 1f * Time.deltaTime);
			break;
		case 6:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj6.transform.position, 1f * Time.deltaTime);
			break;
		case 7:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj7.transform.position, 1f * Time.deltaTime);
			break;
		case 8:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj8.transform.position, 1f * Time.deltaTime);
			break;
		case 9:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj9.transform.position, 1f * Time.deltaTime);
			break;
		case 10:
			camera.transform.position = Vector3.Lerp (camera.transform.position, obj10.transform.position, 1f * Time.deltaTime);
			break;
		default:
			break;

		}
	}

}
