using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

	private Animator animator;
	
	void Start(){
		animator = GetComponent<Animator>();
	}

	void OnTriggerStay2D(Collider2D collider){
		Attacker attacker  = collider.GetComponent<Attacker>();
		if (attacker){
			animator.SetTrigger("underAttackTrigger");
		}
	}
}
