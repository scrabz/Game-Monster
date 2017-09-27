using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawTrapAction : MonoBehaviour {

	public Rigidbody thisRigid;
	RaycastHit hit;
	public float dist = 2f;
	public Vector3 downDir;
	// Use this for initialization
	void Start () {
		downDir = Vector3.down;
		thisRigid = this.GetComponent<Rigidbody> ();
		if (Physics.Raycast (transform.position, downDir, out hit, dist)) {
			if (hit.collider.tag == "Ground") {
				this.transform.position = hit.collider.gameObject.transform.position;
			}
		} else {
			Destroy (this.gameObject);
		}

	}


	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3" || col.gameObject.tag == "Player4") {
			if (this.GetComponent<AttackAction> ().teamNum != col.gameObject.GetComponent<PlayerState> ().teamNum && !col.gameObject.GetComponent<PlayerMovement> ().isRolling) {

				col.gameObject.GetComponent<PlayerHealth> ().GetHit (this.GetComponent<AttackAction> ().damage);
				col.gameObject.GetComponent<PlayerState> ().InflictStun (3f);
				Destroy (this.gameObject);
			}
		}
	}

}
