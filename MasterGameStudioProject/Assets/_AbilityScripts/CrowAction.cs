using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowAction : MonoBehaviour {
	public Rigidbody thisRigid;
	public GameObject collisionObject;
	public Vector3 pushBackDir;
	public bool flyAway = false;
	// Use this for initialization
	void Start () {
		thisRigid = this.GetComponent<Rigidbody> ();
		thisRigid.velocity = transform.forward * 15f;
	}

	// Update is called once per frame
	void Update () {
		if (flyAway) {
			transform.Translate (0, 0.1f, 0);
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Solid") {
			Destroy (this.gameObject);
		}
		if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3" || col.gameObject.tag == "Player4"){
			if (this.GetComponent<AttackAction>().teamNum != col.gameObject.GetComponent<PlayerState>().teamNum && !col.gameObject.GetComponent<PlayerMovement>().isRolling) {
				col.gameObject.GetComponent<PlayerHealth> ().GetHit (this.GetComponent<AttackAction>().damage);
				pushBackDir = this.GetComponent<AttackAction>().creator.transform.Find("RotationPoint").forward;
				collisionObject = col.gameObject;
				col.gameObject.GetComponent<PlayerState> ().Pushback (0.15f,thisRigid.velocity.normalized);
				this.GetComponent<AudioSource> ().Play ();
				flyAway = true;

			}
		}


	}
		
}
