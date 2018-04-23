using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MictlantecuhtliPhase02 : MonoBehaviour {
	[Tooltip("GameObject,  than represents the Mictlantecuhtli's right hand")]
	public GameObject rightHand;
	[Tooltip("GameObject,  than represents the Mictlantecuhtli's left hand")]
	public GameObject leftHand;
	[Tooltip("GameObject,  than represents the rightBoneBlade")]
	public GameObject rightBlade;
	[Tooltip("GameObject,  than represents the leftBoneBlade")]
	public GameObject leftBlade;
	[Tooltip("GameObject,  than represents the bonesCreators for the raining bones")]
	public GameObject[] bonesCreators;
	/*
	 * This Array allows to control Itzpapalotl's attack patron
	 * whatCanDo [0] = true -> waitForaction
	 * whatCanDo [1] = true -> CreateRainingBones
	 * whatCanDo [2] = true -> SummonBoneBlades
	 */
	private bool[] whatCanDo;
	private float timeBetweenAttacks;
	private SpriteRenderer sr;
	//private bool isAlive;

	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		whatCanDo = new bool[3];
		whatCanDo [0] = true;
		timeBetweenAttacks = 1.2f;
		//isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (IsAlive ()) {
			if (whatCanDo [0]) {
				StartCoroutine (WaitForAction ());
				//Debug.Log ("Wait");
			} else if (whatCanDo [1]) {
				SummonBoneBlades ();
				//CreateRainingBones ();
				//Debug.Log ("fire");
			} else if (whatCanDo [2]) {
				//Debug.Log ("rain");
				CreateRainingBones ();
			}
		} else {
			HanddleDeath ();
		}
	}

	/// <summary>
	/// Chacks if the two hands are alive
	/// </summary>
	/// <returns><c>true</c>, if alive was ised, <c>false</c> otherwise.</returns>
	public bool IsAlive(){
		if(rightHand.GetComponent<EnemyHealth>().GetIsAlive()||leftHand.GetComponent<EnemyHealth>().GetIsAlive()){
			return true;
		}else{
			return false;
		}
	}

	/// <summary>
	/// Handdles the death.
	/// </summary>
	public void HanddleDeath (){
		sr.enabled = false;
		SFXCtrl.instance.ShowEnemyExplosion (transform.position);
	}

	/// <summary>
	/// Changes the action.
	/// </summary>
	/// <param name="indexPresentAction">Index present action.</param>
	/// <param name="indexNextAction">Index next action.</param>
	public void ChangeAction(int indexPresentAction, int indexNextAction){
		//Debug.Log (indexNextAction);
		whatCanDo[indexPresentAction] = false;
		whatCanDo[indexNextAction] = true;
	}

	/// <summary>
	/// Waits for action.
	/// </summary>
	/// <returns>The for action.</returns>
	public IEnumerator WaitForAction(){
		yield return new WaitForSeconds (timeBetweenAttacks);
		ChangeAction (0, Random.Range(1,3));
	}

	public void CreateRainingBones(){
		StopAllCoroutines ();
		//anim.SetBool ("isVisible", true);
		foreach (GameObject rrCrator in bonesCreators){
			rrCrator.GetComponent<ButterfliesCreator> ().SetIsActive (true);
		}
		timeBetweenAttacks = 2.2f;
		ChangeAction(2,0);
	}

	public void SummonBoneBlades(){
		StopAllCoroutines ();
		//anim.SetBool ("isVisible", true);
		rightBlade.GetComponent<BladeBone>().SetIsActive(true);
		leftBlade.GetComponent<BladeBone>().SetIsActive(true);
		timeBetweenAttacks = 2.2f;
		ChangeAction(1,0);
	}

}
