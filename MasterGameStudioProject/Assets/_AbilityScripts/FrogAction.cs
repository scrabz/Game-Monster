using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAction : MonoBehaviour {

	public Rigidbody thisRigid;
	RaycastHit hit;
	public float dist = 2f;
	public Vector3 downDir;
	public GameObject createdThing;

	public List<GameObject> opponentList = new List<GameObject>();
	// Use this for initialization

	public GameObject whoToFollow;
	public GameObject[] tempList;
	void Start () {


		downDir = Vector3.down;
		thisRigid = this.GetComponent<Rigidbody> ();
		tempList = GameObject.FindGameObjectsWithTag ("Player1");
		if (tempList.Length > 0) {
			opponentList.Add (tempList [0]);
		}
		tempList = GameObject.FindGameObjectsWithTag ("Player2");
		if (tempList.Length > 0) {
			opponentList.Add (tempList [0]);
		}
		tempList = GameObject.FindGameObjectsWithTag ("Player3");
		if (tempList.Length > 0) {
			opponentList.Add (tempList [0]);
		}
		tempList = GameObject.FindGameObjectsWithTag ("Player4");
		if (tempList.Length > 0) {
			opponentList.Add (tempList [0]);
		}
//		if (Physics.Raycast (transform.position, downDir, out hit, dist)) {
//			if (hit.collider.tag == "Ground") {
//				this.transform.position = hit.point;
//			}
//		} else {
//			//Destroy (this.gameObject);
//		}

		foreach(GameObject opponent in opponentList) {

			if (opponent.GetComponent<PlayerState> ().teamNum == this.GetComponent<AttackAction> ().teamNum) {
				opponentList.Remove (opponent);
			}
		}

		//StartCoroutine ("FollowClosestEnemy", whoToFollow);
	}

	// Update is called once per frame
	void FixedUpdate () {
		GetClosestEnemy (opponentList);
		if (whoToFollow != null) {

			thisRigid.velocity = (whoToFollow.transform.position.normalized * 200f * Time.deltaTime);
			this.transform.GetChild(0).rotation = Quaternion.LookRotation (new Vector3(whoToFollow.transform.position.x,whoToFollow.transform.position.y,whoToFollow.transform.position.z));
			if (Vector3.Distance (this.transform.position, whoToFollow.transform.position) < 1.5f) {
				createdThing = Instantiate (Resources.Load("ProjectileAttacks/PotionExplosion"), this.transform.position, Quaternion.Euler(this.transform.eulerAngles.x,this.transform.eulerAngles.y,this.transform.eulerAngles.z)) as GameObject;
				Destroy (this.gameObject);
			}
		}
	}

//	void OnTriggerEnter(Collider col){
////		if (col.gameObject.tag == "Solid") {
////			Destroy (this.gameObject);
////		}
//
//
//
//
//		if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3" || col.gameObject.tag == "Player4" ){
//			if (this.GetComponent<AttackAction>().teamNum != col.gameObject.GetComponent<PlayerState>().teamNum && !col.gameObject.GetComponent<PlayerMovement>().isRolling) {
//
//				col.gameObject.GetComponent<PlayerHealth> ().GetHit (this.GetComponent<AttackAction>().damage);
//				if (!col.gameObject.GetComponent<PlayerState>().isSlowed){
//				col.GetComponent<PlayerState> ().InflictSlowed (3f);
//				}
//				//Destroy (this.gameObject);
//			}
//		}
//	}


	public void GetClosestEnemy (List<GameObject> enemies)
	{
		float distance = Mathf.Infinity;
		foreach (GameObject go in enemies) {
			Vector3 diff = go.transform.position - transform.position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				whoToFollow = go;
				print ("gothere");
				distance = curDistance;
			}

			//whoToFollow = bestTarget;
		}
	}







}
