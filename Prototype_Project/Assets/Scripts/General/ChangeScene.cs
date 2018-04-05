using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

	//scene name
	public string sceneToGo;

	//changes scene
	public void GoToScene(){
		//calls function from gameManager
		GameManager.instance.ChangeScene(sceneToGo);
	}
}
