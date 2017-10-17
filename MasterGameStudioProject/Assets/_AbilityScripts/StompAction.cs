using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompAction : MonoBehaviour {

	public Rigidbody thisRigid;
	public GameObject createdThing;
	public GameObject alreadyHit;
	// Use this for initialization
	void Start () {
		thisRigid = this.GetComponent<Rigidbody> ();

		thisRigid.AddForce (-transform.up * 2700f);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Solid") {
			//Create some particles
			thisRigid.AddForce (Vector3.zero,ForceMode.VelocityChange);
			Destroy (this.gameObject);

		}




		if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3" || col.gameObject.tag == "Player4"){
			if (this.GetComponent<AttackAction>().teamNum != col.gameObject.GetComponent<PlayerState>().teamNum && !col.gameObject.GetComponent<PlayerMovement>().isRolling && col.gameObject != alreadyHit) {

				col.gameObject.GetComponent<PlayerHealth> ().GetHit (this.GetComponent<AttackAction>().damage);
				alreadyHit = col.gameObject;
				//Destroy (this.gameObject);
			}
		}
	}
	public IEnumerator Die(){
		yield return new WaitForSeconds (2f);
		Destroy (this.gameObject);
		yield return null;
	}

}
