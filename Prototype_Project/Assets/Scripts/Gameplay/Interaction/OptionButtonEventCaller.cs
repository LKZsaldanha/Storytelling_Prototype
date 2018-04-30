using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OptionButtonEventCaller : MonoBehaviour {

	//playable director played
	public PlayableDirector currentDirector;
	//next playable director to go (optional)
	public PlayableDirector nextDirector;
    public GameObject director;
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
        if (director != null)
        {
            director.SetActive(true);
            gameObject.SetActive(false);
        }
        nextDirector.Play();
		//destroys the previous playable director
		Destroy(currentDirector.gameObject);
	}
		
}
