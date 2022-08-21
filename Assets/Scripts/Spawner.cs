using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;

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
		
		float treshold = spawnPerSecond * Time.deltaTime / 5;
		if(Random.value < treshold){
			return true;
		}else{
			return false;
		}		
	}
	
	public void Spawn(GameObject myGameObject){
		GameObject myAttacker = Instantiate(myGameObject) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
		
		/* //мой способ, тоже рабочий
		GameObject myAttacker;
		myAttacker = Instantiate(myGameObject, transform.position, Quaternion.identity) as GameObject;
		myAttacker.transform.parent = transform;
		*/
	}
}
