using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayWallAction : MonoBehaviour {
	public float health = 14f;

	public GameObject createdThing;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3" || col.gameObject.tag == "Player4") {

		}
	}
	void OnTriggerEnter(Collider col){





		if (col.gameObject.tag == "Projectile" || col.gameObject.tag == "Hitbox") {

			if (col.gameObject.name == "PunchHitbox(Clone)") {
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y + Random.Range(-360f,360f),col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y + Random.Range(-360f,360f),col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y + Random.Range(-360f,360f),col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y + Random.Range(-360f,360f),col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y + Random.Range(-360f,360f),col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y + Random.Range(-360f,360f),col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y + Random.Range(-360f,360f),col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y + Random.Range(-360f,360f),col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y + Random.Range(-360f,360f),col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;


				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y,col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y + 10,col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y + 20,col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y + 30,col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y + 40,col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y + 50,col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y - 10,col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y - 20,col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y - 30,col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y - 40,col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/ClayShardProjectile"), this.transform.position, Quaternion.Euler(col.transform.eulerAngles.x,col.transform.eulerAngles.y - 50,col.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = this.GetComponent<AttackAction>().teamNum;
				Destroy (this.gameObject);
			}

			if (col.gameObject.GetComponent<AttackAction> ().teamNum != this.GetComponent<AttackAction> ().teamNum) {
				health -= col.gameObject.GetComponent<AttackAction> ().damage;

				if (health <= 0) {
					Destroy (this.gameObject);
				}
			}
			if (this.gameObject.name != "GhostArrow(Clone)") {
				Destroy (col.gameObject);
			}
		}
	}
}
