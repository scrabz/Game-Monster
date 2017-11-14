using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantUnparent : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		this.transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
