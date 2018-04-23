using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mictlantecuhtli : MonoBehaviour {
	private SpriteRenderer sr;
	private BoxCollider2D box2D;
	private EnemyHealth enemy;

	private bool canReShot;
	/*
	 * This Array allows to control Itzpapalotl's attack patron
	 * whatCanDo [0] = true -> waitForaction
	 * whatCanDo [1] = true -> SummonAllKingKnights
	 * whatCanDo [2] = true -> shotMortisFire
	 * whatCanDo [3] = true -> createBones
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
	[Tooltip("Transform of the left pushing rocks position")]
	public Transform pushingBonesPosLeft;
	[Tooltip("Transform of the right pushing rocks position")]
	public Transform pushingBonesPosRight;

	[Tooltip("GameObject array of enemies")]
	public GameObject[] kingKnights;
	[Tooltip("GameObject for fire Mictlantecuhtli")]
	public GameObject fireBullet;
	[Tooltip("GameObject for bone left attack")]
	public GameObject boneLeft;
	[Tooltip("GameObject for bone right attack")]
	public GameObject boneRight;
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
		nextPos = movingPos [1].position;
		controlNumber = 1;
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
				SummonAllKingKnights(2.2f);
				//Debug.Log ("fire");
			} else if (whatCanDo [2]) {
				ShotMortisFire (1f);
				//Debug.Log ("shell");
			} else if (whatCanDo [3]) {
				CreateBones (2f);
				//createExplosiveJaguars(2f);
			}

			Move ();
			//makeRocksRaining ();
		} else {
			HanddleDeath ();
		}
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
	/// Handdles the death.
	/// </summary>
	public void HanddleDeath(){
		sr.enabled = false;
		box2D.enabled = false;
		//StopMoving ();
	}
	/// <summary>
	/// Summons all king knights.
	/// </summary>
	/// <param name="waitBetweenSummon">Wait between summon.</param>
	public void SummonAllKingKnights(float waitBetweenSummon){
		StopAllCoroutines ();
		//Debug.Log (canReShot);
		int index;
		if (canReShot) {
			canReShot = false;
			//Debug.Log (index);
			//Instantiate (kingKnights[0], firePos[0].position, Quaternion.identity);
			foreach(Transform fir in firePos){
				index = (int)Random.Range (0, 4);
				Instantiate (kingKnights[index], fir.position, Quaternion.identity);
			}
			Invoke ("ReShot", waitBetweenSummon);
		}
		timeBetweenAttacks = 2.5f;
		ChangeAction(1,0);
	}

	public void ReShot(){
		canReShot = true;
	}

	public void ShotMortisFire(float waitBetweenSummon){
		StopAllCoroutines ();
		//Debug.Log (canReShot);		int index;
		if (canReShot) {
			canReShot = false;
			foreach(Transform fir in firePos){
				Instantiate (fireBullet, fir.position, Quaternion.identity);
			}
			Invoke ("ReShot", waitBetweenSummon);
		}
		timeBetweenAttacks = 1.5f;
		ChangeAction(2,0);
	}

	public void CreateBones(float waitBetweenShoots){
		StopAllCoroutines ();
		if (canReShot) {
			canReShot = false;
			Instantiate (boneLeft, pushingBonesPosLeft.position, Quaternion.identity);
			Instantiate (boneRight, pushingBonesPosRight.position, Quaternion.identity);
			Invoke ("ReShot", waitBetweenShoots);
		}
		timeBetweenAttacks = 3f;
		ChangeAction(3,0);
	}
}
