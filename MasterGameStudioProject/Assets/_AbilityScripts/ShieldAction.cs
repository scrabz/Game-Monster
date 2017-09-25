using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAction : MonoBehaviour {

	// Use this for initialization
	public GameObject createdThing;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Projectile") {
			Destroy (col.gameObject);

		}


	}
}
