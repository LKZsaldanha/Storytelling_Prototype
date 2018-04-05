using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OptionButtonEventCaller : MonoBehaviour {

	//playable director played
	public PlayableDirector currentDirector;
	//next playable director to go (optional)
	public PlayableDirector nextDirector;
	//scene to go (optional)
	public string sceneToGo;

	//change the game scene
	public void ChangeScene(){
		//loads the designated scene
		GameManager.instance.ChangeScene(sceneToGo);
	}

	//changes the playable director
	public void ChangePlayableDirector(){
		//plays the next playable director
		nextDirector.Play();
		//destroys the previous playable director
		Destroy(currentDirector.gameObject);
	}
		
}
