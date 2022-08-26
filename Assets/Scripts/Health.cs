﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 100f;
	public AudioClip deathSound;

	public void GetDamage(float damage){
		health -= damage;
		if(health <= 0){
			DestroyObject();
		}
	}
	
	public void DestroyObject(){
		AudioSource.PlayClipAtPoint(deathSound, transform.position, PlayerPrefsManager.GetMasterVolume());
		Destroy(gameObject);
	}
}
