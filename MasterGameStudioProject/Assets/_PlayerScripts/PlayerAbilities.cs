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
	public bool isComboJabbing = false;
	public bool isMegaPunching = false;
	public bool isStomping = false;

	public bool isDaggering = false;
	public bool isKnifeThrowing = false;
	public bool isClawTrapping = false;
	public bool isKnifeSpinning = false;


	public GameObject matchManager;

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
			//comboJab.aIcon = Resources.Load<Sprite> ("AbilityIcons/test1");
			comboJab.aCooldown = 1.5f;
			comboJab.aPanel = ability1;

			megaFist.aName = "Mega Fist";
			//megaFist.aIcon = Resources.Load<Sprite> ("AbilityIcons/test1");
			megaFist.aCooldown = 2f;
			megaFist.aPanel = ability2;

			collection.aName = "Collection / Rejection";
			//collection.aIcon = Resources.Load<Sprite> ("AbilityIcons/test3");
			collection.aCooldown = 3f;
			collection.aPanel = ability3;

			stomp.aName = "Stomp";
			//stomp.aIcon = Resources.Load<Sprite> ("AbilityIcons/test1");
			stomp.aCooldown = 0.4f;
			stomp.aPanel = ability4;

			//Change the icons to match the ability
//			ability1.GetComponent<Image> ().sprite = comboJab.aIcon;
//			ability2.GetComponent<Image> ().sprite = megaFist.aIcon;
//			ability3.GetComponent<Image> ().sprite = collection.aIcon;
//			ability4.GetComponent<Image> ().sprite = stomp.aIcon;

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
			//cleave.aIcon = Resources.Load<Sprite> ("AbilityIcons/test1");
			cleave.aCooldown = 0.7f;
			cleave.aPanel = ability1;

			shield.aName = "Shield";
			//shield.aIcon = Resources.Load<Sprite> ("AbilityIcons/test1");
			shield.aCooldown = 5f;
			shield.aPanel = ability2;

			shieldPush.aName = "Shield Push";
			//shieldPush.aIcon = Resources.Load<Sprite> ("AbilityIcons/test3");
			shieldPush.aCooldown = 3f;
			shieldPush.aPanel = ability3;

			kegToss.aName = "Keg Toss";
			//kegToss.aIcon = Resources.Load<Sprite> ("AbilityIcons/test1");
			kegToss.aCooldown = 15f;
			kegToss.aPanel = ability4;

			//Change the icons to match the ability
//			ability1.GetComponent<Image> ().sprite = cleave.aIcon;
//			ability2.GetComponent<Image> ().sprite = shield.aIcon;
//			ability3.GetComponent<Image> ().sprite = shieldPush.aIcon;
//			ability4.GetComponent<Image> ().sprite = kegToss.aIcon;

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
			//cleave.aIcon = Resources.Load<Sprite> ("AbilityIcons/test1");
			duelDaggers.aCooldown = 0.7f;
			duelDaggers.aPanel = ability1;

			knifeThrow.aName = "Knife Throw";
			//shield.aIcon = Resources.Load<Sprite> ("AbilityIcons/test1");
			knifeThrow.aCooldown = 2.5f;
			knifeThrow.aPanel = ability2;

			clawTrap.aName = "Claw Trap";
			//shieldPush.aIcon = Resources.Load<Sprite> ("AbilityIcons/test3");
			clawTrap.aCooldown = 8f;
			clawTrap.aPanel = ability3;

			knifeSpin.aName = "Knife Spin";
			//kegToss.aIcon = Resources.Load<Sprite> ("AbilityIcons/test1");
			knifeSpin.aCooldown = 15f;
			knifeSpin.aPanel = ability4;

			//Change the icons to match the ability
			//			ability1.GetComponent<Image> ().sprite = cleave.aIcon;
			//			ability2.GetComponent<Image> ().sprite = shield.aIcon;
			//			ability3.GetComponent<Image> ().sprite = shieldPush.aIcon;
			//			ability4.GetComponent<Image> ().sprite = kegToss.aIcon;

		}






			ability4.GetComponent<CooldownManager> ().StartCooldown (4f);
		

	}


	public void Update () {


		//Set input based on player tag
		if (currentJoystick != null && this.GetComponent<PlayerMovement>().canMove && !this.GetComponent<PlayerState>().isStunned) {
			if (matchManager != null) {
				if (!matchManager.GetComponent<MatchManager> ().isCountingDown) {
					abilityButton1 = currentJoystick.RightTrigger.IsPressed;
					abilityButton2 = currentJoystick.LeftTrigger.IsPressed;
					abilityButton3 = currentJoystick.LeftBumper.IsPressed;
					abilityButton4 = currentJoystick.RightBumper.IsPressed;
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
					ability4.GetComponent<CooldownManager> ().StartCooldown (collection.aCooldown);
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



	}

	public IEnumerator ComboJab(){
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/MiniFist"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-20f,20f),rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/MiniFist"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-20f,20f),rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/MiniFist"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-20f,20f),rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/MiniFist"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-20f,20f),rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		//Do an animation here
		abilityActive = false;
		yield return null;

	}


	public IEnumerator MegaFist(){

		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/MegaFist"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		//Do an animation here
		abilityActive = false;
		yield return null;

	}


	public IEnumerator Collection(){

		createdThing = Instantiate (Resources.Load ("SpecialAttacks/CollectionHandHitbox"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;
		abilityActive = false;
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
		yield return new WaitForSeconds(.3f);
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


		yield return new WaitForSeconds(2f);
		abilityActive = false;
		isShielding = false;
		yield return null;
	}


	public IEnumerator ShieldPush(){
		isShieldPushing = true;
		this.GetComponent<PlayerMovement> ().controller.Move (rotationPoint.transform.forward * 2.5f);
		createdThing = Instantiate (Resources.Load ("MeleeAttacks/ShieldPushHitbox"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;

		yield return new WaitForSeconds(0.3f);
		abilityActive = false;
		isShieldPushing = false;
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


		createdThing = Instantiate (Resources.Load ("MeleeAttacks/DaggerHitbox"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;
		yield return new WaitForSeconds(0.12f);
		createdThing = Instantiate (Resources.Load ("MeleeAttacks/DaggerHitbox"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;
		yield return new WaitForSeconds(0.12f);
		isDaggering = false;
		abilityActive = false;
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

		isClawTrapping = false;
		abilityActive = false;
		yield return null;



	}

	public IEnumerator KnifeSpin(){
		isKnifeSpinning = true;
		rotationPoint.GetComponent<PlayerRotation> ().canRotate = false;
		yield return new WaitForSeconds(0.1f);
		for (int i = 0; i < 40; i++) {
			createdThing = Instantiate (Resources.Load ("ProjectileAttacks/KnifeProjectile"), characterPoint1.transform.position, Quaternion.Euler (rotationPoint.transform.eulerAngles.x, rotationPoint.transform.eulerAngles.y + Random.Range (-5, 5), rotationPoint.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			Physics.IgnoreCollision (this.GetComponent<Collider> (), createdThing.GetComponent<Collider> ());
			rotationPoint.transform.eulerAngles = new Vector3 (transform.rotation.eulerAngles.x, rotationPoint.transform.rotation.eulerAngles.y + 30f, transform.rotation.eulerAngles.z);
			yield return new WaitForSeconds (0.05f);
		}


		//Do an animation here
		rotationPoint.GetComponent<PlayerRotation> ().canRotate = true;
		isKnifeSpinning = false;
		abilityActive = false;
		yield return null;



	}


}
