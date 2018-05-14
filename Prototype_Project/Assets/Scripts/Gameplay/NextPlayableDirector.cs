using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class NextPlayableDirector : MonoBehaviour {

    //playble director to play next
	public PlayableDirector nextDirector;

	public bool willChangeScene = false;

	GameObject currentDirector;



	//Starts when the GameObject is activated
	void OnEnable(){
		currentDirector = transform.parent.gameObject;
        //plays the next playable director
		if(willChangeScene){
			ChangeScene changeScene = GetComponent<ChangeScene>();
			if(changeScene != null){
				changeScene.GoToScene();
			}else{
				Debug.Log ("Componente CHANGE SCENE não encontrado");
			}
		}else{				
			if (nextDirector != null){
				nextDirector.gameObject.SetActive(true);
	        }
			nextDirector.Play();
		}
		currentDirector.gameObject.SetActive(false);
		///destroys this gameobject parent (previous playable director)
		Destroy(currentDirector.gameObject,1f);
	}
}
