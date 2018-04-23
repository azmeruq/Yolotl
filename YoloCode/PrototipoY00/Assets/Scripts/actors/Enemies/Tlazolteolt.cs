using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tlazolteolt : MonoBehaviour {
	private SpriteRenderer sr;
	private BoxCollider2D box2D;
	private EnemyHealth enemy;

	private bool canReShot;
	/*
	 * This Array allows to control Itzpapalotl's attack patron
	 * whatCanDo [0] = true -> waitForaction
	 * whatCanDo [1] = true -> shotBlackFire
	 * whatCanDo [2] = true -> useShell
	 * whatCanDo [3] = true -> shotRedFire
	 */
	private bool[] whatCanDo;
	private float timeBetweenAttacks;

	[Tooltip("Transform array for the intance of fire bullets")]
	public Transform[] shotFirePos;
	[Tooltip("GameObject for the fire shell")]
	public GameObject fireShell;
	[Tooltip("GameObject for the black fire bullet")]
	public GameObject blackFireBullet;
	[Tooltip("GameObject for the red fire bullet")]
	public GameObject redFireBullet;

	//private float originalSpeed;


	void Start () {
		sr = gameObject.GetComponent <SpriteRenderer> ();
		box2D = gameObject.GetComponent <BoxCollider2D> ();
		enemy = gameObject.GetComponent <EnemyHealth> ();
		fireShell.GetComponent <EvilEnergyShell> ().SetInActive();
		canReShot = true;
		whatCanDo = new bool[4];
		whatCanDo [0] = true;
		timeBetweenAttacks = 1.2f;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy.GetIsAlive ()) {
			if (whatCanDo [0]) {
				StartCoroutine (WaitForAction ());
				//Debug.Log ("Wait");
			} else if (whatCanDo [1]) {
				FireBullet (1f, true);
				//Debug.Log ("fire");
			} else if (whatCanDo [2]) {
				UseFireShell ();
				//Debug.Log ("shell");
			} else if (whatCanDo [3]) {
				FireBullet (1f, false);
				//Debug.Log ("shell");
			}

		} else {
			HanddleDeath ();
		}
		//Move ();
	}



	/// <summary>
	/// Changes the present action to a new one using the indexes of the array actions.
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
	/// Makes enable the SpriteRender and the boxCollider after the enemy dies.
	/// </summary>
	public void HanddleDeath(){
		sr.enabled = false;
		box2D.enabled = false;
		//StopMoving ();
	}

	/// <summary>
	/// Fires the bullet.
	/// </summary>
	/// <param name="waitBetweenShoots">Wait between shoots.</param>
	/// <param name="isBlackFire">If set to <c>true</c> is black fire is the one who would be shotted
	/// otherwise would be red fire.</param>
	public void FireBullet(float waitBetweenShoots, bool isBlackFire){
		StopAllCoroutines ();
		if (canReShot) {
			canReShot = false;
			if (isBlackFire) {
				foreach (Transform firepos in shotFirePos) {
					Instantiate (blackFireBullet, firepos.position, Quaternion.identity);
				}
			} else {
				foreach(Transform firepos in shotFirePos){
					Instantiate (redFireBullet, firepos.position, Quaternion.identity);
				}
			}
			Invoke ("ReShot", waitBetweenShoots);
		}
		timeBetweenAttacks = 1.5f;
		if (isBlackFire) {
			ChangeAction (1, 0);
		} else {
			ChangeAction(3,0);
		}
	}
	/// <summary>
	/// Allows to shot again
	/// </summary>
	public void ReShot(){
		canReShot = true;
	}

	/// <summary>
	/// Uses the fire shell.
	/// </summary>
	public void UseFireShell( ){
		StopAllCoroutines ();
		//box2D.enabled = false;
		if (!fireShell.GetComponent <EvilEnergyShell> ().GetIsAlive ()) {
			fireShell.GetComponent <EvilEnergyShell> ().HanddleDead ();
		}
		timeBetweenAttacks = 2f;
		ChangeAction(2,0);
	}
}
