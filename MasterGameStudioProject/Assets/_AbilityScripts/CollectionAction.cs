using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionAction : MonoBehaviour {

	// Use this for initialization
	public GameObject createdThing;
	void Start () {
		if (this.GetComponent<AttackAction> ().creator.GetComponent<PlayerAbilities> ().storedProjectiles.Count >= 1) {
			Debug.Log (this.GetComponent<AttackAction> ().creator.GetComponent<PlayerAbilities> ().storedProjectiles.Count);
			createdThing = Instantiate (this.GetComponent<AttackAction> ().creator.GetComponent<PlayerAbilities> ().storedProjectiles [0], this.transform.position, Quaternion.Euler (this.transform.eulerAngles.x, this.transform.eulerAngles.y - 20, this.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction> ().teamNum;
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			createdThing.GetComponent<AttackAction> ().damage = createdThing.GetComponent<AttackAction> ().damage * 2;
			Physics.IgnoreCollision (this.GetComponent<Collider> (), createdThing.GetComponent<Collider> ());
			Destroy (this.gameObject);
		}
			if (this.GetComponent<AttackAction> ().creator.GetComponent<PlayerAbilities> ().storedProjectiles.Count >= 2) {
				createdThing = Instantiate (this.GetComponent<AttackAction> ().creator.GetComponent<PlayerAbilities> ().storedProjectiles [1], this.transform.position, Quaternion.Euler (this.transform.eulerAngles.x, this.transform.eulerAngles.y - 10, this.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction> ().teamNum;
				createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			createdThing.GetComponent<AttackAction> ().damage = createdThing.GetComponent<AttackAction> ().damage * 2;
				Physics.IgnoreCollision (this.GetComponent<Collider> (), createdThing.GetComponent<Collider> ());
				Destroy (this.gameObject);
			}
		if (this.GetComponent<AttackAction> ().creator.GetComponent<PlayerAbilities> ().storedProjectiles.Count >= 3) {
			createdThing = Instantiate (this.GetComponent<AttackAction> ().creator.GetComponent<PlayerAbilities> ().storedProjectiles [2], this.transform.position, Quaternion.Euler (this.transform.eulerAngles.x, this.transform.eulerAngles.y + 10, this.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction> ().teamNum;
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			createdThing.GetComponent<AttackAction> ().damage = createdThing.GetComponent<AttackAction> ().damage * 2;
			Physics.IgnoreCollision (this.GetComponent<Collider> (), createdThing.GetComponent<Collider> ());
			Destroy (this.gameObject);
		}
		if (this.GetComponent<AttackAction> ().creator.GetComponent<PlayerAbilities> ().storedProjectiles.Count >= 4) {
			createdThing = Instantiate (this.GetComponent<AttackAction> ().creator.GetComponent<PlayerAbilities> ().storedProjectiles [3], this.transform.position, Quaternion.Euler (this.transform.eulerAngles.x, this.transform.eulerAngles.y + 20, this.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction> ().teamNum;
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			createdThing.GetComponent<AttackAction> ().damage = createdThing.GetComponent<AttackAction> ().damage * 2;
			Physics.IgnoreCollision (this.GetComponent<Collider> (), createdThing.GetComponent<Collider> ());
			Destroy (this.gameObject);
		}

			this.GetComponent<AttackAction> ().creator.GetComponent<PlayerAbilities> ().storedProjectiles.Clear ();
			print (this.GetComponent<AttackAction> ().creator.GetComponent<PlayerAbilities> ().storedProjectiles.Count);
			

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Projectile") {
			if (this.GetComponent<AttackAction> ().teamNum != col.GetComponent<AttackAction> ().teamNum) {
				if (this.GetComponent<AttackAction> ().creator.GetComponent<PlayerAbilities> ().storedProjectiles.Count < 4) {
					this.GetComponent<AttackAction> ().creator.GetComponent<PlayerAbilities> ().storedProjectiles.Add (Resources.Load ("ProjectileAttacks/" + col.gameObject.name.Substring (0, col.gameObject.name.Length - 7)) as GameObject);
				}
				Destroy (col.gameObject);

			}

		}


	}
}
