using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed;
	public float damage;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		GameObject obj = collider.gameObject;
		if (obj.GetComponent<Attacker>() && obj.GetComponent<Health>()){
			Health targetHealth = obj.GetComponent<Health>();
			targetHealth.GetDamage(damage);
			Destroy(gameObject);
		}
		
	}
	
	// способ рабочий, но стоит ли так делать ?
	/* void OnTriggerEnter2D(Collider2D collider){
		Attacker attacker = collider.GetComponent<Attacker>();
		Health targetHealth = collider.GetComponent<Health>();
		if (attacker && targetHealth){
			targetHealth.GetDamage(damage);
			Destroy(gameObject);
		}
	}
	*/
}
