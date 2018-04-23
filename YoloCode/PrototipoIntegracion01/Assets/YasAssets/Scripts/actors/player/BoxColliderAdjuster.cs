using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fits the Ajolote's BoxCollided2D position when it flips 
/// </summary>

public class BoxColliderAdjuster : MonoBehaviour {
	private PlayerManager player;
	[Tooltip("Game Object who represents the feet ctrl in the player")]
	public GameObject feet;
	private BoxCollider2D box2D;

	void Start () {
		player = GetComponent <PlayerManager> ();
		box2D = GetComponent <BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetIsFacingRight ()) {
			FitBoxCollider (0.35f, 0.13f, 2.58f, 1.36f);
			feet.GetComponent <Feet> ().FitBoxCollider (0.57f, -0.06f, 2.35f, 0.22f);
		} else {
			FitBoxCollider (-0.4f, 0.13f, 2.58f, 1.36f);
			feet.GetComponent <Feet> ().FitBoxCollider (0f, -0.06f, 2.35f, 0.22f);
		}
	}

	public void FitBoxCollider(float offsetx, float offsety, float sizex, float sizey){
		Vector2 box2DOffSet = new Vector2();
		Vector2 box2DSize = new Vector2();

		box2DOffSet.x = offsetx;//2.811507f
		box2DOffSet.y = offsety; // 0.1881718f
		box2DSize.x = sizex; // 3.880423f
		box2DSize.y = sizey; //1.821438f
		box2D.offset = box2DOffSet;
		box2D.size = box2DSize;
	}
}
