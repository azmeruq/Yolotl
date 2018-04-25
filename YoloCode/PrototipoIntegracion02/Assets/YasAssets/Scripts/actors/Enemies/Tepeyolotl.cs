using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tepeyolotl : MonoBehaviour {
	private SpriteRenderer sr;
	private BoxCollider2D box2D;
	//private Animator anim;
	private EnemyHealth enemy;

	private bool canReShot;
	/*
	 * This Array allows to control Itzpapalotl's attack patron
	 * whatCanDo [0] = true -> waitForaction
	 * whatCanDo [1] = true -> FirePushingRocks
	 * whatCanDo [2] = true -> makeRocksRaining
	 * whatCanDo [3] = true -> createExplosiveJaguars
	 */
	private bool[] whatCanDo;
	// Variables for movement
	private Vector3 nextPos;
	private int controlNumber;
	private bool isMovingRight;
	private float timeBetweenAttacks;

	[Tooltip("Transform array for the movement")]
	public Transform[] movingPos;
	[Tooltip("Transform of the left pushing rocks position")]
	public Transform pushingRocksPosLeft;
	[Tooltip("Transform of the right pushing rocks position")]
	public Transform pushingRocksPosRight;
	[Tooltip("GameObject array for the raining rock creator")]
	public GameObject[] rainingRockCreators;
	[Tooltip("GameObject for the pushing rock left")]
	public GameObject pushingRockLeft;
	[Tooltip("GameObject for the pushing rock right")]
	public GameObject pushingRockRight;
	[Tooltip("GameObject for the explosive jaguar")]
	public GameObject explosiveJaguar;
	[Tooltip("Float value for the speed movement")]
	public float speed;
	// Use this for initialization

	void Start () {
		sr = gameObject.GetComponent <SpriteRenderer> ();
		box2D = gameObject.GetComponent <BoxCollider2D> ();
		//anim = gameObject.GetComponent <Animator> ();
		enemy = gameObject.GetComponent <EnemyHealth> ();
		canReShot = true;
		whatCanDo = new bool[4];
		whatCanDo [0] = true;
		timeBetweenAttacks = 1.2f;
		isMovingRight = false;
		nextPos = movingPos [0].position;
		controlNumber = 0;
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
				FirePushingRocks (2f);
				//Debug.Log ("fire");
			} else if (whatCanDo [2]) {
				makeRocksRaining ();
				//Debug.Log ("shell");
			} else if (whatCanDo [3]) {
				//CreateButterflies ();
				createExplosiveJaguars(2f);
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
		ChangeAction (0, Random.Range(1,4));
	}

	/// <summary>
	/// Move this instance.
	/// </summary>
	public void Move(){
		if (isMovingRight) {
			//Debug.Log ("Moving Right");
			sr.flipX = true;
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
			sr.flipX = false;
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
	/// Handdles the death.
	/// </summary>
	public void HanddleDeath(){
		sr.enabled = false;
		box2D.enabled = false;
		//StopMoving ();
	}
	/// <summary>
	/// Makes the rocks raining.
	/// </summary>
	public void makeRocksRaining(){
		StopAllCoroutines ();
		//anim.SetBool ("isVisible", true);
		foreach (GameObject rrCrator in rainingRockCreators){
			rrCrator.GetComponent<ButterfliesCreator> ().SetIsActive (true);
		}
		timeBetweenAttacks = 1.2f;
		ChangeAction(2,0);
	}
	 /// <summary>
	 /// Fires the pushing rocks.
	 /// </summary>
	 /// <param name="waitBetweenShoots">Wait between shoots.</param>
	public void FirePushingRocks(float waitBetweenShoots){
		StopAllCoroutines ();
		if (canReShot) {
			canReShot = false;
			Instantiate (pushingRockLeft, pushingRocksPosLeft.position, Quaternion.identity);
			Instantiate (pushingRockRight, pushingRocksPosRight.position, Quaternion.identity);
			Invoke ("ReShot", waitBetweenShoots);
		}
		timeBetweenAttacks = 3f;
		ChangeAction(1,0);
	}

	/// <summary>
	/// Allows to shot ones again.
	/// </summary>
	public void ReShot(){
		canReShot = true;
	}

	public void createExplosiveJaguars(float waitBetweenShoots){
		StopAllCoroutines ();
		if (canReShot) {
			canReShot = false;
			Instantiate (explosiveJaguar, pushingRocksPosLeft.position, Quaternion.identity);
			Instantiate (explosiveJaguar, pushingRocksPosRight.position, Quaternion.identity);
			Invoke ("ReShot", waitBetweenShoots);
		}
		timeBetweenAttacks = 3f;
		ChangeAction(3,0);
	}
		
}
