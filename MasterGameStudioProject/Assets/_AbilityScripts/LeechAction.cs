using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeechAction : MonoBehaviour {
	public Rigidbody thisRigid;
	public Vector3 pushBackDir;
	public bool moving = true;
	// Use this for initialization
	void Start () {
		thisRigid = this.GetComponent<Rigidbody> ();
		thisRigid.velocity = transform.forward * 25f;

	}
	
	// Update is called once per frame
	void Update () {
		if (moving == false) {
			thisRigid.isKinematic = true;
			Material mat = transform.Find("LeechModel").GetComponent<Renderer>().material;
			Color color = mat.color;
			mat.color = new Color(color.r, color.g, color.b, color.a - (0.5f * Time.deltaTime));
			if (mat.color.a <= 0) {
				Destroy (this.gameObject);
			}
		}
			

	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Solid") {
			thisRigid.velocity = Vector3.zero;
			moving = false;
		}



		if (moving) {
			if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3" || col.gameObject.tag == "Player4") {
				if (this.GetComponent<AttackAction> ().teamNum != col.gameObject.GetComponent<PlayerState> ().teamNum && !col.gameObject.GetComponent<PlayerMovement> ().isRolling && moving == true) {
					Destroy (thisRigid);
					this.transform.SetParent (col.gameObject.transform);
					col.gameObject.GetComponent<PlayerHealth> ().GetHit (this.GetComponent<AttackAction> ().damage);
					col.gameObject.GetComponent<PlayerState> ().InflictPoison (5f);
//				pushBackDir = this.GetComponent<Rigidbody> ().velocity.normalized * 1.2f;
//				col.GetComponent<CharacterController> ().Move (pushBackDir);
					moving = false;
				}
			}
		}
	}
}
