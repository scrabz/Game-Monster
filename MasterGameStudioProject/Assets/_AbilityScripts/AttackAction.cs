using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : MonoBehaviour {
	public int teamNum;
	public Transform parentPoint;
	public GameObject creator;
	public bool foundCreator = false;
	public float lifeTimer = 2.5f;

	public float damage = 1;
	// Use this for initialization
	void Start () {
		//spawnPoint = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {


		if (this.gameObject.name.Contains("Hitbox") && parentPoint != null){
			//this.transform.position = parentPoint.position;
			transform.position = new Vector3 (gameObject.GetComponent<AttackAction> ().parentPoint.transform.position.x, gameObject.GetComponent<AttackAction> ().parentPoint.transform.position.y, gameObject.GetComponent<AttackAction> ().parentPoint.transform.position.z);
			transform.eulerAngles = gameObject.GetComponent<AttackAction> ().parentPoint.transform.eulerAngles;
			//this.transform.rotation = parentPoint.rotation;
		}

		if (transform.position.y <= -100f) {
			Destroy (this.gameObject);
		}
		lifeTimer -= Time.deltaTime;
		if (lifeTimer <= 0) {
			Destroy (this.gameObject);
			this.transform.position = new Vector3 (0, -100f, 0);


		}
	}
}
