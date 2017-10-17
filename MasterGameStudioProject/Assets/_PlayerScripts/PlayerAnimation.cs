using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	public Animator animator;
	public GameObject rotationPoint;
	// Use this for initialization
	void Start () {
		rotationPoint = this.transform.Find ("RotationPoint").gameObject;
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
					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Walk Cycle Start")) {
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
					//animator.Play ("Dodge Roll", 0, 0f);


				} else {
					if (this.GetComponent<PlayerMovement> ().hMovement != 0 || this.GetComponent<PlayerMovement> ().vMovement != 0) {
						if (Vector3.Dot (this.GetComponent<PlayerMovement> ().moveDirection, rotationPoint.transform.forward) < 0) {
							if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("WalkBackwards")) {
								animator.Play ("WalkBackwards", 0, 0f);

							}
						} else {
							if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Walk")) {
								animator.Play ("Walk", 0, 0f);
							}

						}
					}
					else {
						if (!this.GetComponent<PlayerMovement> ().isRolling && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) {
							animator.Play ("Idle", 0, 0f);
						}
					}
				}
			}
		}
					

		if (this.gameObject.name == "Neredy(Clone)") {
			if (this.GetComponent<PlayerAbilities> ().isDaggering && !animator.GetCurrentAnimatorStateInfo (0).IsName ("BasicAttack")) {
				animator.Play ("BasicAttack", 0, 0f);
			}
			if (this.GetComponent<PlayerAbilities> ().isDashAttacking && !animator.GetCurrentAnimatorStateInfo (0).IsName ("LashCharge")) {
				animator.Play ("LashCharge", 0, 0f);
			}
			if (this.GetComponent<PlayerAbilities> ().isShielding && !animator.GetCurrentAnimatorStateInfo (0).IsName ("StoneStare")) {
				animator.Play ("StoneStare", 0, 0f);
			}
			if (this.GetComponent<PlayerAbilities> ().isBecomingEnraged && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Ultimate")) {
				animator.Play ("Ultimate", 0, 0f);
			}
				
			if (!this.GetComponent<PlayerAbilities> ().isDaggering && !this.GetComponent<PlayerAbilities> ().isDashAttacking && !this.GetComponent<PlayerAbilities> ().isShielding && !this.GetComponent<PlayerAbilities> ().isBecomingEnraged) {
				if (this.GetComponent<PlayerMovement> ().isRolling && (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Dodge Roll"))) {
					//animator.Play ("Dodge Roll", 0, 0f);


				} else {
					if (this.GetComponent<PlayerMovement> ().hMovement != 0 || this.GetComponent<PlayerMovement> ().vMovement != 0) {
						if (Vector3.Dot (this.GetComponent<PlayerMovement> ().moveDirection, rotationPoint.transform.forward) < 0) {
							if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("WalkBackwards")) {
								animator.Play ("WalkBackwards", 0, 0f);

							}
						} else {
							if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Walk")) {
								animator.Play ("Walk", 0, 0f);
							}

						}
					} else {
						if (!this.GetComponent<PlayerMovement> ().isRolling && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) {
							animator.Play ("Idle", 0, 0f);
						}
					}
				}
			}
		}

		if (this.gameObject.name == "Tiny(Clone)") {
			if (this.GetComponent<PlayerAbilities> ().isDaggering && !animator.GetCurrentAnimatorStateInfo (0).IsName ("BasicAttack")) {
				animator.Play ("BasicAttack", 0, 0f);

			}
			if (this.GetComponent<PlayerAbilities> ().isKnifeThrowing && !animator.GetCurrentAnimatorStateInfo (0).IsName ("ThrowDaggers")) {
				animator.Play ("ThrowDaggers", 0, 0f);
			}
			if (this.GetComponent<PlayerAbilities> ().isClawTrapping && !animator.GetCurrentAnimatorStateInfo (0).IsName ("PlaceTrap")) {
				animator.Play ("PlaceTrap", 0, 0f);

			}
			if (this.GetComponent<PlayerAbilities> ().isKnifeSpinning && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Ultimate")) {
				animator.Play ("Ultimate", 0, 0f);

			}
			if (this.GetComponent<PlayerAbilities> ().isShielding && this.GetComponent<PlayerMovement> ().hMovement != 0 && this.GetComponent<PlayerMovement> ().vMovement != 0 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Shield Up Walk Cycle")) {
				animator.Play ("Shield Up Walk Cycle", 0, 0f);
			}
			if (this.GetComponent<PlayerAbilities> ().isShieldPushing && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Walk Cycle Start")) {
				animator.Play ("Walk Cycle Start", 0, 0f);
			}
			if (!this.GetComponent<PlayerAbilities> ().isDaggering && !this.GetComponent<PlayerAbilities> ().isClawTrapping && !this.GetComponent<PlayerAbilities> ().isKnifeSpinning && !this.GetComponent<PlayerAbilities> ().isKnifeThrowing) {
				if (this.GetComponent<PlayerMovement> ().isRolling && (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Dodge Roll"))) {
					animator.Play ("Dodge Roll", 0, 0f);


				} else {
					if (this.GetComponent<PlayerMovement> ().hMovement != 0 || this.GetComponent<PlayerMovement> ().vMovement != 0) {
						if (Vector3.Dot (this.GetComponent<PlayerMovement> ().moveDirection, rotationPoint.transform.forward) < 0) {
							if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("WalkBackwards")) {
								animator.Play ("WalkBackwards", 0, 0f);

							}
						} else {
							if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Walk")) {
								animator.Play ("Walk", 0, 0f);
							}

						}
					} else {
						if (!this.GetComponent<PlayerMovement> ().isRolling && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) {
							animator.Play ("Idle", 0, 0f);
						}
					}
				}
			}

		}

		if (this.gameObject.name == "ToeTip(Clone)") {
			if (this.GetComponent<PlayerAbilities> ().isShooting && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Basic Attack/Abilities")) {
				animator.Play ("Basic Attack/Abilities", 0, 0f);
			}
			if (this.GetComponent<PlayerAbilities> ().isStomping && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Ultimate")) {
				animator.Play ("Ultimate", 0, 0f);
			}
			if (this.GetComponent<PlayerAbilities> ().isCollecting && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Basic Attack/Abilities")) {
				animator.Play ("Basic Attack/Abilities", 0, 0f);

			}
			if (this.GetComponent<PlayerAbilities> ().isShielding && this.GetComponent<PlayerMovement> ().hMovement != 0 && this.GetComponent<PlayerMovement> ().vMovement != 0 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Shield Up Walk Cycle")) {
				animator.Play ("Shield Up Walk Cycle", 0, 0f);
			}
			if (this.GetComponent<PlayerAbilities> ().isShieldPushing && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Walk Cycle Start")) {
				animator.Play ("Walk Cycle Start", 0, 0f);
			}
			if (!this.GetComponent<PlayerAbilities> ().isShooting && !this.GetComponent<PlayerAbilities> ().isCollecting && !this.GetComponent<PlayerAbilities> ().isStomping) {
				if (this.GetComponent<PlayerMovement> ().isRolling && (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Dodge Roll"))) {
					animator.Play ("Dodge Roll", 0, 0f);


				} else {
					if (this.GetComponent<PlayerMovement> ().hMovement != 0 || this.GetComponent<PlayerMovement> ().vMovement != 0) {
						if (Vector3.Dot (this.GetComponent<PlayerMovement> ().moveDirection, rotationPoint.transform.forward) < 0) {
							if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("WalkBackwards")) {
								animator.Play ("WalkBackwards", 0, 0f);

							}
						} else {
							if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Walk")) {
								animator.Play ("Walk", 0, 0f);
							}

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
