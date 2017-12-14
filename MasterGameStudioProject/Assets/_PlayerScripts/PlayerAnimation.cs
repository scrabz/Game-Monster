using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	public Animator animator;
	public GameObject rotationPoint;

	public AudioClip brogreVictory;
	public AudioClip garyVictory;
	public AudioClip tinyVictory;
	public AudioClip neredyVictory;
	public AudioClip guyVictory;
	public AudioClip decayVictory;
	public AudioClip geoVictory;
	public AudioClip irisVictory;

	public bool didIt = false;

	public GameObject createdThing;
	// Use this for initialization
	void Start () {
		rotationPoint = this.transform.Find ("RotationPoint").gameObject;
		animator = this.transform.Find("RotationPoint").Find("Model").gameObject.GetComponent<Animator> ();


		brogreVictory = Resources.Load ("SFX/BrogreVictory") as AudioClip;
		garyVictory = Resources.Load ("SFX/GaryVictory") as AudioClip;
		tinyVictory = Resources.Load ("SFX/TinyVictory") as AudioClip;
		neredyVictory = Resources.Load ("SFX/NeredyVictory") as AudioClip;
		irisVictory = Resources.Load ("SFX/IrisVictory") as AudioClip;
		guyVictory = Resources.Load ("SFX/GuyVictory") as AudioClip;
		geoVictory = Resources.Load ("SFX/GeoVictory") as AudioClip;
		decayVictory = Resources.Load ("SFX/DecayVictory") as AudioClip;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.name == "Brogre(Clone)") {
			if (this.GetComponent<PlayerMovement> ().matchOver == true) {
				this.GetComponent<PlayerMovement> ().canMove = false;
				if (this.GetComponent<PlayerState> ().isDying) {
					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("DefeatAnimation")) {
						animator.Play ("DefeatAnimation", 0, 0f);
					}
				} else {
					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("VictoryAnimation")) {
						animator.Play ("VictoryAnimation", 0, 0f);
						this.GetComponent<AudioSource> ().clip = brogreVictory;
						this.GetComponent<AudioSource> ().Play ();
					}
				}
			} else {
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
					} else {
						if (!this.GetComponent<PlayerMovement> ().isRolling && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) {
							animator.Play ("Idle", 0, 0f);
						}
					}
				
				}
			}
		}
					

		if (this.gameObject.name == "Neredy(Clone)") {
			if (this.GetComponent<PlayerMovement> ().matchOver == true) {
				this.GetComponent<PlayerMovement> ().canMove = false;
				if (this.GetComponent<PlayerState> ().isDying) {
					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("DefeatAnimation")) {
						animator.Play ("DefeatAnimation", 0, 0f);
					}
				} else {
					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("VictoryAnimation")) {
						this.GetComponent<AudioSource> ().clip = neredyVictory;
						this.GetComponent<AudioSource> ().Play ();
						animator.Play ("VictoryAnimation", 0, 0f);
					}
				}
			} else {
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
		}

		if (this.gameObject.name == "Tiny(Clone)") {
			if (this.GetComponent<PlayerMovement> ().matchOver == true) {
				this.GetComponent<PlayerMovement> ().canMove = false;
				if (this.GetComponent<PlayerState> ().isDying) {
					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("DefeatAnimation")) {
						animator.Play ("DefeatAnimation", 0, 0f);
					}
				} else {
					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("VictoryAnimation")) {
						animator.Play ("VictoryAnimation", 0, 0f);
						this.GetComponent<AudioSource> ().clip = tinyVictory;
						this.GetComponent<AudioSource> ().Play ();
					}
				}
			} else {
				if (this.GetComponent<PlayerAbilities> ().doingAbil2 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("DashAttack")) {
					animator.Play ("DashAttack", 0, 0f);

				}
				if (this.GetComponent<PlayerAbilities> ().doingAbil1 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("BasicAttack")) {
					animator.Play ("BasicAttack", 0, 0f);
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

		}

		if (this.gameObject.name == "Iris(Clone)") {
			if (this.GetComponent<PlayerMovement> ().matchOver == true) {
				this.GetComponent<PlayerMovement> ().canMove = false;
				if (this.GetComponent<PlayerState> ().isDying) {
					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("DefeatAnimation")) {
						animator.Play ("DefeatAnimation", 0, 0f);
					}
				} else {
					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("VictoryAnimation")) {
						animator.Play ("VictoryAnimation", 0, 0f);
						this.GetComponent<AudioSource> ().clip = irisVictory;
						this.GetComponent<AudioSource> ().Play ();
					}
				}
			} else {
				if (this.GetComponent<PlayerAbilities> ().doingAbil2 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("WhipIn") && this.GetComponent<PlayerAbilities> ().gotSomeone == true) {
					animator.Play ("WhipIn", 0, 0f);

				}
				if (this.GetComponent<PlayerAbilities> ().doingAbil2 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("WhipOut") && this.GetComponent<PlayerAbilities> ().gotSomeone == false) {
					animator.Play ("WhipOut", 0, 0f);

				}

				if (this.GetComponent<PlayerAbilities> ().doingAbil1 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("ChaosClaw")) {
					animator.Play ("ChaosClaw", 0, 0f);
				}
				if (this.GetComponent<PlayerAbilities> ().doingAbil3 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Charm")) {
					animator.Play ("Charm", 0, 0f);

				}
				if (this.GetComponent<PlayerAbilities> ().doingAbil4 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("LifeSteal")) {
					animator.Play ("LifeSteal", 0, 0f);

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


		if (this.gameObject.name == "Claymond(Clone)") {
			if (this.GetComponent<PlayerMovement> ().matchOver == true) {
				this.GetComponent<PlayerMovement> ().canMove = false;
				if (this.GetComponent<PlayerState> ().isDying) {
					
						Destroy (rotationPoint.gameObject);
					if (createdThing == null && didIt == false) {
						didIt = true;
						createdThing = Instantiate (Resources.Load ("Particles/BigExplosion"), transform.position, Quaternion.Euler (this.transform.eulerAngles.x, this.transform.eulerAngles.y - 10f, this.transform.eulerAngles.z)) as GameObject;
					}
					
				} else {
					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("VictoryAnimation")) {
						animator.Play ("VictoryAnimation", 0, 0f);
						this.GetComponent<AudioSource> ().clip = geoVictory;
						this.GetComponent<AudioSource> ().Play ();
					}
				}
			} else {
				if (this.GetComponent<PlayerAbilities> ().doingAbil2 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("SeismicFist")) {
					animator.Play ("SeismicFist", 0, 0f);

				}
				if (this.GetComponent<PlayerAbilities> ().doingAbil1 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("AttackAndWalk")) {
					animator.Play ("AttackAndWalk", 0, 0f);
				}
				if (this.GetComponent<PlayerAbilities> ().doingAbil3 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Rockwall")) {
					animator.Play ("Rockwall", 0, 0f);

				}
				if (this.GetComponent<PlayerAbilities> ().doingAbil4 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("SeismicTerror")) {
					animator.Play ("SeismicTerror", 0, 0f);

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



		if (this.gameObject.name == "DrDecay(Clone)") {
			if (this.GetComponent<PlayerMovement> ().matchOver == true) {
				this.GetComponent<PlayerMovement> ().canMove = false;
				if (this.GetComponent<PlayerState> ().isDying) {
					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("DefeatAnimation")) {
						animator.Play ("DefeatAnimation", 0, 0f);
					}
				} else {
					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("VictoryAnimation")) {
						animator.Play ("VictoryAnimation", 0, 0f);
						this.GetComponent<AudioSource> ().clip = decayVictory;
						this.GetComponent<AudioSource> ().Play ();
					}
				}
			} else {


				if (this.GetComponent<PlayerAbilities> ().doingAbil2 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("GasCloud")) {
					animator.Play ("GasCloud", 0, 0f);

				}
				if (this.GetComponent<PlayerAbilities> ().doingAbil1 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("BasicAttack")) {
					animator.Play ("BasicAttack", 0, 0f);
				}
				if (this.GetComponent<PlayerAbilities> ().doingAbil3 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("BagOfTricks")) {
					animator.Play ("BagOfTricks", 0, 0f);

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

		}

		if (this.gameObject.name == "Guy(Clone)") {
			if (this.GetComponent<PlayerMovement> ().matchOver == true) {
				this.GetComponent<PlayerMovement> ().canMove = false;
				if (this.GetComponent<PlayerState> ().isDying) {
					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("DefeatAnimation")) {
						animator.Play ("DefeatAnimation", 0, 0f);
					}
				} else {
					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("VictoryAnimation")) {
						animator.Play ("VictoryAnimation", 0, 0f);
						this.GetComponent<AudioSource> ().clip = guyVictory;
						this.GetComponent<AudioSource> ().Play ();
					}
				}
			} else {


				if (this.GetComponent<PlayerAbilities> ().doingAbil2 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("NapalmShot")) {
					animator.Play ("NapalmShot", 0, 0f);

				}
				if (this.GetComponent<PlayerMovement> ().hMovement != 0 || this.GetComponent<PlayerMovement> ().vMovement != 0) {
					if (this.GetComponent<PlayerAbilities> ().doingAbil1 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("BasicAttack")) {
						animator.Play ("BasicAttack", 0, 0f);
					}
				} else {
					if (this.GetComponent<PlayerAbilities> ().doingAbil1 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("BasicAttackNotMoving")) {
						animator.Play ("BasicAttackNotMoving", 0, 0f);
					}
				}
				if (this.GetComponent<PlayerMovement> ().hMovement != 0 || this.GetComponent<PlayerMovement> ().vMovement != 0) {
					if (this.GetComponent<PlayerAbilities> ().doingAbil3 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("BasicAttack")) {
						animator.Play ("BasicAttack", 0, 0f);
					}
				} else {
					if (this.GetComponent<PlayerAbilities> ().doingAbil3 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("BasicAttackNotMoving")) {
						animator.Play ("BasicAttackNotMoving", 0, 0f);
					}
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

		}




		if (this.gameObject.name == "ToeTip(Clone)") {

			if (this.GetComponent<PlayerMovement> ().matchOver == true) {
				this.GetComponent<PlayerMovement> ().canMove = false;
				if (this.GetComponent<PlayerState> ().isDying) {
					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("DefeatAnimation")) {
						animator.Play ("DefeatAnimation", 0, 0f);
					}
				} else {
					if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Ultimate")) {
						animator.Play ("Ultimate", 0, 0f);
						this.GetComponent<AudioSource> ().clip = garyVictory;
						this.GetComponent<AudioSource> ().Play ();
					}
				}
			} else {

				if (this.GetComponent<PlayerAbilities> ().doingAbil1 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Abilities")) {
					animator.Play ("Abilities", 0, 0f);
				}
				if (this.GetComponent<PlayerAbilities> ().doingAbil4 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Ultimate")) {
					animator.Play ("Ultimate", 0, 0f);
				}
				if (this.GetComponent<PlayerAbilities> ().doingAbil3 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Abilities")) {
					animator.Play ("Abilities", 0, 0f);

				}
				if (this.GetComponent<PlayerAbilities> ().doingAbil2 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Abilities")) {
					animator.Play ("Abilities", 0, 0f);

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
