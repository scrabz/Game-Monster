using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayWallAction : MonoBehaviour {
	public float health = 20f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Projectile" || col.gameObject.tag == "Hitbox") {
			if (col.gameObject.GetComponent<AttackAction> ().teamNum != this.GetComponent<AttackAction> ().teamNum) {
				health -= col.gameObject.GetComponent<AttackAction> ().damage;
				Destroy (col.gameObject);
				if (health <= 0) {
					Destroy (this.gameObject);
				}
			}
		}
	}
}
