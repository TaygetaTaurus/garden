using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public float treshold;
	public GameObject[] attackerPrefabArray;
	
	private float difficultyScaling;

	void Start(){
		difficultyScaling *= PlayerPrefsManager.GetDifficulty();
		
		if (PlayerPrefsManager.GetDifficulty() == 1){
			difficultyScaling = 4500000f;
		}else if(PlayerPrefsManager.GetDifficulty() == 2){
			difficultyScaling = 300000f;
		}else{
			difficultyScaling = 150000f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject thisAttacker in attackerPrefabArray){
			if (isTimeToSpawn(thisAttacker)){
				Spawn (thisAttacker);
			}
		}
	}
	
	
	bool isTimeToSpawn(GameObject attackerGameObject){
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnPerSecond = 1/meanSpawnDelay;
		
		
		if (Time.deltaTime > meanSpawnDelay){
			Debug.LogWarning("Spawn rate capped by frame rate");
		}
		
		treshold = (spawnPerSecond * Time.deltaTime / 5) + Time.timeSinceLevelLoad / difficultyScaling;
		return(Random.value < treshold);	
	}
	
	public void Spawn(GameObject myGameObject){
		GameObject myAttacker = Instantiate(myGameObject) as GameObject;
		Vector3 spawnPosition = transform.position;
		myAttacker.transform.parent = transform;
		if (myGameObject.GetComponent<Lizard>()){
			spawnPosition += new Vector3(-2.25f, 0f , 0f);
		}
		myAttacker.transform.position =  spawnPosition;
		
		/* //мой способ, тоже рабочий
		GameObject myAttacker;
		myAttacker = Instantiate(myGameObject, transform.position, Quaternion.identity) as GameObject;
		myAttacker.transform.parent = transform;
		*/
	}
}
