using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicArrowAction : MonoBehaviour {
	public Rigidbody thisRigid;
	public Vector3 pushBackDir;
	public GameObject collisionObject;
	public bool moving = true;
	public GameObject createdThing;

	float explodeTimer = 0.15f;
	// Use this for initialization
	void Start () {
		thisRigid = this.GetComponent<Rigidbody> ();
		if (gameObject.name == "BasicArrow(Clone)") {
			thisRigid.velocity = transform.forward * 60f;
		}
		if (gameObject.name == "ScatterArrow(Clone)") {
			thisRigid.velocity = transform.forward * 30f;
		}

		if (gameObject.name == "GhostArrow(Clone)") {
			thisRigid.velocity = transform.forward * 15f;
		}


	}
	
	// Update is called once per frame
	void Update () {
		//print (thisRigid.velocity);
		//print (thisRigid.velocity.magnitude);
		if (gameObject.name == "GhostArrow(Clone)") {
			//this.transform.eulerAngles = transform.forward + new Vector3(0,Mathf.Sin (Time.time * 80f),0) * 2f;
			thisRigid.velocity = transform.forward * 18f;
		}

		if (gameObject.name == "BasicArrow(Clone)") {
			if (thisRigid.velocity.magnitude > 30f) {
				thisRigid.velocity = thisRigid.velocity + (-transform.forward * 1.5f);

			} else {
				thisRigid.useGravity = true;
			}
		}

		if (moving == false) {
			thisRigid.isKinematic = true;
			Material mat = transform.Find("GameObject").Find("GuyArrowFBX").GetComponent<Renderer>().material;
			Color color = mat.color;
			mat.color = new Color(color.r, color.g, color.b, color.a - (0.5f * Time.deltaTime));
			if (mat.color.a <= 0) {
				Destroy (this.gameObject);
			}
		}

		if (this.gameObject.name == "ScatterArrow(Clone)") {
			explodeTimer -= Time.deltaTime;
			if (explodeTimer <= 0) {
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/BasicArrow"), transform.position, Quaternion.Euler(this.transform.eulerAngles.x,this.transform.eulerAngles.y - 20f,this.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
				Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/BasicArrow"), transform.position, Quaternion.Euler(this.transform.eulerAngles.x,this.transform.eulerAngles.y - 10f,this.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
				Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/BasicArrow"), transform.position, Quaternion.Euler(this.transform.eulerAngles.x,this.transform.eulerAngles.y,this.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
				Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/BasicArrow"), transform.position, Quaternion.Euler(this.transform.eulerAngles.x,this.transform.eulerAngles.y + 10f,this.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
				Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/BasicArrow"), transform.position, Quaternion.Euler(this.transform.eulerAngles.x,this.transform.eulerAngles.y + 20f,this.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
				Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
				Destroy (this.gameObject);
			}

		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Solid" || col.gameObject.tag == "Ground"){
			if (gameObject.name == "BasicArrow(Clone)" || gameObject.name == "StunArrow(Clone)" || gameObject.name == "ScatterArrow") {
				moving = false;
				thisRigid.velocity = Vector3.zero;
			}
			if (gameObject.name == "BouncyArrow(Clone)") {
				thisRigid.AddRelativeForce (transform.forward * 16f);
			}
//			if (gameObject.name == "ScatterArrow(Clone)") {
//				createdThing = Instantiate (Resources.Load("ProjectileAttacks/BasicArrow"), transform.InverseTransformDirection(transform.position), Quaternion.Euler(this.transform.eulerAngles.x,-this.transform.eulerAngles.y - 160f,this.transform.eulerAngles.z)) as GameObject;
//				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
//				createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
//				Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
//				createdThing = Instantiate (Resources.Load("ProjectileAttacks/BasicArrow"), transform.InverseTransformDirection(transform.position), Quaternion.Euler(this.transform.eulerAngles.x,-this.transform.eulerAngles.y - 170f,this.transform.eulerAngles.z)) as GameObject;
//				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
//				createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
//				Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
//				createdThing = Instantiate (Resources.Load("ProjectileAttacks/BasicArrow"), transform.InverseTransformDirection(transform.position), Quaternion.Euler(this.transform.eulerAngles.x,-this.transform.eulerAngles.y - 180f,this.transform.eulerAngles.z)) as GameObject;
//				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
//				createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
//				Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
//				createdThing = Instantiate (Resources.Load("ProjectileAttacks/BasicArrow"), transform.InverseTransformDirection(transform.position), Quaternion.Euler(this.transform.eulerAngles.x,-this.transform.eulerAngles.y - 190f,this.transform.eulerAngles.z)) as GameObject;
//				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
//				createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
//				Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
//				createdThing = Instantiate (Resources.Load("ProjectileAttacks/BasicArrow"), this.transform.position, Quaternion.Euler(this.transform.eulerAngles.x,-this.transform.eulerAngles.y - 200f,this.transform.eulerAngles.z)) as GameObject;
//				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
//				createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
//				Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
//				Destroy (this.gameObject);
//			}
		}




		if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3" || col.gameObject.tag == "Player4"){
			if (this.GetComponent<AttackAction>().teamNum != col.gameObject.GetComponent<PlayerState>().teamNum && !col.gameObject.GetComponent<PlayerMovement>().isRolling) {
				col.gameObject.GetComponent<PlayerHealth> ().GetHit (this.GetComponent<AttackAction>().damage);

				if (this.gameObject.name == "StunArrow(Clone)"){
					col.gameObject.GetComponent<PlayerState> ().InflictStun (1.5f);
				}
				pushBackDir = this.GetComponent<AttackAction>().creator.transform.Find("RotationPoint").forward;
				collisionObject = col.gameObject;
				//col.gameObject.GetComponent<PlayerState> ().Pushback (0.01f,thisRigid.velocity.normalized);
				if (this.gameObject.name != "GhostArrow") {
					Destroy (this.gameObject);
				}

			}
		}
	}

	void OnTriggerStay(Collider col){

		if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3" || col.gameObject.tag == "Player4") {
			if (this.gameObject.name == "GhostArrow(Clone)") {
				if (this.GetComponent<AttackAction> ().teamNum != col.gameObject.GetComponent<PlayerState> ().teamNum && !col.gameObject.GetComponent<PlayerMovement> ().isRolling) {
					col.gameObject.GetComponent<PlayerHealth> ().GetHit (this.GetComponent<AttackAction> ().damage * 2f);
					col.gameObject.GetComponent<PlayerState> ().InflictSlowed (2f);
					if (this.gameObject.name == "StunArrow(Clone)") {
						col.gameObject.GetComponent<PlayerState> ().InflictStun (1.5f);
					}
					pushBackDir = this.GetComponent<AttackAction> ().creator.transform.Find ("RotationPoint").forward;
					collisionObject = col.gameObject;
					//col.gameObject.GetComponent<PlayerState> ().Pushback (0.01f,thisRigid.velocity.normalized);

				}
			}
		}
	}


}
