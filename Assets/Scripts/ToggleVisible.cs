using UnityEngine;
using System.Collections;

public class ToggleVisible : MonoBehaviour {
	
	private bool isActive = false;
	private GameObject[] levelButtonsArray;
	
	
	// Use this for initialization
	void Start () {
	
		levelButtonsArray = GameObject.FindGameObjectsWithTag("levelButton");
		foreach (GameObject thisButton in levelButtonsArray){
			thisButton.SetActive(isActive);
		}
	}

	public void Toggle(){
		isActive = !isActive;

		foreach (GameObject thisButton in levelButtonsArray){
			thisButton.SetActive(isActive);
		}

	}
}
