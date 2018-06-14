using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Fixer collider.
/// This class fix the box collider of an object whet it flips
/// </summary>
public class FixerCollider : MonoBehaviour {
	private BoxCollider2D box2D;
	private SpriteRenderer sr;
	public Vector2 originalOffset;
	public Vector2 FlipOffset;
	public Vector2 originalSize;
	public Vector2 FlipSize;
	// Use this for initialization
	void Start () {
		box2D = GetComponent <BoxCollider2D> ();
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (sr.flipX) {
			FitOnFlipBoxCollider ();
		} else {
			setOriginalBoxColliderDimensions ();
		}
	}

	public void FitOnFlipBoxCollider(){
		box2D.offset = FlipOffset;
		box2D.size = FlipSize;
	}

	public void setOriginalBoxColliderDimensions(){
		box2D.offset = originalOffset;
		box2D.size = originalSize;
	}
}
