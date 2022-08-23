using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {
	
	public static GameObject selectedDefender;
	public GameObject defenderPrefab;
	
	private Button[] buttonArray;
	private Text costText;
	
	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();
		costText = GetComponentInChildren<Text>();
		if(!costText){
			Debug.LogWarning(name + " has no cost");
		}
		
		costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
	}

	void OnMouseDown(){
		foreach(Button thisButton in buttonArray){
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		GetComponent<SpriteRenderer>().color = Color.white;
		
		selectedDefender = defenderPrefab;
	}
}
