using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour {

	//Time limit for player decision. Infinite if set to 0
	public float timeLimit;
	//time left for player decision
	public float timeLeft;

	//time progressbar. Not necessary if time limit equals 0
	public Image progressBar;

	//array of buttons
	public GameObject [] buttons;
	//array of buttons' text
	public string [] options;

	//scene to go if timeends (optional)
	public bool goToSceneIfTimeEnds;
	//component that changes scenes
	public ChangeScene sceneChanger;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < buttons.Length; i++){
			//sets text of each button
			buttons[i].GetComponentInChildren<Text>().text = options[i];
			//deactivate buttons
			buttons[i].SetActive(false);
			//resets timeLeft
			timeLeft = timeLimit;
			//deactivate the whole progressbar 
			progressBar.transform.parent.gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//if timeLimit equals 0, there is no timeLimit
		if(timeLimit >0){
			//if there is time left
			if(timeLeft >0){
				for (int i = 0; i < buttons.Length; i++){
					//activate buttons
					buttons[i].SetActive(true);
				}
				//checks if the progressbar exists
				if(progressBar != null){
					//activate the whole progressbar 
					progressBar.transform.parent.gameObject.SetActive(true);
					//sets progressbar fillamout
					progressBar.fillAmount = timeLeft/timeLimit;
				}
				//deacreases time left
				timeLeft -= Time.deltaTime;
			}else{
				//calls function if no option was selected
				NoOptionSelected(goToSceneIfTimeEnds);
			}
		}else{
			for (int i = 0; i < buttons.Length; i++){
				//activate buttons
				buttons[i].SetActive(true);
			}
		}
		
	}

	public void OptionSelected(){
		//deactivate everything
		this.gameObject.SetActive(false);
	}

	public void NoOptionSelected(bool scene){
		//deactivate everything
		this.gameObject.SetActive(false);
		//checks if it should go to another scene
		if(scene){
			//calls function from other component
			sceneChanger.GoToScene();
		}else{
			//call playable director
		}
	}
}
