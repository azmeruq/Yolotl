using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCtrl : MonoBehaviour {

	/*public void changeScene(string sceneName){
		GameDataCtrl.instance.CreateNewGameData ();
		SceneManager.LoadScene (sceneName);
	}*/
	public GameObject warnningwindow;
	//public GameObject acceptBotton;
	public GameObject cancelBotton;
	public Text textNature;
	public Text textDescription;
	private bool isLoading;

	private void CreateNewGame(){
		GameDataCtrl.instance.CreateNewGameData ();
		SceneManager.LoadScene ("00_LevelSelector");
	}

	public void LoadGame(){
		isLoading = true;
		if (GameDataCtrl.instance.DoesGameDataExist ()) {
			GameDataCtrl.instance.LoadData ();
			SceneManager.LoadScene ("00_LevelSelector");
		} else {
			warnningwindow.SetActive (true);
			cancelBotton.SetActive (false);
			textNature.text = "Partida no encontrada: ";
			textDescription.text = "No se pudieron encontrar datos de una partida previamente guardada. Inicie una nueva partida para jugar.";
		}
	}

	public void OpenWarnningWindow(){
		isLoading = false;
		warnningwindow.SetActive (true);
		cancelBotton.SetActive (true);
		textNature.text = "Advertencia: ";
		textDescription.text = "Se eliminarán todos los datos previamente guardados. ¿Desea crear una nueva partida?";
	}

	public void CloseWarnningWindow(){
		warnningwindow.SetActive (false);
	}

	public void AcceptBottomBehaviour(){
		if (isLoading) {
			CloseWarnningWindow ();
		} else {
			CreateNewGame ();
		}
	}
	

}
