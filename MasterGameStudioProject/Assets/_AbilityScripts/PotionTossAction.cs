using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionTossAction : MonoBehaviour {

	public Rigidbody thisRigid;
	public GameObject createdThing;
	public GameObject alreadyHit;
	// Use this for initialization
	void Start () {
		thisRigid = this.GetComponent<Rigidbody> ();
		thisRigid.velocity = transform.forward * 7f;
		thisRigid.AddForce (transform.up * 10800f);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Solid") {
			createdThing = Instantiate (Resources.Load("ProjectileAttacks/PotionExplosion"), this.transform.position, Quaternion.Euler(this.transform.eulerAngles.x,this.transform.eulerAngles.y,this.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
			print ("happened");
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			//Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
			Destroy (this.gameObject);
		}
	}


}
