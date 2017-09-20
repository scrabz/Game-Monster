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
	CharacterAbility stomp;

	CharacterAbility cleave;
	CharacterAbility shield;
	CharacterAbility shieldPush;
	CharacterAbility kegToss;

	public InputDevice currentJoystick;

	public bool abilityActive = false;
	public GameObject createdThing;

	public GameObject rotationPoint;
	public int teamNum;
	void Start () {

		teamNum = this.GetComponent<PlayerState> ().teamNum;

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


		if (this.gameObject.name == "ToeTip") {

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
			comboJab.aIcon = Resources.Load<Sprite> ("AbilityIcons/test1");
			comboJab.aCooldown = 0.2f;
			comboJab.aPanel = ability1;

			megaFist.aName = "Mega Fist";
			megaFist.aIcon = Resources.Load<Sprite> ("AbilityIcons/test1");
			megaFist.aCooldown = 2f;
			megaFist.aPanel = ability2;

			collection.aName = "Collection / Rejection";
			collection.aIcon = Resources.Load<Sprite> ("AbilityIcons/test3");
			collection.aCooldown = 1.5f;
			collection.aPanel = ability3;

			stomp.aName = "Stomp";
			stomp.aIcon = Resources.Load<Sprite> ("AbilityIcons/test1");
			stomp.aCooldown = 0.4f;
			stomp.aPanel = ability4;

			//Change the icons to match the ability
			ability1.GetComponent<Image> ().sprite = comboJab.aIcon;
			ability2.GetComponent<Image> ().sprite = megaFist.aIcon;
			ability3.GetComponent<Image> ().sprite = collection.aIcon;
			ability4.GetComponent<Image> ().sprite = stomp.aIcon;

		}

		if (this.gameObject.name == "Brogre") {

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
			cleave.aIcon = Resources.Load<Sprite> ("AbilityIcons/test1");
			cleave.aCooldown = 1.2f;
			cleave.aPanel = ability1;

			shield.aName = "Shield";
			shield.aIcon = Resources.Load<Sprite> ("AbilityIcons/test1");
			shield.aCooldown = 2f;
			shield.aPanel = ability2;

			shieldPush.aName = "Shield Push";
			shieldPush.aIcon = Resources.Load<Sprite> ("AbilityIcons/test3");
			shieldPush.aCooldown = 1.5f;
			shieldPush.aPanel = ability3;

			kegToss.aName = "Keg Toss";
			kegToss.aIcon = Resources.Load<Sprite> ("AbilityIcons/test1");
			kegToss.aCooldown = 0.4f;
			kegToss.aPanel = ability4;

			//Change the icons to match the ability
			ability1.GetComponent<Image> ().sprite = cleave.aIcon;
			ability2.GetComponent<Image> ().sprite = shield.aIcon;
			ability3.GetComponent<Image> ().sprite = shieldPush.aIcon;
			ability4.GetComponent<Image> ().sprite = kegToss.aIcon;

		}



	}


	public void Update () {


		//Set input based on player tag
		if (currentJoystick != null) {

			abilityButton1 = currentJoystick.RightTrigger.IsPressed;
			abilityButton2 = currentJoystick.LeftTrigger.IsPressed;
			abilityButton3 = currentJoystick.LeftBumper.IsPressed;
			abilityButton4 = currentJoystick.RightBumper.IsPressed;

		}
		//If player is pressing an attack and there's no problem with that, attack
		if (this.gameObject.name == "ToeTip") {
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
			}
		}

		if (this.gameObject.name == "Brogre") {
			if (this.GetComponent<PlayerMovement> ().isRolling == false && abilityActive == false) {
				if (abilityButton1 && ability1.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability1.GetComponent<CooldownManager> ().StartCooldown (cleave.aCooldown);
					StartCoroutine ("Cleave");

				}
				if (abilityButton2 && ability2.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability2.GetComponent<CooldownManager> ().StartCooldown (megaFist.aCooldown);
					StartCoroutine("MegaFist");

				}
			}
		}


	}

	public void StartCooldown(GameObject whichAbility){
		

	}
	public IEnumerator ComboJab(){

		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/MiniFist"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-20f,20f),rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		//Do an animation here
		abilityActive = false;
		yield return null;

	}


	public IEnumerator MegaFist(){

		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/MegaFist"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;
		//Do an animation here
		abilityActive = false;
		yield return null;

	}

	public IEnumerator Cleave(){

		yield return new WaitForSeconds(0.3f);

		createdThing = Instantiate (Resources.Load ("MeleeAttacks/CleaveHitbox"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;
		abilityActive = false;
		yield return null;
	}

}
