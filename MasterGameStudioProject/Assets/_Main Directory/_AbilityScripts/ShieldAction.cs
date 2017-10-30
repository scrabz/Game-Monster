using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAction : MonoBehaviour {

	// Use this for initialization
	public GameObject createdThing;
	public Vector3 reverseDir;

	public

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Projectile") {
			if (col.gameObject.GetComponent<AttackAction> ().teamNum != this.GetComponent<AttackAction> ().teamNum && col.gameObject.name != "ClawTrap(Clone)") {
				col.gameObject.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction> ().teamNum;
				col.GetComponent<Rigidbody> ().velocity = -col.GetComponent<Rigidbody> ().velocity;
			}

		}


	}
}
