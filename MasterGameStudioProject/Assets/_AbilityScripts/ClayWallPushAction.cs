using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayWallPushAction : MonoBehaviour {

	public GameObject createdThing;
	// Use this for initialization

	float thingTimer = 0.5f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		thingTimer -= Time.deltaTime;
		if (thingTimer <= 0) {
			DoThing ();
		}
	}
	void OnTriggerEnter(Collision col){
		if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3" || col.gameObject.tag == "Player4") {
			col.gameObject.GetComponent<PlayerState> ().Pushback (1f, -this.transform.forward);
			Debug.Log ("blip");

		}
	}

	public void DoThing(){
		createdThing = Instantiate (Resources.Load("SpecialAttacks/ClayWall"), this.transform.position, Quaternion.Euler(this.transform.eulerAngles.x,this.transform.eulerAngles.y,this.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		Destroy (this.gameObject);
	}
}
