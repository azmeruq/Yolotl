using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionMenuCtrl : MonoBehaviour {
	public LevelDescriptors levelInformation;
	public int levelsAmount;
	public Sprite [] levelImage;
	public string [] levelsName;
	public Text levelName;
	public Text levelDescription;
	public Image levelImageIcon;
	//For the game data query max = 21
	private int indexCtrl;
	// For the level Information max = 22
	private int navigationIndexCtrl;
	// For the levels image max = 10
	private int indexImage; 
	// Use this for initialization
	void Start () {
		indexCtrl = 0;	
		indexImage = 1;
		navigationIndexCtrl = 1;
		ShowLevelInformation ();
	}

	public void GoPrevious(){
		navigationIndexCtrl --;
		indexCtrl --;
		if(navigationIndexCtrl == 0){
			indexCtrl = 0;	
			indexImage = 1;
			navigationIndexCtrl = 1;
		}

		if (((navigationIndexCtrl % 2 == 0) && ((navigationIndexCtrl != 20)&&(navigationIndexCtrl != 18))) || (navigationIndexCtrl == 19)) {
			indexImage--;
		}
			
		//Debug.Log ("Index navigation: " + navigationIndexCtrl);
		//Debug.Log ("Index query: " + indexCtrl);

		if (!GameDataCtrl.instance.GetGameData ().GetLevel (indexCtrl)) {
			ShowLevelDefault ();
		} else {
			ShowLevelInformation();
		}
	}

	public void GoNext(){
		//Debug.Log (navigationIndexCtrl);
		navigationIndexCtrl ++;
		indexCtrl ++;
		if (navigationIndexCtrl > levelsAmount) {
			navigationIndexCtrl = 22;
			indexCtrl = 21;
			indexImage = 10;
		}
		if ((((navigationIndexCtrl % 2 == 1)&&(navigationIndexCtrl!=19))||(navigationIndexCtrl==20))&&(indexImage<levelImage.Length-1)) {
			indexImage++;
		}
			
		// si es falso muestra que no esta disponible el nivel
		if (!GameDataCtrl.instance.GetGameData ().GetLevel (indexCtrl)) {
			ShowLevelDefault ();
		} else {
			ShowLevelInformation();
		}	
		
		//Debug.Log ("Index navigation: " + navigationIndexCtrl);
		//Debug.Log ("Index query: " + indexCtrl);

	}

	public void ShowLevelInformation(){
		levelName.text = levelInformation.levels [navigationIndexCtrl].levelName;
		levelDescription.text = levelInformation.levels [navigationIndexCtrl].levelDescription;
		levelImageIcon.sprite = levelImage[indexImage];
	}

	/// <summary>
	/// Shows The information when the level is no available .
	/// </summary>
	public void ShowLevelDefault(){
		levelName.text = levelInformation.levels [0].levelName;
		levelDescription.text = levelInformation.levels [0].levelDescription;
		levelImageIcon.sprite = levelImage[0];
	}
	
	public void GoToScene(){

		switch (navigationIndexCtrl) {
			case 3:
				changeToLevel02Plt ();
				break;
			case 4:
				changeToLevel02Plt ();
				break;
			case 7:
				changeToLevel04Plt ();
				break;
			case 8:
				changeToLevel04Plt ();
				break;
			case 11:
				changeToLevel06Plt ();
				break;
			case 12:
				changeToLevel06Plt ();
				break;
			case 15:
				changeToLevel08Plt ();
				break;
			case 16:
				changeToLevel08Plt ();
				break;
			case 20:
				changeToLevel10Plt ();
				break;
			case 21:
				changeToLevel10Plt ();
				break;
			case 22:
				changeToLevel10Plt ();
				break;
		}

		if (GameDataCtrl.instance.GetGameData ().GetLevel (indexCtrl)) {
			SceneManager.LoadScene (levelsName[indexCtrl]);
		}
	}

	public void changeToLevel02Plt(){
		GameDataCtrl.instance.SaveData (50f, 30f, 5f, 0, 2);
	}

	public void changeToLevel04Plt(){
		GameDataCtrl.instance.SaveData (60f, 40f, 15f, 0, 7);
	}

	public void changeToLevel06Plt(){
		GameDataCtrl.instance.SaveData (70f, 50f, 15f, 0, 10);
	}

	public void changeToLevel08Plt(){
		GameDataCtrl.instance.SaveData (80f, 60f, 20f, 0, 14);
	}

	public void changeToLevel10Plt(){
		GameDataCtrl.instance.SaveData (90f, 70f, 25f, 0, 18);
	}
}
