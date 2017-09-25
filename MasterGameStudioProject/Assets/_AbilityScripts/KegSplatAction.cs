using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KegSplatAction : MonoBehaviour {

	public Rigidbody thisRigid;

	// Use this for initialization
	void Start () {
		thisRigid = this.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.tag == "Solid") {
			Destroy (this.gameObject);
		}




		if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3" || col.gameObject.tag == "Player4" ){
			if (this.GetComponent<AttackAction>().teamNum != col.gameObject.GetComponent<PlayerState>().teamNum && !col.gameObject.GetComponent<PlayerMovement>().isRolling) {

				col.gameObject.GetComponent<PlayerHealth> ().GetHit (this.GetComponent<AttackAction>().damage);
				if (!col.gameObject.GetComponent<PlayerState>().isSlowed){
				col.GetComponent<PlayerState> ().InflictSlowed (1f);
				}
				//Destroy (this.gameObject);
			}
		}
	}
}
