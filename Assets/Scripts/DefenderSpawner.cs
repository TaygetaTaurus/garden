using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private	Camera myCamera;
	private StarDisplay starDisplay;
	private GameObject defenderParent;

	void Start(){
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		defenderParent = GameObject.Find("Defenders");
		myCamera = GameObject.FindObjectOfType<Camera>();
		
		if(!defenderParent){
			defenderParent = new GameObject("Defenders");
		}
	}
	
	void OnMouseDown(){
		Vector2 rawPos = CalculateWorldPointOfMouseClick();
		Vector2 roundedPos = SnapToGrid(rawPos);
		GameObject defender = Button.selectedDefender;
		
		int defenderCost = defender.GetComponent<Defender>().starCost;
		if(starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS){
			SpawnDefender(roundedPos, defender);
		}else{
			Debug.Log("Not enough stars for spawn");
		}
	}

	void SpawnDefender(Vector2 roundedPos, GameObject defender)
	{
		GameObject newDef = Instantiate (defender, roundedPos, Quaternion.identity) as GameObject;
		newDef.transform.parent = defenderParent.transform;
	}

	Vector2 SnapToGrid(Vector2 rawWorldPoint){
		float snapedWorldPointX = Mathf.RoundToInt(rawWorldPoint.x);
		float snapedWorldPointY = Mathf.RoundToInt(rawWorldPoint.y);
		
		return new Vector2(snapedWorldPointX, snapedWorldPointY);
	}
	// тут преобразование вектора3 в вектор2, можно ли так делать и вообще законно? Какие последствия ?
	Vector2 CalculateWorldPointOfMouseClick(){
		return myCamera.ScreenToWorldPoint(Input.mousePosition);
	}
}
