using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;

public class PlayerAbilities : MonoBehaviour {


	[SerializeField] private CharacterAbility ability;
	public GameObject abilityPanel;
	public GameObject ability1;
	public GameObject ability2;
	public GameObject ability3;
	public GameObject ability4;



	public GameObject characterModel;
	public Transform characterPoint1;
	public Transform characterPoint2;
	public Transform spawnPoint;

	private float cooldownDuration;
	private float nextReadyTime;
	private float cooldownTimeLeft;

	bool abilityButton1;
	bool abilityButton2;
	bool abilityButton3;
	bool abilityButton4;


	CharacterAbility comboJab;
	CharacterAbility megaFist;
	CharacterAbility collection;
	public List<GameObject> storedProjectiles;
	CharacterAbility stomp;


	CharacterAbility cleave;
	CharacterAbility shield;
	CharacterAbility shieldPush;
	CharacterAbility kegToss;

	CharacterAbility duelDaggers;
	CharacterAbility knifeThrow;
	CharacterAbility clawTrap;
	CharacterAbility knifeSpin;

	CharacterAbility pushPunch;
	CharacterAbility clayShards;
	CharacterAbility clayWall;
	CharacterAbility shockwave;

	CharacterAbility comboAttack;
	CharacterAbility dashAttack;
	CharacterAbility petrify;
	CharacterAbility rage;

	public GameObject rageEffectL;
	public GameObject rageEffectR;




	public InputDevice currentJoystick;

	public bool abilityActive = false;
	public GameObject createdThing;

	public GameObject rotationPoint;
	public int teamNum;


	//Dumb Bools

	public bool isCleaving = false;
	public bool isShieldPushing = false;
	public bool isShielding = false;
	public bool isKegTossing = false;

	public bool isCollecting = false;
	public bool isShooting = false;
	public bool isStomping = false;

	public bool isDaggering = false;
	public bool isKnifeThrowing = false;
	public bool isClawTrapping = false;
	public bool isKnifeSpinning = false;

	public bool isDashAttacking = false;
	public bool isPetrifying = false;
	public bool isBecomingEnraged = false;
	public bool isRaging = false;

	public GameObject matchManager;

	public bool handicap = false;

	void Start () {

		teamNum = this.GetComponent<PlayerState> ().teamNum;
		matchManager = GameObject.Find ("MatchManager");



		if (this.gameObject.tag == "Player1") {
			if (InputManager.Devices [0] != null) {
				currentJoystick = InputManager.Devices [0];
			}
		}
		if (this.gameObject.tag == "Player2") {
			if (InputManager.Devices [1] != null) {
				currentJoystick = InputManager.Devices [1];
			}
		}
		if (this.gameObject.tag == "Player3") {
			if (InputManager.Devices [2] != null) {
				currentJoystick = InputManager.Devices [2];
			}
		}
		if (this.gameObject.tag == "Player4") {
			if (InputManager.Devices [3] != null) {
				currentJoystick = InputManager.Devices [3];
			}
		}

		rotationPoint = this.gameObject.transform.Find ("RotationPoint").gameObject;
		characterPoint1 = this.gameObject.transform.Find ("RotationPoint").Find ("SpawningPoint1");
		characterPoint2 = this.gameObject.transform.Find ("RotationPoint").Find ("SpawningPoint2");

		if (this.gameObject.tag == "Player1") {
			abilityPanel = GameObject.Find ("P1Panel");
		}
		if (this.gameObject.tag == "Player2") {
			abilityPanel = GameObject.Find ("P2Panel");
		}
		if (this.gameObject.tag == "Player3") {
			abilityPanel = GameObject.Find ("P3Panel");
		}
		if (this.gameObject.tag == "Player4") {
			abilityPanel = GameObject.Find ("P4Panel");
		}


		if (this.gameObject.name == "ToeTip(Clone)") {

			comboJab = new CharacterAbility ();
			megaFist = new CharacterAbility ();
			collection = new CharacterAbility ();
			stomp = new CharacterAbility ();

			//Find the Ability panels
			ability1 = abilityPanel.transform.Find ("Ability1").gameObject;
			ability2 = abilityPanel.transform.Find ("Ability2").gameObject;
			ability3 = abilityPanel.transform.Find ("Ability3").gameObject;
			ability4 = abilityPanel.transform.Find ("Ability4").gameObject;

			//Set the properties of every ability
			comboJab.aName = "Fury Fists";
			comboJab.aIcon = Resources.Load<Sprite> ("AbilityIcons/GaryA1");
			comboJab.aCooldown = 0.8f;
			comboJab.aPanel = ability1;

			megaFist.aName = "Mega Fist";
			megaFist.aIcon = Resources.Load<Sprite> ("AbilityIcons/GaryA2");
			megaFist.aCooldown = 2f;
			megaFist.aPanel = ability2;

			collection.aName = "Collection / Rejection";
			collection.aIcon = Resources.Load<Sprite> ("AbilityIcons/GaryA3");
			collection.aCooldown = 3f;
			collection.aPanel = ability3;

			stomp.aName = "Stomp";
			stomp.aIcon = Resources.Load<Sprite> ("AbilityIcons/GaryA4");
			stomp.aCooldown = 15f;
			stomp.aPanel = ability4;

			//Change the icons to match the ability
			ability1.GetComponent<Image> ().sprite = comboJab.aIcon;
			ability2.GetComponent<Image> ().sprite = megaFist.aIcon;
			ability3.GetComponent<Image> ().sprite = collection.aIcon;
			ability4.GetComponent<Image> ().sprite = stomp.aIcon;

		}

		if (this.gameObject.name == "Brogre(Clone)") {

			cleave = new CharacterAbility ();
			shield = new CharacterAbility ();
			shieldPush = new CharacterAbility ();
			kegToss = new CharacterAbility ();

			//Find the Ability panels
			ability1 = abilityPanel.transform.Find ("Ability1").gameObject;
			ability2 = abilityPanel.transform.Find ("Ability2").gameObject;
			ability3 = abilityPanel.transform.Find ("Ability3").gameObject;
			ability4 = abilityPanel.transform.Find ("Ability4").gameObject;

			//Set the properties of every ability
			cleave.aName = "Cleave";
			cleave.aIcon = Resources.Load<Sprite> ("AbilityIcons/BrogreA1");
			cleave.aCooldown = 0.7f;
			cleave.aPanel = ability1;

			shield.aName = "Shield";
			shield.aIcon = Resources.Load<Sprite> ("AbilityIcons/BrogreA2");
			shield.aCooldown = 3f;
			shield.aPanel = ability2;

			shieldPush.aName = "Shield Push";
			shieldPush.aIcon = Resources.Load<Sprite> ("AbilityIcons/BrogreA3");
			shieldPush.aCooldown = 3f;
			shieldPush.aPanel = ability3;

			kegToss.aName = "Keg Toss";
			kegToss.aIcon = Resources.Load<Sprite> ("AbilityIcons/BrogreA4");
			kegToss.aCooldown = 15f;
			kegToss.aPanel = ability4;

			//Change the icons to match the ability
			ability1.GetComponent<Image> ().sprite = cleave.aIcon;
			ability2.GetComponent<Image> ().sprite = shield.aIcon;
			ability3.GetComponent<Image> ().sprite = shieldPush.aIcon;
			ability4.GetComponent<Image> ().sprite = kegToss.aIcon;

		}


		if (this.gameObject.name == "Neredy(Clone)") {

			comboAttack = new CharacterAbility ();
			dashAttack = new CharacterAbility ();
			petrify = new CharacterAbility ();
			rage = new CharacterAbility ();

			//Find the Ability panels
			ability1 = abilityPanel.transform.Find ("Ability1").gameObject;
			ability2 = abilityPanel.transform.Find ("Ability2").gameObject;
			ability3 = abilityPanel.transform.Find ("Ability3").gameObject;
			ability4 = abilityPanel.transform.Find ("Ability4").gameObject;

			//Set the properties of every ability
			comboAttack.aName = "Combo Attack";
			comboAttack.aIcon = Resources.Load<Sprite> ("AbilityIcons/NeredyA1");
			comboAttack.aCooldown = 1f;
			comboAttack.aPanel = ability1;

			dashAttack.aName = "Dash Attack";
			dashAttack.aIcon = Resources.Load<Sprite> ("AbilityIcons/NeredyA2");
			dashAttack.aCooldown = 2.5f;
			dashAttack.aPanel = ability2;

			petrify.aName = "Petrify";
			petrify.aIcon = Resources.Load<Sprite> ("AbilityIcons/NeredyA3");
			petrify.aCooldown = 8f;
			petrify.aPanel = ability3;

			rage.aName = "Rage";
			rage.aIcon = Resources.Load<Sprite> ("AbilityIcons/NeredyA4");
			rage.aCooldown = 15f;
			rage.aPanel = ability4;

			//Change the icons to match the ability
			ability1.GetComponent<Image> ().sprite = comboAttack.aIcon;
			ability2.GetComponent<Image> ().sprite = dashAttack.aIcon;
			ability3.GetComponent<Image> ().sprite = petrify.aIcon;
			ability4.GetComponent<Image> ().sprite = rage.aIcon;

		}


		if (this.gameObject.name == "Tiny(Clone)") {

			duelDaggers = new CharacterAbility ();
			knifeThrow = new CharacterAbility ();
			clawTrap = new CharacterAbility ();
			knifeSpin = new CharacterAbility ();

			//Find the Ability panels
			ability1 = abilityPanel.transform.Find ("Ability1").gameObject;
			ability2 = abilityPanel.transform.Find ("Ability2").gameObject;
			ability3 = abilityPanel.transform.Find ("Ability3").gameObject;
			ability4 = abilityPanel.transform.Find ("Ability4").gameObject;

			//Set the properties of every ability
			duelDaggers.aName = "Duel Daggers";
			duelDaggers.aIcon = Resources.Load<Sprite> ("AbilityIcons/TinyA1");
			duelDaggers.aCooldown = 0.7f;
			duelDaggers.aPanel = ability1;

			knifeThrow.aName = "Knife Throw";
			knifeThrow.aIcon = Resources.Load<Sprite> ("AbilityIcons/TinyA2");
			knifeThrow.aCooldown = 1.5f;
			knifeThrow.aPanel = ability2;

			clawTrap.aName = "Claw Trap";
			clawTrap.aIcon = Resources.Load<Sprite> ("AbilityIcons/TinyA3");
			clawTrap.aCooldown = 8f;
			clawTrap.aPanel = ability3;

			knifeSpin.aName = "Knife Spin";
			knifeSpin.aIcon = Resources.Load<Sprite> ("AbilityIcons/TinyA4");
			knifeSpin.aCooldown = 15f;
			knifeSpin.aPanel = ability4;

			//Change the icons to match the ability
			ability1.GetComponent<Image> ().sprite = duelDaggers.aIcon;
			ability2.GetComponent<Image> ().sprite = knifeThrow.aIcon;
			ability3.GetComponent<Image> ().sprite = clawTrap.aIcon;
			ability4.GetComponent<Image> ().sprite = knifeSpin.aIcon;

		}

		if (this.gameObject.name == "Claymond(Clone)") {

			pushPunch = new CharacterAbility ();
			clayShards = new CharacterAbility ();
			clayWall = new CharacterAbility ();
			shockwave = new CharacterAbility ();

			//Find the Ability panels
			ability1 = abilityPanel.transform.Find ("Ability1").gameObject;
			ability2 = abilityPanel.transform.Find ("Ability2").gameObject;
			ability3 = abilityPanel.transform.Find ("Ability3").gameObject;
			ability4 = abilityPanel.transform.Find ("Ability4").gameObject;

			//Set the properties of every ability
			pushPunch.aName = "Push Punch";
			//pushPunch.aIcon = Resources.Load<Sprite> ("AbilityIcons/test1");
			pushPunch.aCooldown = 0.8f;
			pushPunch.aPanel = ability1;

			clayShards.aName = "Clay Shards";
			//clayShards.aIcon = Resources.Load<Sprite> ("AbilityIcons/test1");
			clayShards.aCooldown = 2f;
			clayShards.aPanel = ability2;

			clayWall.aName = "Clay Wall";
			//clayWall.aIcon = Resources.Load<Sprite> ("AbilityIcons/test3");
			clayWall.aCooldown = 3f;
			clayWall.aPanel = ability3;

			shockwave.aName = "Shockwave";
			//shockwave.aIcon = Resources.Load<Sprite> ("AbilityIcons/test1");
			shockwave.aCooldown = 15f;
			shockwave.aPanel = ability4;

			//Change the icons to match the ability
			//			ability1.GetComponent<Image> ().sprite = comboJab.aIcon;
			//			ability2.GetComponent<Image> ().sprite = megaFist.aIcon;
			//			ability3.GetComponent<Image> ().sprite = collection.aIcon;
			//			ability4.GetComponent<Image> ().sprite = stomp.aIcon;

		}





		if (!handicap && matchManager != null){
			ability4.GetComponent<CooldownManager> ().StartCooldown (15f);
		}


		if (this.gameObject.name == "Neredy(Clone)") {
			rageEffectL = GameObject.Find ("RageEffectL");
			rageEffectR = GameObject.Find ("RageEffectR");
			rageEffectL.SetActive (false);
			rageEffectR.SetActive (false);
		}


	}


	public void Update () {


		//Set input based on player tag
		if (currentJoystick != null && this.GetComponent<PlayerMovement>().canMove && !this.GetComponent<PlayerState>().isStunned && !this.GetComponent<PlayerState>().isBeingPushed) {
			if (matchManager != null) {
				if (!matchManager.GetComponent<MatchManager> ().isCountingDown) {
					abilityButton1 = currentJoystick.RightTrigger.IsPressed;
					abilityButton2 = currentJoystick.LeftTrigger.IsPressed;
					abilityButton3 = currentJoystick.LeftBumper.IsPressed;
					abilityButton4 = currentJoystick.RightBumper.IsPressed;
//
//					abilityButton1 = currentJoystick.Action1.IsPressed;
//					abilityButton2 = currentJoystick.Action2.IsPressed;
//					abilityButton3 = currentJoystick.Action3.IsPressed;
//					abilityButton4 = currentJoystick.RightStickButton.IsPressed;
				}
			} else {
				abilityButton1 = currentJoystick.RightTrigger.IsPressed;
				abilityButton2 = currentJoystick.LeftTrigger.IsPressed;
				abilityButton3 = currentJoystick.LeftBumper.IsPressed;
				abilityButton4 = currentJoystick.RightBumper.IsPressed;
			}

		}
		//If player is pressing an attack and there's no problem with that, attack
		if (this.gameObject.name == "ToeTip(Clone)") {
			if (this.GetComponent<PlayerMovement> ().isRolling == false && abilityActive == false) {
				if (abilityButton1 && ability1.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability1.GetComponent<CooldownManager> ().StartCooldown (comboJab.aCooldown);
					StartCoroutine("ComboJab");

				}
				if (abilityButton2 && ability2.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability2.GetComponent<CooldownManager> ().StartCooldown (megaFist.aCooldown);
					StartCoroutine("MegaFist");

				}
				if (abilityButton3 && ability3.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability3.GetComponent<CooldownManager> ().StartCooldown (collection.aCooldown);
					StartCoroutine("Collection");

				}
				if (abilityButton4 && ability4.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability4.GetComponent<CooldownManager> ().StartCooldown (stomp.aCooldown);
					StartCoroutine("Stomp");

				}
			}
		}

		if (this.gameObject.name == "Brogre(Clone)") {
			if (this.GetComponent<PlayerMovement> ().isRolling == false && abilityActive == false) {
				if (abilityButton1 && ability1.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability1.GetComponent<CooldownManager> ().StartCooldown (cleave.aCooldown);
					StartCoroutine ("Cleave");

				}
				if (abilityButton2 && ability2.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability2.GetComponent<CooldownManager> ().StartCooldown (shield.aCooldown);
					StartCoroutine("Shield");

				}
				if (abilityButton3 && ability3.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability3.GetComponent<CooldownManager> ().StartCooldown (shield.aCooldown);
					StartCoroutine("ShieldPush");

				}

				if (abilityButton4 && ability4.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability4.GetComponent<CooldownManager> ().StartCooldown (kegToss.aCooldown);
					StartCoroutine("KegToss");

				}


			}
		}
		if (this.gameObject.name == "Neredy(Clone)") {
			if (this.GetComponent<PlayerMovement> ().isRolling == false && abilityActive == false) {
				if (isRaging == false) {
					if (abilityButton1 && ability1.GetComponent<CooldownManager> ().abilityCooling == false) {
						abilityActive = true;
						ability1.GetComponent<CooldownManager> ().StartCooldown (comboAttack.aCooldown);
						StartCoroutine ("ComboAttack");

					}
					if (abilityButton2 && ability2.GetComponent<CooldownManager> ().abilityCooling == false) {
						abilityActive = true;
						ability2.GetComponent<CooldownManager> ().StartCooldown (dashAttack.aCooldown);
						StartCoroutine ("DashAttack");

					}
					if (abilityButton3 && ability3.GetComponent<CooldownManager> ().abilityCooling == false) {
						abilityActive = true;
						ability3.GetComponent<CooldownManager> ().StartCooldown (petrify.aCooldown);
						StartCoroutine ("Petrify");

					}

					if (abilityButton4 && ability4.GetComponent<CooldownManager> ().abilityCooling == false) {
						abilityActive = true;
						ability4.GetComponent<CooldownManager> ().StartCooldown (rage.aCooldown);
						StartCoroutine ("BecomeEnraged");

					}
				} else {
					if (abilityButton1 && ability1.GetComponent<CooldownManager> ().abilityCooling == false) {
						abilityActive = true;
						ability1.GetComponent<CooldownManager> ().StartCooldown (0.8f);
						StartCoroutine ("ComboAttack");

					}
					if (abilityButton2 && ability2.GetComponent<CooldownManager> ().abilityCooling == false) {
						abilityActive = true;
						ability2.GetComponent<CooldownManager> ().StartCooldown (0.5f);
						StartCoroutine ("DashAttack");

					}
					if (abilityButton3 && ability3.GetComponent<CooldownManager> ().abilityCooling == false) {
						abilityActive = true;
						ability3.GetComponent<CooldownManager> ().StartCooldown (0.8f);
						StartCoroutine ("Petrify");

					}






				}


			}
		}

		if (this.gameObject.name == "Tiny(Clone)") {
			if (this.GetComponent<PlayerMovement> ().isRolling == false && abilityActive == false) {
				if (abilityButton1 && ability1.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability1.GetComponent<CooldownManager> ().StartCooldown (duelDaggers.aCooldown);
					StartCoroutine ("DuelDaggers");

				}
				if (abilityButton2 && ability2.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability2.GetComponent<CooldownManager> ().StartCooldown (knifeThrow.aCooldown);
					StartCoroutine("KnifeThrow");

				}
				if (abilityButton3 && ability3.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability3.GetComponent<CooldownManager> ().StartCooldown (clawTrap.aCooldown);
					StartCoroutine("TrapSet");

				}

				if (abilityButton4 && ability4.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability4.GetComponent<CooldownManager> ().StartCooldown (knifeSpin.aCooldown);
					StartCoroutine("KnifeSpin");

				}


			}
		}

		if (this.gameObject.name == "Claymond(Clone)") {
			if (this.GetComponent<PlayerMovement> ().isRolling == false && abilityActive == false) {
				if (abilityButton1 && ability1.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability1.GetComponent<CooldownManager> ().StartCooldown (pushPunch.aCooldown);
					StartCoroutine ("PushPunch");

				}
				if (abilityButton2 && ability2.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability2.GetComponent<CooldownManager> ().StartCooldown (clayShards.aCooldown);
					StartCoroutine("ClayShards");

				}
				if (abilityButton3 && ability3.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability3.GetComponent<CooldownManager> ().StartCooldown (clayWall.aCooldown);
					StartCoroutine("ClayWall");

				}

				if (abilityButton4 && ability4.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability4.GetComponent<CooldownManager> ().StartCooldown (shockwave.aCooldown);
					StartCoroutine("Shockwave");

				}


			}
		}


	}

	public IEnumerator ComboJab(){
		isShooting = true;
		yield return new WaitForSeconds(0.2f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/MiniFist"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/MiniFist"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-10f,10f),rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/MiniFist"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-10f,10f),rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/MiniFist"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-10f,10f),rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		//Do an animation here
		yield return new WaitForSeconds(0.1f);
		isShooting = false;
		abilityActive = false;
		yield return null;

	}


	public IEnumerator MegaFist(){
		isShooting = true;
		yield return new WaitForSeconds(0.2f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/MegaFist"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		//Do an animation here
		yield return new WaitForSeconds(0.1f);
		abilityActive = false;
		isShooting = false;

		yield return null;

	}


	public IEnumerator Collection(){
		isShooting = true;
		yield return new WaitForSeconds (0.2f);
		createdThing = Instantiate (Resources.Load ("SpecialAttacks/CollectionHandHitbox"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;
		yield return new WaitForSeconds (2f);
		isShooting = false;
		abilityActive = false;
		yield return null;
	}

	public IEnumerator Stomp(){
		isStomping = true;
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/GiantHand"), characterPoint2.transform.position + new Vector3(0,25f,0), Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		//Do an animation here
		yield return new WaitForSeconds(1f);
		abilityActive = false;
		isStomping = false;
		yield return null;

	}



	//BROGRE ABILITIES
	public IEnumerator Cleave(){
		isCleaving = true;
		yield return new WaitForSeconds(0.3f);

		createdThing = Instantiate (Resources.Load ("MeleeAttacks/CleaveHitbox"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;
		yield return new WaitForSeconds(0.3f);
		isCleaving = false;
		abilityActive = false;
		yield return null;
	}

	public IEnumerator Shield(){
		isShielding = true;
		createdThing = Instantiate (Resources.Load ("SpecialAttacks/ShieldHitbox"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;


		yield return new WaitForSeconds(1f);
		abilityActive = false;
		isShielding = false;
		yield return null;
	}


	public IEnumerator ShieldPush(){
		isShieldPushing = true;
		this.GetComponent<PlayerMovement> ().canMove = false;
		createdThing = Instantiate (Resources.Load ("MeleeAttacks/ShieldPushHitbox"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;
		for (int i = 0; i < 8; i++) {
			this.GetComponent<PlayerMovement> ().controller.Move (-rotationPoint.transform.forward * 8f * Time.deltaTime);
			yield return new WaitForSeconds(0.02f);
		}
		for (int i = 0; i < 24; i++) {
			this.GetComponent<PlayerMovement> ().controller.Move (rotationPoint.transform.forward * 28f * Time.deltaTime);
			yield return new WaitForSeconds(0.01f);
		}



		yield return new WaitForSeconds(0.3f);
		abilityActive = false;
		isShieldPushing = false;
		this.GetComponent<PlayerMovement> ().canMove = true;
		yield return null;
	}




	public IEnumerator KegToss(){
		isKegTossing = true;
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/KegTossProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-20f,20f),rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		//Do an animation here

		yield return new WaitForSeconds(0.7f);
		abilityActive = false;
		isKegTossing = false;
		yield return null;

	}

	//TINY ABILITIES
	public IEnumerator DuelDaggers(){
		isDaggering = true;

		yield return new WaitForSeconds(0.12f);
		createdThing = Instantiate (Resources.Load ("MeleeAttacks/DaggerHitbox"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;
		yield return new WaitForSeconds(0.42f);
		createdThing = Instantiate (Resources.Load ("MeleeAttacks/DaggerHitbox"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;
		yield return new WaitForSeconds(0.22f);
		isDaggering = false;
		abilityActive = false;
		yield return null;
	}


	public IEnumerator ComboAttack(){
		isDaggering = true;

		yield return new WaitForSeconds(0.12f);
		createdThing = Instantiate (Resources.Load ("MeleeAttacks/DaggerHitbox"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;
		yield return new WaitForSeconds(0.22f);
		createdThing = Instantiate (Resources.Load ("MeleeAttacks/DaggerHitbox"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;
		yield return new WaitForSeconds(0.22f);
		createdThing = Instantiate (Resources.Load ("MeleeAttacks/DaggerHitbox"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;
		//yield return new WaitForSeconds(0.10f);
		if (!isRaging) {
			yield return new WaitForSeconds (0.12f);
		}
		isDaggering = false;
		abilityActive = false;
		yield return null;
	}

	public IEnumerator DashAttack(){
		isDashAttacking = true;
		this.GetComponent<PlayerMovement> ().canMove = false;
		this.GetComponent<PlayerMovement> ().canRotate = false;
		this.GetComponent<Rigidbody> ().detectCollisions = false;
		this.GetComponent<Rigidbody> ().isKinematic = true;
		this.GetComponent<CharacterController> ().detectCollisions = false;
		this.GetComponent<BoxCollider> ().enabled = false;
		createdThing = Instantiate (Resources.Load ("MeleeAttacks/DashHitbox"), transform.position, Quaternion.Euler (rotationPoint.transform.eulerAngles.x, rotationPoint.transform.eulerAngles.y, rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision (this.GetComponent<Collider> (), createdThing.GetComponent<Collider> ());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;
		for (int i = 0; i < 10; i++) {
			this.GetComponent<PlayerMovement> ().controller.Move (rotationPoint.transform.forward * 45f * Time.deltaTime);

			yield return new WaitForSeconds (0.01f);

			
		}



		yield return new WaitForSeconds(0.1f);
		this.GetComponent<BoxCollider> ().enabled = true;
		this.GetComponent<CharacterController> ().detectCollisions = true;
		this.GetComponent<Rigidbody> ().detectCollisions = true;
		this.GetComponent<Rigidbody> ().isKinematic = false;
		abilityActive = false;
		isDashAttacking = false;
		this.GetComponent<PlayerMovement> ().canRotate = true;
		this.GetComponent<PlayerMovement> ().canMove = true;
		yield return null;
	}


	public IEnumerator Petrify(){
		isShielding = true;
		yield return new WaitForSeconds (.2f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/PetrifyProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds (1.2f);

		abilityActive = false;
		isShielding = false;
		yield return null;
	}


	public IEnumerator KnifeThrow(){
		isKnifeThrowing = true;
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/KnifeProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y - 10,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/KnifeProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/KnifeProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + 10,rotationPoint.transform.eulerAngles.z)) as GameObject;


		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		//Do an animation here
		isKnifeThrowing = false;
		abilityActive = false;
		yield return null;



	}

	public IEnumerator TrapSet(){
		isClawTrapping = true;
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("SpecialAttacks/ClawTrap"), transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds(0.7f);
		isClawTrapping = false;
		abilityActive = false;
		yield return null;



	}

	public IEnumerator KnifeSpin(){
		isKnifeSpinning = true;
		this.GetComponent<PlayerMovement> ().canRotate = false;
		yield return new WaitForSeconds(0.1f);
		for (int i = 0; i < 40; i++) {
			createdThing = Instantiate (Resources.Load ("ProjectileAttacks/KnifeProjectile"), characterPoint1.transform.position, Quaternion.Euler (rotationPoint.transform.eulerAngles.x, rotationPoint.transform.eulerAngles.y + Random.Range (-5, 5), rotationPoint.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			Physics.IgnoreCollision (this.GetComponent<Collider> (), createdThing.GetComponent<Collider> ());
			rotationPoint.transform.eulerAngles = new Vector3 (transform.rotation.eulerAngles.x, rotationPoint.transform.rotation.eulerAngles.y + 30f, transform.rotation.eulerAngles.z);
			yield return new WaitForSeconds (0.01f);
		}


		//Do an animation here
		this.GetComponent<PlayerMovement> ().canRotate = true;
		isKnifeSpinning = false;
		abilityActive = false;
		yield return null;



	}

	public IEnumerator PushPunch(){
		isShieldPushing = true;
		this.GetComponent<PlayerMovement> ().canMove = false;
		createdThing = Instantiate (Resources.Load ("MeleeAttacks/PushPunchHitbox"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;
		for (int i = 0; i < 8; i++) {
			this.GetComponent<PlayerMovement> ().controller.Move (rotationPoint.transform.forward * 10f * Time.deltaTime);
			yield return new WaitForSeconds(0.01f);
		}



		yield return new WaitForSeconds(0.3f);
		abilityActive = false;
		isShieldPushing = false;
		this.GetComponent<PlayerMovement> ().canMove = true;
		yield return null;
	}
	public IEnumerator ClayWall(){
		isClawTrapping = true;
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("SpecialAttacks/ClayWall"), characterPoint2.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds(0.3f);
		isClawTrapping = false;
		abilityActive = false;
		yield return null;



	}

	public IEnumerator ClayShards(){
		isKnifeThrowing = true;
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/ClayShardProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y - 65,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/ClayShardProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + 65,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/ClayShardProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y - 75,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/ClayShardProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + 75,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds(0.3f);
		isKnifeThrowing = false;
		abilityActive = false;
		yield return null;



	}

	public IEnumerator BasicArrow(){
		isKnifeThrowing = true;
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/BasicArrow"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y - 65,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());

		yield return new WaitForSeconds(0.3f);
		isKnifeThrowing = false;
		abilityActive = false;
		yield return null;



	}

	public IEnumerator BecomeEnraged(){
		isBecomingEnraged = true;
		ability1.GetComponent<CooldownManager> ().CancelCooldown();
		ability2.GetComponent<CooldownManager> ().CancelCooldown();
		ability3.GetComponent<CooldownManager> ().CancelCooldown();
		StartCoroutine ("Raging");
		yield return new WaitForSeconds(0.6f);
		isBecomingEnraged = false;
		//StartCoroutine ("Raging");
		abilityActive = false;
		yield return null;
		rageEffectL.SetActive (true);
		rageEffectR.SetActive (true);


	}

	public IEnumerator Raging(){

		isRaging = true;
		yield return new WaitForSeconds(8f);
		isRaging = false;
		rageEffectL.SetActive (false);
		rageEffectR.SetActive (false);

	}





}
