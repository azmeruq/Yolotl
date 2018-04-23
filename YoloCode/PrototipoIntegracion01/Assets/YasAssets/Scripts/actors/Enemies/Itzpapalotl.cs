using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itzpapalotl : MonoBehaviour {
	private SpriteRenderer sr;
	private BoxCollider2D box2D;
	private Animator anim;
	private EnemyHealth enemy;

	private bool canReShot;
	/*
	 * This Array allows to control Itzpapalotl's attack patron
	 * whatCanDo [0] = true -> waitForaction
	 * whatCanDo [1] = true -> shotFire
	 * whatCanDo [2] = true -> useShell
	 * whatCanDo [3] = true -> butterflies
	 */
	private bool[] whatCanDo;
	private Vector3 nextPos;
	private int controlNumber;
	private bool isMovingRight;
	private float timeBetweenAttacks;

	[Tooltip("Transform array for the intance of fire bullets")]
	public Transform[] shotFirePos;
	[Tooltip("Transform array for the movement")]
	public Transform[] movingPos;
	[Tooltip("GameObject for the fire shell")]
	public GameObject fireShell;
	[Tooltip("GameObject for the fire bullet")]
	public GameObject fireBullet;
	[Tooltip("Float value for the speed movement")]
	public float speed;
	[Tooltip("Prefab of ButterfliesCreator")]
	public GameObject bfCratorRight;
	[Tooltip("Prefab of ButterfliesCreator")]
	public GameObject bfCratorLeft;

	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent <SpriteRenderer> ();
		box2D = gameObject.GetComponent <BoxCollider2D> ();
		anim = gameObject.GetComponent <Animator> ();
		enemy = gameObject.GetComponent <EnemyHealth> ();
		fireShell.SetActive (false);
		canReShot = true;
		whatCanDo = new bool[4];
		whatCanDo [0] = true;
		timeBetweenAttacks = 1.2f;
		isMovingRight = false;
		nextPos = movingPos [2].position;
		controlNumber = 3;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		 * Check firts if is visble if it's make the change between actions
		 * otherwise fire 
		*/
		if (enemy.GetIsAlive ()) {
			if (whatCanDo [0]) {
				StartCoroutine (WaitForAction ());
				//Debug.Log ("Wait");
			} else if (whatCanDo [1]) {
				FireBullet (1f);
				//Debug.Log ("fire");
			} else if (whatCanDo [2]) {
				UseFireShell ();
				//Debug.Log ("shell");
			} else if (whatCanDo [3]) {
				CreateButterflies ();
				//Debug.Log ("shell");
			}
			Move ();
		} else {
			HanddleDeath ();
		}


	}

	/// <summary>
	/// Fires the firebullet in everypoint from the firepos array.
	/// </summary>
	public void FireBullet(float waitBetweenShoots){
		StopAllCoroutines ();
		if (canReShot) {
			canReShot = false;
			foreach(Transform firepos in shotFirePos){
				Instantiate (fireBullet, firepos.position, Quaternion.identity);
			}
			Invoke ("ReShot", waitBetweenShoots);
		}
		timeBetweenAttacks = 2f;
		ChangeAction(1,0);
	}


	public void ReShot(){
		canReShot = true;
	}

	public void UseFireShell( ){
		StopAllCoroutines ();
		box2D.enabled = false;
		fireShell.SetActive (true);
		Invoke ("SetFireShellOff", 6f);
	}

	public void SetFireShellOff(){
		StopAllCoroutines ();
		box2D.enabled = true;
		fireShell.SetActive (false);
		timeBetweenAttacks = 1f;
		ChangeAction(2,0);
	}

	public void CreateButterflies(){
		StopAllCoroutines ();
		anim.SetBool ("isVisible", true);
		bfCratorRight.GetComponent<ButterfliesCreator> ().SetIsActive (true);
		bfCratorLeft.GetComponent<ButterfliesCreator> ().SetIsActive (true);
		Invoke ("StopCreatingButterflies", 3f);
	}

	public void StopCreatingButterflies(){
		anim.SetBool ("isVisible", false);
		//bfCratorRight.GetComponent<ButterfliesCreator> ().SetIsActive (true);
		//bfCratorLeft.GetComponent<ButterfliesCreator> ().SetIsActive (true);
		timeBetweenAttacks = 1.2f;
		ChangeAction(3,0);
	}

	public void ChangeAction(int indexPresentAction, int indexNextAction){
		whatCanDo[indexPresentAction] = false;
		whatCanDo[indexNextAction] = true;
	}


	public IEnumerator WaitForAction(){
		yield return new WaitForSeconds (timeBetweenAttacks);
		ChangeAction (0, Random.Range(1,4));
	}


	public void Move(){
		if (isMovingRight) {
			//Debug.Log ("Moving Right");
			if(transform.position == nextPos){
				//Debug.Log (controlNumber);
				if (controlNumber == movingPos.Length-1) {
					controlNumber = movingPos.Length - 1;
					nextPos = movingPos [movingPos.Length - 2].position;
					isMovingRight = false;
				} else {
					controlNumber++;	
					nextPos = movingPos [controlNumber].position;
				}
			}
		} else {
			//Debug.Log ("Moving left");
			if (transform.position == nextPos) {
				if (controlNumber == 0) {
					controlNumber = 1;
					nextPos = movingPos [controlNumber].position;
					isMovingRight = true;
				} else {
					controlNumber--;	
					nextPos = movingPos [controlNumber].position;
				}
			}

		}
		transform.position = Vector3.MoveTowards(transform.position, nextPos, speed*Time.deltaTime);
	}

	public void HanddleDeath(){
		sr.enabled = false;
		box2D.enabled = false;
		//StopMoving ();
	}
}
