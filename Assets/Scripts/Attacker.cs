using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySeconds;
	
	private Animator animator;
	private float currentSpeed;
	private GameObject currentTarget;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		
		if(!currentTarget){
			animator.SetBool("isAttacking", false);
		}
	}
	
	public void SetSpeed(float speed){
		currentSpeed = speed;
	}
	
	public void StrikeCurrentTarget(float damage){
		if(currentTarget){
			Health health = currentTarget.GetComponent<Health>();
			if(health){
				health.GetDamage(damage);
			}
		}
	}
	
	public void Attack(GameObject obj){
		currentTarget = obj;
	}
}







