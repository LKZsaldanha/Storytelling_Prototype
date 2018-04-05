using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	//global instance of gameManger
	public static GameManager instance;

	//curent scene name
	public string currentScene = "";

	void Awake(){
		//sets the gameManager to remain when changing scenes
		DontDestroyOnLoad(gameObject);

		//deletes this instance of gameManager if there was a gameManager created before
		if (instance == null) {
			instance = this;
		}else{
			DestroyImmediate(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		//set current scene to MainMenu at start of the game
		currentScene = "Menu_Main";
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ChangeScene (string nextScene){
		//change scene
		SceneManager.LoadScene(nextScene);
		//sets current scene to the new scene
		currentScene = nextScene;
	}

	public void SaveProgress (){
		//save game progress
	}
}
