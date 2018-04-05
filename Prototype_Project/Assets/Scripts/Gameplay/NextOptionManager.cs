using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextOptionManager : MonoBehaviour {
	//option manager to be activated next
	public OptionManager optManager;

	//Starts when the GameObject is activated
	void OnEnable(){
		//activates the option manager gameobject
		optManager.gameObject.SetActive(true);
	}
}
