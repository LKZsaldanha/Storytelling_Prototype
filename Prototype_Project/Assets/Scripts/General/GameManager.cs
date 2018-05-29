using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//para testar
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	//global instance of gameManger
	public static GameManager instance;

	private SceneController sceneController;

	private void Awake(){
		//deletes this instance of gameManager if there was a gameManager created before
		if (instance == null) {
			instance = this;
		}else{
			DestroyImmediate(gameObject);
		}
		sceneController = FindObjectOfType<SceneController> ();
	}

	public void ChangeScene (string nextScene){
		//"if" para testar de qualquer cena
		if(sceneController){
			sceneController.FadeAndLoadScene(nextScene);
		}else{
			SceneManager.LoadScene(nextScene);
		}
	}
}
