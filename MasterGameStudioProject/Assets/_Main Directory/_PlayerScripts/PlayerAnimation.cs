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
			if (this.GetComponent<PlayerAbilities> ().doingAbil1 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("BasicAttack")) {
				animator.Play ("BasicAttack", 0, 0f);
			}
			if (this.GetComponent<PlayerAbilities> ().doingAbil4 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Ultimate")) {
				animator.Play ("Ultimate", 0, 0f);
			}
			if (this.GetComponent<PlayerAbilities> ().doingAbil3) {


				if (this.GetComponent<PlayerMovement> ().hMovement != 0 || this.GetComponent<PlayerMovement> ().vMovement != 0) {

					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("ShieldBlock")) {
						animator.Play ("ShieldBlock", 0, 0f);
					}
				} else {
					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("ShieldStay")) {
						animator.Play ("ShieldStay", 0, 0f);
					}
				}
			}
			if (this.GetComponent<PlayerAbilities> ().doingAbil2 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("LeapAttack")) {
				animator.Play ("LeapAttack", 0, 0f);
			}
			if (!this.GetComponent<PlayerAbilities> ().doingAbil1 && !this.GetComponent<PlayerAbilities> ().doingAbil2 && !this.GetComponent<PlayerAbilities> ().doingAbil3 && !this.GetComponent<PlayerAbilities> ().doingAbil4) {
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
					

		if (this.gameObject.name == "Neredy(Clone)") {
			if (this.GetComponent<PlayerAbilities> ().doingAbil1 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("BasicAttack")) {
				animator.Play ("BasicAttack", 0, 0f);
			}
			if (this.GetComponent<PlayerAbilities> ().doingAbil2 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("LashCharge")) {
				animator.Play ("LashCharge", 0, 0f);
			}
			if (this.GetComponent<PlayerAbilities> ().doingAbil3 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("StoneStare")) {
				animator.Play ("StoneStare", 0, 0f);
			}
			if (this.GetComponent<PlayerAbilities> ().doingAbil4 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Ultimate")) {
				animator.Play ("Ultimate", 0, 0f);
			}
				
			if (!this.GetComponent<PlayerAbilities> ().doingAbil1 && !this.GetComponent<PlayerAbilities> ().doingAbil2 && !this.GetComponent<PlayerAbilities> ().doingAbil3 && !this.GetComponent<PlayerAbilities> ().doingAbil4) {
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

		if (this.gameObject.name == "Tiny(Clone)") {
			if (this.GetComponent<PlayerAbilities> ().doingAbil2 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("BasicAttack")) {
				animator.Play ("BasicAttack", 0, 0f);

			}
			if (this.GetComponent<PlayerAbilities> ().doingAbil1 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("ThrowDaggers")) {
				animator.Play ("ThrowDaggers", 0, 0f);
			}
			if (this.GetComponent<PlayerAbilities> ().doingAbil3 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("PlaceTrap")) {
				animator.Play ("PlaceTrap", 0, 0f);

			}
			if (this.GetComponent<PlayerAbilities> ().doingAbil4 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Ultimate")) {
				animator.Play ("Ultimate", 0, 0f);

			}

			if (!this.GetComponent<PlayerAbilities> ().doingAbil1 && !this.GetComponent<PlayerAbilities> ().doingAbil2 && !this.GetComponent<PlayerAbilities> ().doingAbil3 && !this.GetComponent<PlayerAbilities> ().doingAbil4) {
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

		if (this.gameObject.name == "ToeTip(Clone)") {

			if (this.GetComponent<PlayerMovement> ().wonMatch == true) {
				this.GetComponent<PlayerMovement> ().canMove = false;
				if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Ultimate")) {
					animator.Play ("Ultimate", 0, 0f);
				}
			} else {

				if (this.GetComponent<PlayerAbilities> ().doingAbil1 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Basic Attack/Abilities")) {
					animator.Play ("Basic Attack/Abilities", 0, 0f);
				}
				if (this.GetComponent<PlayerAbilities> ().doingAbil4 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Ultimate")) {
					animator.Play ("Ultimate", 0, 0f);
				}
				if (this.GetComponent<PlayerAbilities> ().doingAbil3 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("LastOne")) {
					animator.Play ("LastOne", 0, 0f);

				}
				if (this.GetComponent<PlayerAbilities> ().doingAbil2 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("AnothaOne")) {
					animator.Play ("AnothaOne", 0, 0f);

				}
				if (!this.GetComponent<PlayerAbilities> ().doingAbil1 && !this.GetComponent<PlayerAbilities> ().doingAbil2 && !this.GetComponent<PlayerAbilities> ().doingAbil3 && !this.GetComponent<PlayerAbilities> ().doingAbil4) {

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
