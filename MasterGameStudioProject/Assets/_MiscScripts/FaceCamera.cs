using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour {

	public Camera cameraToLookAt;

	void Start() 
	{
		cameraToLookAt = Camera.main;
	}

	void Update() 
	{
		Vector3 v = cameraToLookAt.transform.position - transform.position;
		v.x = v.z = 0.0f;
		transform.LookAt( cameraToLookAt.transform.position - v ); 
		//transform.rotation =(cameraToLookAt.transform.rotation); // Take care about camera rotation
	}
}