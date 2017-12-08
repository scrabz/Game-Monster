using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayShardAction : MonoBehaviour {
	public Rigidbody thisRigid;
	public Vector3 pushBackDir;
	// Use this for initialization
	void Start () {
		thisRigid = this.GetComponent<Rigidbody> ();
		thisRigid.velocity = transform.forward * 25f;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Solid") {
			Destroy (this.gameObject);
		}




		if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3" || col.gameObject.tag == "Player4"){
			if (this.GetComponent<AttackAction>().teamNum != col.gameObject.GetComponent<PlayerState>().teamNum && !col.gameObject.GetComponent<PlayerMovement>().isRolling) {
				
				col.gameObject.GetComponent<PlayerHealth> ().GetHit (this.GetComponent<AttackAction>().damage);
//				pushBackDir = this.GetComponent<Rigidbody> ().velocity.normalized * 1.2f;
//				col.GetComponent<CharacterController> ().Move (pushBackDir);
				Destroy (this.gameObject);
			}
		}
		if (col.gameObject.tag == "Player2" && col.gameObject.name.Contains ("Dummy")) {
			if (this.GetComponent<AttackAction>().teamNum != col.gameObject.GetComponent<PlayerState>().teamNum && !col.gameObject.GetComponent<PlayerMovement>().isRolling) {

				col.gameObject.GetComponent<DummyHealth> ().GetHit (this.GetComponent<AttackAction>().damage);
				//				pushBackDir = this.GetComponent<Rigidbody> ().velocity.normalized * 1.2f;
				//				col.GetComponent<CharacterController> ().Move (pushBackDir);
				Destroy (this.gameObject);
			}
		}
	}
}
