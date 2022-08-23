using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private int starsAmount = 100;
	private Text text;
	
	public enum Status {SUCCESS, FAILURE};
	
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		UpdateDisplay();
	}

	public void AddStars(int amount){
		starsAmount += amount;
		UpdateDisplay();
	}
	
	public Status UseStars(int defenderCost){
		if (starsAmount >= defenderCost){
			starsAmount -= defenderCost;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
	
	private void UpdateDisplay(){
		text.text = starsAmount.ToString();
	}
}
