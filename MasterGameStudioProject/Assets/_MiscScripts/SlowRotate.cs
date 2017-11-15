using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 85f * Time.deltaTime, 0);
	}
}
