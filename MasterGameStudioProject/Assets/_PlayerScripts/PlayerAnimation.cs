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
		if (this.gameObject.name == "Brogre(Clone)") {
			if (this.GetComponent<PlayerAbilities> ().isCleaving && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Basic Attack")) {
				animator.Play ("Basic Attack", 0, 0f);
			}
			if (this.GetComponent<PlayerAbilities> ().isKegTossing && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Ultimate (Keg Toss)")) {
				animator.Play ("Ultimate (Keg Toss)", 0, 0f);
			}
			if (this.GetComponent<PlayerAbilities> ().isShielding) {


				if (this.GetComponent<PlayerMovement> ().hMovement != 0 || this.GetComponent<PlayerMovement> ().vMovement != 0) {

					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Shield Up Walk Cycle")) {
						animator.Play ("Shield Up Walk Cycle", 0, 0f);
					}
				} else {
					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("WalkCycleStart")) {
						animator.Play ("Walk Cycle Start", 0, 0f);
					}
				}
			}
			if (this.GetComponent<PlayerAbilities> ().isShielding && this.GetComponent<PlayerMovement> ().hMovement != 0 && this.GetComponent<PlayerMovement> ().vMovement != 0 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Shield Up Walk Cycle")) {
				animator.Play ("Shield Up Walk Cycle", 0, 0f);
			}
			if (this.GetComponent<PlayerAbilities> ().isShieldPushing && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Walk Cycle Start")) {
				animator.Play ("Walk Cycle Start", 0, 0f);
			}
			if (!this.GetComponent<PlayerAbilities> ().isCleaving && !this.GetComponent<PlayerAbilities> ().isShielding && !this.GetComponent<PlayerAbilities> ().isShieldPushing && !this.GetComponent<PlayerAbilities> ().isKegTossing) {
				if (this.GetComponent<PlayerMovement> ().isRolling && (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Dodge Roll"))) {
					animator.Play ("Dodge Roll", 0, 0f);


				} else {
					if (this.GetComponent<PlayerMovement>().hMovement != 0 || this.GetComponent<PlayerMovement>().vMovement != 0) {
						if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Walk Cycle")){
						animator.Play ("Walk Cycle", 0, 0f);
						}
					} else {
						if (!this.GetComponent<PlayerMovement> ().isRolling && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) {
							animator.Play ("Idle", 0, 0f);
						}
					}
				}
			}

		}

		 
	}
}
