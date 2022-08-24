using UnityEngine;
using System.Collections;

public class Jabba : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		GameObject obj = collider.gameObject;
		
		if (!obj.GetComponent<Defender>()){
			return;
		}
		
		anim.SetBool("isAttacking", true);
		attacker.Attack(obj);
	}
}
