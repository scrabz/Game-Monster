using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHitboxActions : MonoBehaviour {
	public GameObject alreadyHit;
	public Vector3 pushBackDir;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Solid") {
			//Destroy (this.gameObject);
		}
		if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3" || col.gameObject.tag == "Player4"){
			if (this.GetComponent<AttackAction>().teamNum != col.gameObject.GetComponent<PlayerState>().teamNum && col.gameObject != alreadyHit) {
				//Dont let Brogre get hurt by this if he's shielding
				//if (!col.gameObject.GetComponent<PlayerAbilities> ().doingAbil2 && !col.gameObject.GetComponent<PlayerAbilities> ().doingAbil3 && this.gameObject.name == "Brogre(Clone)") {
				if (!col.gameObject.name.Contains("Dummy")){
					col.gameObject.GetComponent<PlayerHealth> ().GetHit (this.GetComponent<AttackAction> ().damage);
				}
				else{
					col.gameObject.GetComponent<DummyHealth> ().GetHit (this.GetComponent<AttackAction> ().damage);
				}
					pushBackDir = this.GetComponent<AttackAction>().creator.transform.Find("RotationPoint").forward;
				if (this.gameObject.name != "DashHitbox(Clone)" && this.gameObject.name != "PetrifyHitbox(Clone)" && this.gameObject.name != "WhipHitbox(Clone)") {
						col.gameObject.GetComponent<PlayerState> ().Pushback (0.025f, pushBackDir);
					}
					alreadyHit = col.gameObject;
				//}
				if (this.gameObject.name == "ShieldShockwaveHitbox(Clone)") {
					pushBackDir = this.GetComponent<AttackAction>().creator.transform.Find("RotationPoint").forward;
					col.GetComponent<PlayerState> ().InflictStun (1f);
					col.gameObject.GetComponent<PlayerState> ().Pushback (0.15f,pushBackDir);
					this.GetComponent<Rigidbody> ().isKinematic = true;
				}
				if (this.gameObject.name == "GroundSlamHitbox(Clone)") {
					pushBackDir = this.GetComponent<AttackAction>().creator.transform.Find("RotationPoint").forward;
					col.GetComponent<PlayerState> ().InflictStun (2f);
					//col.gameObject.GetComponent<PlayerState> ().Pushback (0.15f,pushBackDir);
					this.GetComponent<Rigidbody> ().isKinematic = true;
				}


				if (this.gameObject.name == "PetrifyHitbox(Clone)") {
					//pushBackDir = this.GetComponent<AttackAction>().creator.transform.Find("RotationPoint").forward;
					col.GetComponent<PlayerState> ().InflictStun (1.5f);
					Destroy (this.GetComponent<Collider>());
				}

				if (this.gameObject.name == "PunchHitbox(Clone)") {
					pushBackDir = this.GetComponent<AttackAction>().creator.transform.Find("RotationPoint").forward;
					col.gameObject.GetComponent<PlayerState> ().Pushback (0.35f,pushBackDir);
					Destroy (this.GetComponent<Collider>());
				}

				if (this.gameObject.name == "WhipHitbox(Clone)") {
					this.GetComponent<AttackAction> ().creator.GetComponent<PlayerAbilities> ().gotSomeone = true;
					pushBackDir = this.GetComponent<AttackAction>().creator.transform.Find("RotationPoint").forward;
					col.gameObject.transform.position = this.GetComponent<AttackAction>().creator.transform.Find ("RotationPoint").Find ("SpawningPoint1").position;
					col.gameObject.GetComponent<PlayerState> ().InflictStun (0.50f);
					Destroy (this.GetComponent<Collider>());
				}

			}
		}
	}




}
