using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MictlantecuhtliPhase03 : MonoBehaviour {
	private SpriteRenderer sr;
	private BoxCollider2D box2D;
	private EnemyHealth enemy;

	private bool canReShot;
	/*
	 * This Array allows to control Itzpapalotl's attack patron
	 * whatCanDo [0] = true -> waitForActions
	 * whatCanDo [1] = true -> CreateButterFlies
	 * whatCanDo [2] = true -> CreateJaguars
	 * whatCanDo [3] = true -> ShotBubbles
	 * whatCanDo [4] = true -> ShotRedFire
	 */
	private bool[] whatCanDo;
	// Variables for movement
	private Vector3 nextPos;
	private int controlNumber;
	private bool isMovingRight;
	private float timeBetweenAttacks;

	[Tooltip("Transform array for the movement")]
	public Transform[] movingPos;
	[Tooltip("Transform array for shotting")]
	public Transform[] firePos;
	[Tooltip("GameObject array for the raining ButterFlyCreators")]
	public GameObject[] butterflyCreators;
	[Tooltip("Prefab for the bubble bullet")]
	public GameObject bubbleShot;
	[Tooltip("Prefab for the bubble bullet")]
	public GameObject redFire;
	[Tooltip("Prefab for the JaguarKnight")]
	public GameObject jaguarKnight;

	[Tooltip("Float value for the speed movement")]
	public float speed;

	void Start () {
		sr = gameObject.GetComponent <SpriteRenderer> ();
		box2D = gameObject.GetComponent <BoxCollider2D> ();
		//anim = gameObject.GetComponent <Animator> ();
		enemy = gameObject.GetComponent <EnemyHealth> ();
		canReShot = true;
		whatCanDo = new bool[5];
		whatCanDo [0] = true;
		timeBetweenAttacks = 1.2f;
		isMovingRight = false;
		nextPos = movingPos [1].position;
		controlNumber = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy.GetIsAlive ()) {
			if (whatCanDo [0]) {
				StartCoroutine (WaitForAction ());
			} else if (whatCanDo [1]) {
				CreateButterflies ();
			} else if (whatCanDo [2]) {
				createExplosiveJaguars (2.2f);
			} else if (whatCanDo [3]) {
				FireBullet (1.2f, true);
			}else if (whatCanDo [4]) {
				FireBullet (1.2f, false);
			}

			Move ();
			//makeRocksRaining ();
		} else {
			HanddleDeath ();
		}
	}

	/// <summary>
	/// Changes the action.
	/// </summary>
	/// <param name="indexPresentAction">Index present action.</param>
	/// <param name="indexNextAction">Index next action.</param>
	public void ChangeAction(int indexPresentAction, int indexNextAction){
		whatCanDo[indexPresentAction] = false;
		whatCanDo[indexNextAction] = true;
	}

	/// <summary>
	/// Waits for action.
	/// </summary>
	/// <returns>The for action.</returns>
	public IEnumerator WaitForAction(){
		yield return new WaitForSeconds (timeBetweenAttacks);
		ChangeAction (0, Random.Range(1,5));
	}

	/// <summary>
	/// Handdles the death.
	/// </summary>
	public void HanddleDeath(){
		sr.enabled = false;
		box2D.enabled = false;
	}

	/// <summary>
	/// Move this instance.
	/// </summary>
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

	/// <summary>
	/// Fires the bullet.
	/// </summary>
	/// <param name="waitBetweenShoots">Wait between shoots.</param>
	/// <param name="isBubble">If set to <c>true</c> is bubble.</param>
	public void FireBullet(float waitBetweenShoots, bool isBubble){
		StopAllCoroutines ();
		if (canReShot) {
			canReShot = false;
			if (isBubble) {
				foreach (Transform firepos in firePos) {
					Instantiate (bubbleShot, firepos.position, Quaternion.identity);
				}
			} else {
				foreach(Transform firepos in firePos){
					Instantiate (redFire, firepos.position, Quaternion.identity);
				}
			}
			Invoke ("ReShot", waitBetweenShoots);
		}
		timeBetweenAttacks = 1.5f;
		if (isBubble) {
			ChangeAction (3, 0);
		} else {
			ChangeAction(4,0);
		}
	}

	public void ReShot(){
		canReShot = true;
	}

	/// <summary>
	/// Creates the explosive jaguars.
	/// </summary>
	/// <param name="waitBetweenShoots">Wait between shoots.</param>
	public void createExplosiveJaguars(float waitBetweenShoots){
		StopAllCoroutines ();
		if (canReShot) {
			canReShot = false;
			Instantiate (jaguarKnight, firePos[0].position, Quaternion.identity);
			Instantiate (jaguarKnight, firePos[3].position, Quaternion.identity);
			Invoke ("ReShot", waitBetweenShoots);
		}
		timeBetweenAttacks = 3f;
		ChangeAction(2,0);
	}

	/// <summary>
	/// Creates the butterflies.
	/// </summary>
	public void CreateButterflies(){
		StopAllCoroutines ();
		foreach (GameObject bfCreator in butterflyCreators) {
			bfCreator.GetComponent<ButterfliesCreator> ().SetIsActive (true);
		}
		timeBetweenAttacks = 1.2f;
		ChangeAction(1,0);
	}
}
