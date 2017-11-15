using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NapalmArrowAction : MonoBehaviour {

	public Rigidbody thisRigid;
	public GameObject createdThing;
	public GameObject alreadyHit;
	public float dir = 1f;
	// Use this for initialization
	void Start () {
		thisRigid = this.GetComponent<Rigidbody> ();
		thisRigid.velocity = transform.forward * 9f * dir;
		thisRigid.AddForce (transform.up * 8800f);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Solid") {
			createdThing = Instantiate (Resources.Load("ProjectileAttacks/Napalm"), this.transform.position, Quaternion.Euler(this.transform.eulerAngles.x,this.transform.eulerAngles.y,this.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
			print ("napsss");
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
			Destroy (this.gameObject);
		}
	}


}
