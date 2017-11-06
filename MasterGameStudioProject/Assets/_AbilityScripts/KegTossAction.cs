using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KegTossAction : MonoBehaviour {

	public Rigidbody thisRigid;
	public GameObject createdThing;
	public GameObject alreadyHit;
	// Use this for initialization
	void Start () {
		thisRigid = this.GetComponent<Rigidbody> ();
		thisRigid.velocity = transform.forward * 8f;
		thisRigid.AddForce (transform.up * 1800f);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Solid") {
			createdThing = Instantiate (Resources.Load("ProjectileAttacks/KegSplat"), this.transform.position, Quaternion.Euler(this.transform.eulerAngles.x,this.transform.eulerAngles.y,this.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
			Destroy (this.gameObject);
		}




		if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3" || col.gameObject.tag == "Player4" ){
			if (this.GetComponent<AttackAction>().teamNum != col.gameObject.GetComponent<PlayerState>().teamNum && !col.gameObject.GetComponent<PlayerMovement>().isRolling && col.gameObject != alreadyHit) {

				col.gameObject.GetComponent<PlayerHealth> ().GetHit (this.GetComponent<AttackAction>().damage);
				alreadyHit = col.gameObject;
				//Destroy (this.gameObject);
			}
		}
	}


}
