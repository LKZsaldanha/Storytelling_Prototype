using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOver_ActivateGO : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler {
	public GameObject gameObjectToActivate;

	public void OnPointerEnter(PointerEventData eventData){
		gameObjectToActivate.SetActive (true);
	}
	public void OnPointerExit(PointerEventData eventData){
		gameObjectToActivate.SetActive (false);
	}
}
