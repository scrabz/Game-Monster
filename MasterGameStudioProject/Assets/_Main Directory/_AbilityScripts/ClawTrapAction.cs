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
				this.transform.position = hit.point + new Vector3(0,0.25f,0);
				StartCoroutine ("Sink");
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
				this.GetComponent<Animator> ().SetBool ("isActivated", true);
				this.transform.position = new Vector3(transform.position.x,transform.position.y + 0.5f,transform.position.z);
				col.transform.position = new Vector3 (transform.position.x, col.transform.position.y, transform.position.z);
				col.gameObject.GetComponent<PlayerHealth> ().GetHit (this.GetComponent<AttackAction> ().damage);
				col.gameObject.GetComponent<PlayerState> ().InflictStun (2f);
				StartCoroutine ("Die");
			}
		}
	}

	public IEnumerator Sink(){
		for(int i = 0; i < 10f; i++) {
			this.transform.Translate (0, -0.1f, 0);
			yield return new WaitForSeconds (0.05f);


		}
		print ("done sinking");
		yield return null;
	}
	public IEnumerator Die(){
		yield return new WaitForSeconds (2f);
		Destroy (this.gameObject);
		yield return null;
	}
}
