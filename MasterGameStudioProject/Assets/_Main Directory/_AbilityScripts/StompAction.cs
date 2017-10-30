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

		thisRigid.AddForce (-transform.up * 4000f);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Ground") {
			//Create some particles

			print ("yee");
			//Destroy (this.gameObject);
			thisRigid.AddForce (transform.up * 2700f);
			StartCoroutine("Die");

		}




		if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3" || col.gameObject.tag == "Player4"){
			thisRigid.AddForce (transform.up * 2700f);
			if (this.GetComponent<AttackAction>().teamNum != col.gameObject.GetComponent<PlayerState>().teamNum && !col.gameObject.GetComponent<PlayerMovement>().isRolling && col.gameObject != alreadyHit) {
				StartCoroutine("Die");
				col.gameObject.GetComponent<PlayerHealth> ().GetHit (this.GetComponent<AttackAction>().damage);
				col.gameObject.GetComponent<PlayerState> ().InflictStun (0.5f);
				alreadyHit = col.gameObject;
				//Destroy (this.gameObject);
			}
		}
	}
	public IEnumerator Die(){
		this.GetComponent<AttackAction> ().parentPoint = null;
		thisRigid.isKinematic = true;
		yield return new WaitForSeconds (0.5f);
		Destroy (this.gameObject);
		yield return null;
	}

}
