using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class NextPlayableDirection : MonoBehaviour {

    //playble director to play next
    public GameObject director;
	public PlayableDirector nextDirector;

	//Starts when the GameObject is activated
	void OnEnable(){
        //plays the next playable director
        if (director != null)
        {
            director.SetActive(true);
            gameObject.SetActive(false);
        }
		nextDirector.Play();
		//destroys this gameobject parent (previous playable director)
		Destroy(transform.parent.gameObject);
	}
}
