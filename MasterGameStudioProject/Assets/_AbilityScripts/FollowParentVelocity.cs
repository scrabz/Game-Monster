using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParentVelocity : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (this.transform.parent.GetComponent<Rigidbody> ().velocity.magnitude > 0.1f) {
			transform.rotation = Quaternion.LookRotation (this.transform.parent.GetComponent<Rigidbody> ().velocity);
		}

	}
}
