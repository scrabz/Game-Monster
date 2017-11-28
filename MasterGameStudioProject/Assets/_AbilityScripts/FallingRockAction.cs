using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRockAction : MonoBehaviour {

	public Rigidbody thisRigid;
	public GameObject createdThing;
	public GameObject alreadyHit;
	public float dir = 1f;
	// Use this for initialization
	void Start () {
		thisRigid = this.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Solid") {
		createdThing = Instantiate (Resources.Load("ProjectileAttacks/VolcanoRockExplosion"), this.transform.position, Quaternion.Euler(this.transform.eulerAngles.x,this.transform.eulerAngles.y,this.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
			Destroy (this.gameObject);
		}
	}


}
