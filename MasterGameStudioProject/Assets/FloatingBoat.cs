using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBoat : MonoBehaviour {

	private Transform Water;
	private Cloth planeCloth;
	private int closestVertexIndex = -1;


	// Use this for initialization
	void Start () {
		Water = GameObject.Find ("Water").transform;
		planeCloth = Water.GetComponent<Cloth>();
	}
	
	// Update is called once per frame
	void Update () {
		GetClosestVertex ();
	}

	void GetClosestVertex (){
		for (int i = 0; i < planeCloth.vertices.Length; i++) {
			if (closestVertexIndex == -1) {
				closestVertexIndex = i;
			}
			float distance = Vector3.Distance (planeCloth.vertices[i], transform.position);
			float closestDistance = Vector3.Distance (planeCloth.vertices [closestVertexIndex], transform.position);
			if (distance < closestDistance) {
				closestVertexIndex = i;
			}
		}
		transform.position = new Vector3(
			transform.position.x,
			planeCloth.vertices[closestVertexIndex].y,
			transform.position.z
		);
	}
}
