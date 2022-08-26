using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject gun;
	public AudioClip fireSound;
	
	private Spawner myLaneSpawner;
	private Animator animator;
	private GameObject projectileParent;
	
	void Start(){
		animator = GetComponent<Animator>();
		
		//creates parrent if necessary
		projectileParent = GameObject.Find("Projectiles");
		if(!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}
		
		SetMyLaneSpawner();
	}
	
	void Update(){
		if(IsAttackerAheadInLane()){
			animator.SetBool("isAttacking", true);
		}else{
			animator.SetBool("isAttacking", false);
		}
	}
	
	void SetMyLaneSpawner(){
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
		
		foreach(Spawner thisSpawner in spawnerArray){
			if (thisSpawner.transform.position.y == transform.position.y){
				myLaneSpawner = thisSpawner;
				return;
			}	
		}
		
		Debug.LogError(name + " Cant find spawner for y = " + transform.position.y + " lane");
	}
	
	bool IsAttackerAheadInLane(){
		//exit if no attackers in lane
		if(myLaneSpawner.transform.childCount <= 0){
			return false;
		}
		
		//if there are attackers, are they ahead?
		foreach(Transform attacker in myLaneSpawner.transform){
			if(attacker.transform.position.x > transform.position.x){
				return true;
			}
		}
		//Attacker in lane, but behind us
		return false;
	}
	
	private void Fire(){
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
		
		AudioSource.PlayClipAtPoint(fireSound, transform.position, PlayerPrefsManager.GetMasterVolume());
	}
	
}
