using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	public Animator animator;
	// Use this for initialization
	void Start () {
		animator = this.transform.Find("RotationPoint").Find("Model").gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (this.GetComponent<PlayerMovement> ().isRolling && (!animator.GetCurrentAnimatorStateInfo (0).IsName ("TestRoll"))) {
				animator.Play ("TestRoll", 0, 0f);


			} else {
			if (!this.GetComponent<PlayerMovement> ().isRolling && !animator.GetCurrentAnimatorStateInfo (0).IsName ("TestIdle")){
				animator.Play ("TestIdle", 0, 0f);


			}
			}



		 
	}
}
