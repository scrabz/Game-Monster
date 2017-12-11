using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using InControl;

public class PlayerAbilities : MonoBehaviour {


	[SerializeField] private CharacterAbility ability;
	public GameObject abilityPanel;
	public GameObject ability1;
	public GameObject ability2;
	public GameObject ability3;
	public GameObject ability4;
	public GameObject characterPortrait;

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


	CharacterAbility potionToss;
	CharacterAbility poisonCloud;
	CharacterAbility undeadCompanions;
	CharacterAbility bagOfTricks;


	CharacterAbility pushPunch;
	CharacterAbility clayShards;
	CharacterAbility clayWall;
	CharacterAbility shockwave;


	CharacterAbility basicArrow;
	CharacterAbility napalmStrike;
	CharacterAbility arrowArsenal;
	CharacterAbility trueForm;

	CharacterAbility comboAttack;
	CharacterAbility dashAttack;
	CharacterAbility petrify;
	CharacterAbility rage;

	CharacterAbility darkClaw;
	CharacterAbility whip;
	CharacterAbility kissOfDeath;
	CharacterAbility lifeSteal;

	public GameObject rageEffectL;
	public GameObject rageEffectR;

	public InputDevice currentJoystick;

	public bool abilityActive = false;
	public GameObject createdThing;

	public GameObject rotationPoint;
	public int teamNum;

	//Dumb Bools

	public bool gotSomeone = false;

	public bool doingAbil1 = false;
	public bool doingAbil2 = false;
	public bool doingAbil3 = false;
	public bool doingAbil4 = false;

	public bool isRaging = false;

	public GameObject matchManager;

	public bool handicap = false;
	public GameObject cam;

	public int selectedArrow = 0;

	public AudioClip brogreJump;
	public AudioClip brogreSmash;
	public AudioClip brogreSlash;
	public AudioClip brogreShield;
	public AudioClip brogreToss;
	public AudioClip brogreWet;

	public AudioClip tinyKnife;
	public AudioClip tinyDash;
	public AudioClip tinyTrapPlace;
	public AudioClip tinyUlt;


	public AudioClip decayPotionThrow;
	public AudioClip decaySmoke;
	public AudioClip decayLeechThrow;
	public AudioClip decayCrowThrow;
	public AudioClip decayFrogThrow;


	public AudioClip neredyDash;
	public AudioClip neredyEnrage;

	void Start () {
		cam = GameObject.Find ("Main Camera");
		teamNum = this.GetComponent<PlayerState> ().teamNum;
		matchManager = GameObject.Find ("MatchManager");
		characterModel = transform.Find ("RotationPoint").Find ("Model").gameObject;

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

		//var inputDevice = (InputManager.Devices.Count > this.GetComponent<PlayerState>().teamNum) ? InputManager.Devices[this.GetComponent<PlayerState>().teamNum] : null;
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
		if (!this.gameObject.name.Contains ("Dummy")) {
			characterPortrait = abilityPanel.transform.Find ("ChrPortrait").gameObject;
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
			comboJab.aIcon = Resources.Load<Sprite> ("AbilityIcons/GA1");
			comboJab.aCooldown = 1f;
			comboJab.aPanel = ability1;

			megaFist.aName = "Mega Fist";
			megaFist.aIcon = Resources.Load<Sprite> ("AbilityIcons/GA2");
			megaFist.aCooldown = 2f;
			megaFist.aPanel = ability2;

			collection.aName = "Collection / Rejection";
			collection.aIcon = Resources.Load<Sprite> ("AbilityIcons/GA3");
			collection.aCooldown = 2.8f;
			collection.aPanel = ability3;

			stomp.aName = "Stomp";
			stomp.aIcon = Resources.Load<Sprite> ("AbilityIcons/GA4");
			stomp.aCooldown = 15f;
			stomp.aPanel = ability4;

			//Change the icons to match the ability
			ability1.GetComponent<Image> ().sprite = comboJab.aIcon;
			ability2.GetComponent<Image> ().sprite = megaFist.aIcon;
			ability3.GetComponent<Image> ().sprite = collection.aIcon;
			ability4.GetComponent<Image> ().sprite = stomp.aIcon;
			characterPortrait.GetComponent<Image>().sprite = Resources.Load<Sprite> ("CharacterPortraits/SkeletonP");
		}

		if (this.gameObject.name == "Brogre(Clone)") {


			brogreJump = Resources.Load ("SFX/BrogreJump") as AudioClip;
			brogreSmash = Resources.Load ("SFX/BrogreSmash") as AudioClip;
			brogreSlash = Resources.Load ("SFX/BrogreSlash") as AudioClip;
			brogreShield = Resources.Load ("SFX/BrogreShield") as AudioClip;
			brogreToss = Resources.Load ("SFX/BrogreToss") as AudioClip;
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
			cleave.aIcon = Resources.Load<Sprite> ("AbilityIcons/BA1");
			cleave.aCooldown = 1f;
			cleave.aPanel = ability1;

			shield.aName = "Shield";
			shield.aIcon = Resources.Load<Sprite> ("AbilityIcons/BA2");
			shield.aCooldown = 6f;
			shield.aPanel = ability2;

			shieldPush.aName = "Shield Push";
			shieldPush.aIcon = Resources.Load<Sprite> ("AbilityIcons/BA3");
			shieldPush.aCooldown = 4f;
			shieldPush.aPanel = ability3;

			kegToss.aName = "Keg Toss";
			kegToss.aIcon = Resources.Load<Sprite> ("AbilityIcons/BA4");
			kegToss.aCooldown = 15f;
			kegToss.aPanel = ability4;

			//Change the icons to match the ability
			ability1.GetComponent<Image> ().sprite = cleave.aIcon;
			ability2.GetComponent<Image> ().sprite = shield.aIcon;
			ability3.GetComponent<Image> ().sprite = shieldPush.aIcon;
			ability4.GetComponent<Image> ().sprite = kegToss.aIcon;
			characterPortrait.GetComponent<Image>().sprite = Resources.Load<Sprite> ("CharacterPortraits/BrogreP");
		}


		if (this.gameObject.name == "Neredy(Clone)") {

			comboAttack = new CharacterAbility ();
			dashAttack = new CharacterAbility ();
			petrify = new CharacterAbility ();
			rage = new CharacterAbility ();

			neredyDash = Resources.Load ("SFX/NeredyDash") as AudioClip;
			neredyEnrage = Resources.Load ("SFX/NeredyEnrage") as AudioClip;
			//Find the Ability panels
			ability1 = abilityPanel.transform.Find ("Ability1").gameObject;
			ability2 = abilityPanel.transform.Find ("Ability2").gameObject;
			ability3 = abilityPanel.transform.Find ("Ability3").gameObject;
			ability4 = abilityPanel.transform.Find ("Ability4").gameObject;

			//Set the properties of every ability
			comboAttack.aName = "Combo Attack";
			comboAttack.aIcon = Resources.Load<Sprite> ("AbilityIcons/NA1");
			comboAttack.aCooldown = 0.6f;
			comboAttack.aPanel = ability1;

			dashAttack.aName = "Dash Attack";
			dashAttack.aIcon = Resources.Load<Sprite> ("AbilityIcons/NA2");
			dashAttack.aCooldown = 1.5f;
			dashAttack.aPanel = ability2;

			petrify.aName = "Petrify";
			petrify.aIcon = Resources.Load<Sprite> ("AbilityIcons/NA3");
			petrify.aCooldown = 8f;
			petrify.aPanel = ability3;

			rage.aName = "Rage";
			rage.aIcon = Resources.Load<Sprite> ("AbilityIcons/NA4");
			rage.aCooldown = 15f;
			rage.aPanel = ability4;

			//Change the icons to match the ability
			ability1.GetComponent<Image> ().sprite = comboAttack.aIcon;
			ability2.GetComponent<Image> ().sprite = dashAttack.aIcon;
			ability3.GetComponent<Image> ().sprite = petrify.aIcon;
			ability4.GetComponent<Image> ().sprite = rage.aIcon;
			characterPortrait.GetComponent<Image>().sprite = Resources.Load<Sprite> ("CharacterPortraits/GorgonP");
		}


		if (this.gameObject.name == "Tiny(Clone)") {


			tinyDash = Resources.Load ("SFX/TinyDash") as AudioClip;
			tinyKnife = Resources.Load ("SFX/TinyKnife") as AudioClip;
			tinyTrapPlace = Resources.Load ("SFX/TinyTrapDrop") as AudioClip;
			tinyUlt = Resources.Load ("SFX/TinyUlt") as AudioClip;

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
			duelDaggers.aIcon = Resources.Load<Sprite> ("AbilityIcons/TA1");
			duelDaggers.aCooldown = 0.7f;
			duelDaggers.aPanel = ability1;

			knifeThrow.aName = "Knife Throw";
			knifeThrow.aIcon = Resources.Load<Sprite> ("AbilityIcons/TA2");
			knifeThrow.aCooldown = 1f;
			knifeThrow.aPanel = ability2;

			clawTrap.aName = "Claw Trap";
			clawTrap.aIcon = Resources.Load<Sprite> ("AbilityIcons/TA3");
			clawTrap.aCooldown = 8f;
			clawTrap.aPanel = ability3;

			knifeSpin.aName = "Knife Spin";
			knifeSpin.aIcon = Resources.Load<Sprite> ("AbilityIcons/TA4");
			knifeSpin.aCooldown = 15f;
			knifeSpin.aPanel = ability4;

			//Change the icons to match the ability
			ability1.GetComponent<Image> ().sprite = duelDaggers.aIcon;
			ability2.GetComponent<Image> ().sprite = knifeThrow.aIcon;
			ability3.GetComponent<Image> ().sprite = clawTrap.aIcon;
			ability4.GetComponent<Image> ().sprite = knifeSpin.aIcon;
			characterPortrait.GetComponent<Image>().sprite = Resources.Load<Sprite> ("CharacterPortraits/TinyP");
		}

		if (this.gameObject.name == "DrDecay(Clone)") {


			decayPotionThrow = Resources.Load ("SFX/DecayPotionThrow") as AudioClip;
			decaySmoke = Resources.Load ("SFX/DecaySmoke") as AudioClip;
			decayCrowThrow = Resources.Load ("SFX/DecayCrowThrow") as AudioClip;
			decayFrogThrow = Resources.Load ("SFX/DecayFrogThrow") as AudioClip;
			decayLeechThrow = Resources.Load ("SFX/DecayCrowBite") as AudioClip;


			potionToss = new CharacterAbility ();
			poisonCloud = new CharacterAbility ();
			undeadCompanions = new CharacterAbility ();
			bagOfTricks = new CharacterAbility ();

			//Find the Ability panels
			ability1 = abilityPanel.transform.Find ("Ability1").gameObject;
			ability2 = abilityPanel.transform.Find ("Ability2").gameObject;
			ability3 = abilityPanel.transform.Find ("Ability3").gameObject;
			ability4 = abilityPanel.transform.Find ("Ability4").gameObject;

			//Set the properties of every ability
			potionToss.aName = "Duel Daggers";
			potionToss.aIcon = Resources.Load<Sprite> ("AbilityIcons/DA1");
			potionToss.aCooldown = 0.7f;
			potionToss.aPanel = ability1;

			poisonCloud.aName = "Knife Throw";
			poisonCloud.aIcon = Resources.Load<Sprite> ("AbilityIcons/DA2");
			poisonCloud.aCooldown = 2.5f;
			poisonCloud.aPanel = ability2;

			undeadCompanions.aName = "Claw Trap";
			undeadCompanions.aIcon = Resources.Load<Sprite> ("AbilityIcons/DA3");
			undeadCompanions.aCooldown = 2f;
			undeadCompanions.aPanel = ability3;

			bagOfTricks.aName = "Knife Spin";
			bagOfTricks.aIcon = Resources.Load<Sprite> ("AbilityIcons/DA4");
			bagOfTricks.aCooldown = 15f;
			bagOfTricks.aPanel = ability4;

			//Change the icons to match the ability
			ability1.GetComponent<Image> ().sprite = potionToss.aIcon;
			ability2.GetComponent<Image> ().sprite = poisonCloud.aIcon;
			ability3.GetComponent<Image> ().sprite = undeadCompanions.aIcon;
			ability4.GetComponent<Image> ().sprite = bagOfTricks.aIcon;
			characterPortrait.GetComponent<Image>().sprite = Resources.Load<Sprite> ("CharacterPortraits/DrDecayP");
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
			clayShards.aName = "Clay Shards";
			clayShards.aIcon = Resources.Load<Sprite> ("AbilityIcons/GEA1");
			clayShards.aCooldown = 0.8f;
			clayShards.aPanel = ability1;

			pushPunch.aName = "Push Punch";
			pushPunch.aIcon = Resources.Load<Sprite> ("AbilityIcons/GEA2");
			pushPunch.aCooldown = 3f;
			pushPunch.aPanel = ability2;

			clayWall.aName = "Clay Wall";
			clayWall.aIcon = Resources.Load<Sprite> ("AbilityIcons/GEA3");
			clayWall.aCooldown = 8f;
			clayWall.aPanel = ability3;

			shockwave.aName = "Shockwave";
			shockwave.aIcon = Resources.Load<Sprite> ("AbilityIcons/GEA4");
			shockwave.aCooldown = 15f;
			shockwave.aPanel = ability4;
			characterPortrait.GetComponent<Image>().sprite = Resources.Load<Sprite> ("CharacterPortraits/ClaymondP");

			//Change the icons to match the ability
			ability1.GetComponent<Image> ().sprite = pushPunch.aIcon;
			ability2.GetComponent<Image> ().sprite = clayShards.aIcon;
			ability3.GetComponent<Image> ().sprite = clayWall.aIcon;
			ability4.GetComponent<Image> ().sprite = shockwave.aIcon;

		}


		if (this.gameObject.name == "Iris(Clone)") {

			darkClaw = new CharacterAbility ();
			whip = new CharacterAbility ();
			kissOfDeath = new CharacterAbility ();
			lifeSteal = new CharacterAbility ();

			//Find the Ability panels
			ability1 = abilityPanel.transform.Find ("Ability1").gameObject;
			ability2 = abilityPanel.transform.Find ("Ability2").gameObject;
			ability3 = abilityPanel.transform.Find ("Ability3").gameObject;
			ability4 = abilityPanel.transform.Find ("Ability4").gameObject;

			//Set the properties of every ability
			darkClaw.aName = "Push Punch";
			darkClaw.aIcon = Resources.Load<Sprite> ("AbilityIcons/IA1");
			darkClaw.aCooldown = 0.8f;
			darkClaw.aPanel = ability1;

			whip.aName = "Clay Shards";
			whip.aIcon = Resources.Load<Sprite> ("AbilityIcons/IA2");
			whip.aCooldown = 3f;
			whip.aPanel = ability2;

			kissOfDeath.aName = "Clay Wall";
			kissOfDeath.aIcon = Resources.Load<Sprite> ("AbilityIcons/IA3");
			kissOfDeath.aCooldown = 5f;
			kissOfDeath.aPanel = ability3;

			lifeSteal.aName = "Shockwave";
			lifeSteal.aIcon = Resources.Load<Sprite> ("AbilityIcons/IA4");
			lifeSteal.aCooldown = 15f;
			lifeSteal.aPanel = ability4;
			characterPortrait.GetComponent<Image>().sprite = Resources.Load<Sprite> ("CharacterPortraits/SuccP");

			//Change the icons to match the ability
			ability1.GetComponent<Image> ().sprite = darkClaw.aIcon;
			ability2.GetComponent<Image> ().sprite = whip.aIcon;
			ability3.GetComponent<Image> ().sprite = kissOfDeath.aIcon;
			ability4.GetComponent<Image> ().sprite = lifeSteal.aIcon;

		}


		if (this.gameObject.name == "Guy(Clone)") {

			basicArrow = new CharacterAbility ();
			napalmStrike = new CharacterAbility ();
			arrowArsenal = new CharacterAbility ();
			trueForm = new CharacterAbility ();

			//Find the Ability panels
			ability1 = abilityPanel.transform.Find ("Ability1").gameObject;
			ability2 = abilityPanel.transform.Find ("Ability2").gameObject;
			ability3 = abilityPanel.transform.Find ("Ability3").gameObject;
			ability4 = abilityPanel.transform.Find ("Ability4").gameObject;

			//Set the properties of every ability
			basicArrow.aName = "Push Punch";
			basicArrow.aIcon = Resources.Load<Sprite> ("AbilityIcons/GUA1");
			basicArrow.aCooldown = 0.5f;
			basicArrow.aPanel = ability1;

			napalmStrike.aName = "C";
			napalmStrike.aIcon = Resources.Load<Sprite> ("AbilityIcons/GUA2");
			napalmStrike.aCooldown = 4f;
			napalmStrike.aPanel = ability2;

			arrowArsenal.aName = "Clay Wall";
			arrowArsenal.aIcon = Resources.Load<Sprite> ("AbilityIcons/GUA3");
			arrowArsenal.aCooldown = 2f;
			arrowArsenal.aPanel = ability3;

			trueForm.aName = "Shockwave";
			trueForm.aIcon = Resources.Load<Sprite> ("AbilityIcons/GUA4");
			trueForm.aCooldown = 25f;
			trueForm.aPanel = ability4;
			characterPortrait.GetComponent<Image>().sprite = Resources.Load<Sprite> ("CharacterPortraits/GuyP");
			ability1.GetComponent<Image> ().sprite = basicArrow.aIcon;
			ability2.GetComponent<Image> ().sprite = napalmStrike.aIcon;
			ability3.GetComponent<Image> ().sprite = arrowArsenal.aIcon;
			ability4.GetComponent<Image> ().sprite = trueForm.aIcon;

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


	public void FixedUpdate () {


		//Set input based on player tag
		if (currentJoystick != null && this.GetComponent<PlayerMovement>().canMove && !this.GetComponent<PlayerMovement>().matchOver && !this.GetComponent<PlayerState>().isStunned && !this.GetComponent<PlayerState>().isBeingPushed) {
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
			if (this.GetComponent<PlayerMovement>().matchOver == false && abilityActive == false) {
				if (abilityButton1 && ability1.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability1.GetComponent<CooldownManager> ().StartCooldown (comboJab.aCooldown);
					StopAllCoroutines ();
					StartCoroutine("ComboJab");

				}
				if (abilityButton2 && ability2.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability2.GetComponent<CooldownManager> ().StartCooldown (megaFist.aCooldown);
					StopAllCoroutines ();
					StartCoroutine("MegaFist");

				}
				if (abilityButton3 && ability3.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability3.GetComponent<CooldownManager> ().StartCooldown (collection.aCooldown);
					StopAllCoroutines ();
					StartCoroutine("Collection");

				}
				if (abilityButton4 && ability4.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability4.GetComponent<CooldownManager> ().StartCooldown (stomp.aCooldown);
					StopAllCoroutines ();
					StartCoroutine("Stomp");

				}
			}
		}

		if (this.gameObject.name == "Brogre(Clone)") {
			if (this.GetComponent<PlayerMovement>().matchOver == false && abilityActive == false) {
				if (abilityButton1 && ability1.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability1.GetComponent<CooldownManager> ().StartCooldown (cleave.aCooldown);
					StopAllCoroutines ();
					StartCoroutine ("Cleave");

				}
				if (abilityButton2 && ability2.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability2.GetComponent<CooldownManager> ().StartCooldown (shieldPush.aCooldown);
					StopAllCoroutines ();
					StartCoroutine("ShieldPush");

				}
				if (abilityButton3 && ability3.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability3.GetComponent<CooldownManager> ().StartCooldown (shield.aCooldown);
					StopAllCoroutines ();
					StartCoroutine("Shield");

				}

				if (abilityButton4 && ability4.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability4.GetComponent<CooldownManager> ().StartCooldown (kegToss.aCooldown);
					StopAllCoroutines ();
					StartCoroutine("KegToss");

				}


			}
		}
		if (this.gameObject.name == "Neredy(Clone)") {
			if (this.GetComponent<PlayerMovement>().matchOver == false && abilityActive == false) {
				if (isRaging == false) {
					if (abilityButton1 && ability1.GetComponent<CooldownManager> ().abilityCooling == false) {
						abilityActive = true;
						ability1.GetComponent<CooldownManager> ().StartCooldown (comboAttack.aCooldown);
						StopAllCoroutines ();
						StartCoroutine ("ComboAttack");

					}
					if (abilityButton2 && ability2.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
						abilityActive = true;
						ability2.GetComponent<CooldownManager> ().StartCooldown (dashAttack.aCooldown);
						StopAllCoroutines ();

						StartCoroutine ("DashAttack");

					}
					if (abilityButton3 && ability3.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
						abilityActive = true;
						ability3.GetComponent<CooldownManager> ().StartCooldown (petrify.aCooldown);
						StopAllCoroutines ();
						StartCoroutine ("Petrify");

					}

					if (abilityButton4 && ability4.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
						abilityActive = true;
						ability4.GetComponent<CooldownManager> ().StartCooldown (rage.aCooldown);
						StopAllCoroutines ();
						StartCoroutine ("BecomeEnraged");

					}
				} else {
					if (abilityButton1 && ability1.GetComponent<CooldownManager> ().abilityCooling == false) {
						abilityActive = true;
						ability1.GetComponent<CooldownManager> ().StartCooldown (0.8f);
						//StopAllCoroutines ();
						StartCoroutine ("ComboAttack");

					}
					if (abilityButton2 && ability2.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
						abilityActive = true;
						ability2.GetComponent<CooldownManager> ().StartCooldown (0.5f);
						//StopAllCoroutines ();
						StartCoroutine ("DashAttack");

					}
					if (abilityButton3 && ability3.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
						abilityActive = true;
						ability3.GetComponent<CooldownManager> ().StartCooldown (0.8f);
						//StopAllCoroutines ();
						StartCoroutine ("Petrify");

					}






				}


			}
		}

		if (this.gameObject.name == "Tiny(Clone)") {
			if (this.GetComponent<PlayerMovement>().matchOver == false && abilityActive == false) {
				if (abilityButton1 && ability1.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability1.GetComponent<CooldownManager> ().StartCooldown (knifeThrow.aCooldown);
					StopAllCoroutines ();
					StartCoroutine ("KnifeThrow");

				}
				if (abilityButton2 && ability2.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability2.GetComponent<CooldownManager> ().StartCooldown (knifeThrow.aCooldown);
					StopAllCoroutines ();
					StartCoroutine("QuickSlash");

				}
				if (abilityButton3 && ability3.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability3.GetComponent<CooldownManager> ().StartCooldown (clawTrap.aCooldown);
					StopAllCoroutines ();
					StartCoroutine("TrapSet");

				}

				if (abilityButton4 && ability4.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability4.GetComponent<CooldownManager> ().StartCooldown (knifeSpin.aCooldown);
					StopAllCoroutines ();
					StartCoroutine("KnifeSpin");

				}


			}
		}

		if (this.gameObject.name == "Iris(Clone)") {
			if (this.GetComponent<PlayerMovement>().matchOver == false && abilityActive == false) {
				if (abilityButton1 && ability1.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability1.GetComponent<CooldownManager> ().StartCooldown (darkClaw.aCooldown);
					StopAllCoroutines ();
					StartCoroutine ("DarkClaw");

				}
				if (abilityButton2 && ability2.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability2.GetComponent<CooldownManager> ().StartCooldown (whip.aCooldown);
					StopAllCoroutines ();
					StartCoroutine("Whip");

				}
				if (abilityButton3 && ability3.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability3.GetComponent<CooldownManager> ().StartCooldown (kissOfDeath.aCooldown);
					StopAllCoroutines ();
					StartCoroutine("KissOfDeath");

				}

				if (abilityButton4 && ability4.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability4.GetComponent<CooldownManager> ().StartCooldown (lifeSteal.aCooldown);
					StopAllCoroutines ();
					StartCoroutine("LifeSteal");

				}


			}
		}



		if (this.gameObject.name == "DrDecay(Clone)") {
			if (this.GetComponent<PlayerMovement>().matchOver == false && abilityActive == false) {
				if (abilityButton1 && ability1.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability1.GetComponent<CooldownManager> ().StartCooldown (potionToss.aCooldown);
					StopAllCoroutines ();
					StartCoroutine ("PotionToss");

				}
				if (abilityButton2 && ability2.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability2.GetComponent<CooldownManager> ().StartCooldown (poisonCloud.aCooldown);
					StopAllCoroutines ();
					StartCoroutine("PoisonCloud");

				}
				if (abilityButton3 && ability3.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability3.GetComponent<CooldownManager> ().StartCooldown (undeadCompanions.aCooldown);
					StopAllCoroutines ();
					StartCoroutine("UndeadCompanions");

				}

				if (abilityButton4 && ability4.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability4.GetComponent<CooldownManager> ().StartCooldown (bagOfTricks.aCooldown);
					StopAllCoroutines ();
					StartCoroutine("BagOfTricks");

				}


			}
		}


		if (this.gameObject.name == "Claymond(Clone)") {
			if (this.GetComponent<PlayerMovement>().matchOver == false && abilityActive == false) {
				if (abilityButton1 && ability1.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability1.GetComponent<CooldownManager> ().StartCooldown (clayShards.aCooldown);
					StartCoroutine ("ClayShards");

				}
				if (abilityButton2 && ability2.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability2.GetComponent<CooldownManager> ().StartCooldown (pushPunch.aCooldown);
					StartCoroutine("PushPunch");

				}
				if (abilityButton3 && ability3.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability3.GetComponent<CooldownManager> ().StartCooldown (clayWall.aCooldown);
					StartCoroutine("ClayWall");

				}

				if (abilityButton4 && ability4.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability4.GetComponent<CooldownManager> ().StartCooldown (shockwave.aCooldown);
					StartCoroutine("GroundSlam");

				}


			}
		}

		if (this.gameObject.name == "Guy(Clone)") {
			if (this.GetComponent<PlayerMovement>().matchOver == false && abilityActive == false) {
				if (abilityButton1 && ability1.GetComponent<CooldownManager> ().abilityCooling == false) {
					abilityActive = true;
					ability1.GetComponent<CooldownManager> ().StartCooldown (basicArrow.aCooldown);
					StartCoroutine ("BasicArrow");

				}
				if (abilityButton2 && ability2.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability2.GetComponent<CooldownManager> ().StartCooldown (napalmStrike.aCooldown);
					StartCoroutine("NapalmStrike");

				}
				if (abilityButton3 && ability3.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability3.GetComponent<CooldownManager> ().StartCooldown (arrowArsenal.aCooldown);
					StartCoroutine("ArrowArsenal");

				}

				if (abilityButton4 && ability4.GetComponent<CooldownManager> ().abilityCooling == false && !abilityActive) {
					abilityActive = true;
					ability4.GetComponent<CooldownManager> ().StartCooldown (trueForm.aCooldown);
					StartCoroutine("TrueForm");

				}


			}
		}




	}

	public IEnumerator Whip(){
		doingAbil2 = true;

		yield return new WaitForSeconds(0.4f);
		createdThing = Instantiate (Resources.Load ("SpecialAttacks/WhipHitbox"), characterPoint2.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint2;
		//this.GetComponent<AudioSource> ().clip = brogreSlash;
		//this.GetComponent<AudioSource> ().Play ();


		yield return new WaitForSeconds(0.35f);
		if (gotSomeone == false) {
			gotSomeone = true;
			yield return new WaitForSeconds(0.5f);
		}



		gotSomeone = false;
		doingAbil2 = false;
		abilityActive = false;
		yield return null;
	}

	public IEnumerator TrueForm(){
		characterModel.transform.Find("GuyEyes").GetComponent<SkinnedMeshRenderer> ().enabled = false;
		characterModel.transform.Find("guyHat").GetComponent<SkinnedMeshRenderer> ().enabled = false;
		characterModel.transform.Find("guyHair1").GetComponent<SkinnedMeshRenderer> ().enabled = false;
		characterModel.transform.Find("guyHair1").GetComponent<SkinnedMeshRenderer> ().enabled = false;
		characterModel.transform.Find("GuyBody").GetComponent<SkinnedMeshRenderer> ().enabled = false;
		characterModel.transform.Find("GuyBow").GetComponent<SkinnedMeshRenderer> ().enabled = false;
		characterModel.transform.Find("guyEyeBrows").GetComponent<SkinnedMeshRenderer> ().enabled = false;
		characterModel.transform.Find("polySurface1").GetComponent<SkinnedMeshRenderer> ().enabled = false;
		this.GetComponent<PlayerState> ().Invincibility (3f,false);
		this.GetComponent<PlayerMovement> ().canRotate = false;
		createdThing = Instantiate (Resources.Load ("Blackout"),cam.transform) as GameObject;
		this.GetComponent<PlayerState> ().itemImage.enabled = false;
		cam.GetComponent<Grayscale> ().enabled = true;
		createdThing = Instantiate (Resources.Load ("SpecialAttacks/ShadowBeastHitbox"), transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint2;
		//Do an animation here
		yield return new WaitForSeconds(3f);
		createdThing = Instantiate (Resources.Load ("Blackout"),cam.transform) as GameObject;
		characterModel.transform.Find("GuyBody").GetComponent<SkinnedMeshRenderer> ().enabled = true;
		characterModel.transform.Find("GuyEyes").GetComponent<SkinnedMeshRenderer> ().enabled = true;
		characterModel.transform.Find("guyHat").GetComponent<SkinnedMeshRenderer> ().enabled = true;
		characterModel.transform.Find("guyHair1").GetComponent<SkinnedMeshRenderer> ().enabled = true;
		characterModel.transform.Find("guyHair1").GetComponent<SkinnedMeshRenderer> ().enabled = true;
		characterModel.transform.Find("GuyBody").GetComponent<SkinnedMeshRenderer> ().enabled = true;
		characterModel.transform.Find("GuyBow").GetComponent<SkinnedMeshRenderer> ().enabled = true;
		characterModel.transform.Find("guyEyeBrows").GetComponent<SkinnedMeshRenderer> ().enabled = true;
		characterModel.transform.Find("polySurface1").GetComponent<SkinnedMeshRenderer> ().enabled = true;

		cam.GetComponent<Grayscale> ().enabled = false;
		this.GetComponent<PlayerMovement> ().canRotate = true;
		this.GetComponent<PlayerState> ().itemImage.enabled = true;
		abilityActive = false;
		doingAbil4 = false;
		yield return null;
	}
	public IEnumerator Shockwave(){
		yield return null;
	}


	public IEnumerator ComboJab(){
		doingAbil1 = true;
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/MiniFist"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-10f,10f),rotationPoint.transform.eulerAngles.z)) as GameObject;
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
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/MiniFist"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-20f,20f),rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds(0.1f);
		doingAbil1 = false;
		abilityActive = false;
		yield return null;

	}


	public IEnumerator MegaFist(){
		doingAbil2 = true;
		yield return new WaitForSeconds(0.2f);
		this.GetComponent<PlayerMovement> ().canMove = false;
		this.GetComponent<PlayerMovement> ().canRotate = false;
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/MegaFist"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		for (int i = 0; i < 16; i++) {
			if (this.GetComponent<PlayerMovement> ().lockedInPlace == false) {
				this.GetComponent<PlayerMovement> ().controller.Move (rotationPoint.transform.forward * -28f * Time.deltaTime);
			}
			yield return new WaitForSeconds(0.01f);
		}
		//Do an animation here
		yield return new WaitForSeconds(0.05f);
		abilityActive = false;
		this.GetComponent<PlayerMovement> ().canRotate = true;
		this.GetComponent<PlayerMovement> ().canMove = true;
		doingAbil2 = false;

		yield return null;

	}


	public IEnumerator Collection(){
		float coolVar;
		doingAbil3 = true;
		if (storedProjectiles.Count > 0){
			coolVar = 0.2f;
		}
		else{
			coolVar = 2.5f;
		}
		yield return new WaitForSeconds (0.2f);
		createdThing = Instantiate (Resources.Load ("SpecialAttacks/CollectionHandHitbox"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;

		yield return new WaitForSeconds (coolVar);
		doingAbil3 = false;
		abilityActive = false;
		yield return null;
	}

	public IEnumerator Stomp(){
		doingAbil4 = true;
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/GiantHand"), characterPoint2.transform.position + new Vector3(0,90f,0), Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint2;
		//Do an animation here
		yield return new WaitForSeconds(1f);
		abilityActive = false;
		doingAbil4 = false;
		yield return null;

	}







	//BROGRE ABILITIES
	public IEnumerator Cleave(){
		doingAbil1 = true;
		for (int i = 0; i < 7; i++) {

			this.GetComponent<PlayerMovement> ().controller.Move (rotationPoint.transform.forward * 10f * Time.deltaTime);

			yield return new WaitForSeconds(0.01f);

		}

		createdThing = Instantiate (Resources.Load ("MeleeAttacks/CleaveHitbox"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;
		this.GetComponent<AudioSource> ().clip = brogreSlash;
		this.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds(0.5f);
		doingAbil1 = false;
		abilityActive = false;
		yield return null;
	}

	public IEnumerator Shield(){
		doingAbil3 = true;
		createdThing = Instantiate (Resources.Load ("SpecialAttacks/ShieldHitbox"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;
		this.GetComponent<AudioSource> ().clip = brogreShield;
		this.GetComponent<AudioSource> ().Play ();


		yield return new WaitForSeconds(2.5f);
		abilityActive = false;
		doingAbil3 = false;
		yield return null;
	}


	public IEnumerator ShieldPush(){
		doingAbil2 = true;
		Vector3 startPos = characterModel.transform.position;
		this.GetComponent<PlayerMovement> ().canMove = false;
		//this.GetComponent<PlayerMovement> ().canRotate = false;
		this.GetComponent<AudioSource> ().clip = brogreJump;
		this.GetComponent<AudioSource> ().Play ();
		for (int i = 0; i < 38; i++) {
			
			this.GetComponent<PlayerMovement> ().controller.Move (rotationPoint.transform.forward * 15f * Time.deltaTime);

			yield return new WaitForSeconds(0.01f);

		}
			
		//characterModel.transform.position = Vector3.Lerp (characterModel.transform.position, new Vector3 (characterModel.transform.position.x, characterModel.transform.position.y - 1 , characterModel.transform.position.z), 0.8f);
		createdThing = Instantiate (Resources.Load ("MeleeAttacks/ShieldShockwaveHitbox"), transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		this.GetComponent<AudioSource> ().clip = brogreSmash;
		this.GetComponent<AudioSource> ().Play ();
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.GetComponent<AttackAction> ().parentPoint = this.transform;

		yield return new WaitForSeconds(0.6f);
		//yield return new WaitForSeconds(0.1f);
		abilityActive = false;
		doingAbil2 = false;
		//characterModel.transform.position = startPos;
		this.GetComponent<PlayerMovement> ().canMove = true;
		//this.GetComponent<PlayerMovement> ().canRotate = true;
		yield return null;
	}




	public IEnumerator KegToss(){
		doingAbil4 = true;
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/KegTossProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-20f,20f),rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		//Do an animation here
		this.GetComponent<AudioSource> ().clip = brogreToss;
		this.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds(0.7f);
		abilityActive = false;
		doingAbil4 = false;
		yield return null;

	}

	public IEnumerator PotionToss(){
		doingAbil1 = true;
		yield return new WaitForSeconds(0.3f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/NormalPotion"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-20f,20f),rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		//Do an animation here
		this.GetComponent<AudioSource> ().clip = decayPotionThrow;
		this.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds(0.2f);
		abilityActive = false;
		doingAbil1 = false;
		yield return null;

	}

	public IEnumerator NapalmStrike(){
		doingAbil2 = true;
		yield return new WaitForSeconds(0.3f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/NapalmArrow"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y - 20f,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/NapalmArrow"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y - 10f ,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/NapalmArrow"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/NapalmArrow"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + 10f ,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/NapalmArrow"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + 20f,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		for (int i = 0; i < 16; i++) {
			if (this.GetComponent<PlayerMovement> ().lockedInPlace == false) {
				this.GetComponent<PlayerMovement> ().controller.Move (rotationPoint.transform.forward * -20f * Time.deltaTime);
			}
			yield return new WaitForSeconds(0.01f);
		}

		//Do an animation here

		yield return new WaitForSeconds(0.2f);
		abilityActive = false;
		doingAbil2 = false;
		yield return null;

	}



	public IEnumerator QuickSlash(){
		doingAbil2 = true;
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
		this.GetComponent<AudioSource> ().clip = tinyDash;
		this.GetComponent<AudioSource> ().Play ();
		for (int i = 0; i < 18; i++) {
			if (this.GetComponent<PlayerMovement> ().lockedInPlace == false) {
				this.GetComponent<PlayerMovement> ().controller.Move (rotationPoint.transform.forward * 30f * Time.deltaTime);
			}

			yield return new WaitForSeconds (0.01f);


		}



		yield return new WaitForSeconds(0.05f);
		this.GetComponent<BoxCollider> ().enabled = true;
		this.GetComponent<CharacterController> ().detectCollisions = true;
		this.GetComponent<Rigidbody> ().detectCollisions = true;
		this.GetComponent<Rigidbody> ().isKinematic = false;
		abilityActive = false;
		doingAbil2 = false;
		this.GetComponent<PlayerMovement> ().canRotate = true;
		this.GetComponent<PlayerMovement> ().canMove = true;
		yield return null;
	}


	public IEnumerator ComboAttack(){

		//ACTUALLY SOUNDWAVE NOW

		doingAbil1 = true;
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/Soundwave"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-10f,10f),rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.transform.localScale = transform.localScale - new Vector3 (-0.3f, -0.3f, -0.3f);
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/Soundwave"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-20f,20f),rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.transform.localScale = transform.localScale - new Vector3 (-0.2f, -0.2f, -0.2f);
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/Soundwave"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-20f,20f),rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/Soundwave"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-20f,20f),rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing.transform.localScale = transform.localScale - new Vector3 (-0.2f, -0.2f, -0.2f);
		yield return new WaitForSeconds(0.1f);
		if (isRaging) {
			doingAbil1 = true;
			yield return new WaitForSeconds(0.05f);
			createdThing = Instantiate (Resources.Load ("ProjectileAttacks/Soundwave"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-10f,10f),rotationPoint.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
			createdThing.transform.localScale = transform.localScale - new Vector3 (-0.3f, -0.3f, -0.3f);
			yield return new WaitForSeconds(0.05f);
			createdThing = Instantiate (Resources.Load ("ProjectileAttacks/Soundwave"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-20f,20f),rotationPoint.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
			createdThing.transform.localScale = transform.localScale - new Vector3 (-0.2f, -0.2f, -0.2f);
			yield return new WaitForSeconds(0.05f);
			createdThing = Instantiate (Resources.Load ("ProjectileAttacks/Soundwave"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-20f,20f),rotationPoint.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
			yield return new WaitForSeconds(0.05f);
			createdThing = Instantiate (Resources.Load ("ProjectileAttacks/Soundwave"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-20f,20f),rotationPoint.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
			createdThing.transform.localScale = transform.localScale - new Vector3 (-0.2f, -0.2f, -0.2f);
			yield return new WaitForSeconds(0.05f);
			createdThing = Instantiate (Resources.Load ("ProjectileAttacks/Soundwave"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-10f,10f),rotationPoint.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
			createdThing.transform.localScale = transform.localScale - new Vector3 (-0.3f, -0.3f, -0.3f);
			yield return new WaitForSeconds(0.05f);
			createdThing = Instantiate (Resources.Load ("ProjectileAttacks/Soundwave"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-20f,20f),rotationPoint.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
			createdThing.transform.localScale = transform.localScale - new Vector3 (-0.2f, -0.2f, -0.2f);
			yield return new WaitForSeconds(0.05f);
			createdThing = Instantiate (Resources.Load ("ProjectileAttacks/Soundwave"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-20f,20f),rotationPoint.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
			yield return new WaitForSeconds(0.05f);
			createdThing = Instantiate (Resources.Load ("ProjectileAttacks/Soundwave"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + Random.Range(-20f,20f),rotationPoint.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
			createdThing.transform.localScale = transform.localScale - new Vector3 (-0.2f, -0.2f, -0.2f);
			yield return new WaitForSeconds(0.05f);

		}

		doingAbil1 = false;
		abilityActive = false;
		yield return null;
	}

	public IEnumerator DashAttack(){
		doingAbil2 = true;
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
		this.GetComponent<AudioSource> ().clip = neredyDash;
		this.GetComponent<AudioSource> ().Play ();
		for (int i = 0; i < 15; i++) {
			if (this.GetComponent<PlayerMovement> ().lockedInPlace == false) {
				this.GetComponent<PlayerMovement> ().controller.Move (rotationPoint.transform.forward * 35f * Time.deltaTime);
			}

			yield return new WaitForSeconds (0.01f);

			
		}



		yield return new WaitForSeconds(0.05f);
		this.GetComponent<BoxCollider> ().enabled = true;
		this.GetComponent<CharacterController> ().detectCollisions = true;
		this.GetComponent<Rigidbody> ().detectCollisions = true;
		this.GetComponent<Rigidbody> ().isKinematic = false;
		abilityActive = false;
		doingAbil2 = false;
		this.GetComponent<PlayerMovement> ().canRotate = true;
		this.GetComponent<PlayerMovement> ().canMove = true;
		yield return null;
	}


	public IEnumerator Petrify(){
		doingAbil3 = true;
		yield return new WaitForSeconds (0.1f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/PetrifyProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds (0.7f);

		abilityActive = false;
		doingAbil3 = false;
		yield return null;
	}

	public IEnumerator DarkClaw(){
		doingAbil1 = true;
		yield return new WaitForSeconds (0.2f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/MissileProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds (0.3f);

		abilityActive = false;
		doingAbil1 = false;
		yield return null;
	}

	public IEnumerator KissOfDeath(){
		doingAbil3 = true;
		yield return new WaitForSeconds (0.4f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/KissProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds (0.7f);

		abilityActive = false;
		doingAbil3 = false;
		yield return null;
	}

	public IEnumerator LifeSteal(){
		doingAbil4 = true;
		yield return new WaitForSeconds (0.3f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/LifeSteal"), transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds (0.7f);

		abilityActive = false;
		doingAbil4 = false;
		yield return null;
	}

	public IEnumerator KnifeThrow(){
		doingAbil1 = true;
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
		doingAbil1 = false;
		abilityActive = false;
		yield return null;



	}

	public IEnumerator TrapSet(){
		doingAbil3 = true;
		yield return new WaitForSeconds(0.1f);
		createdThing = Instantiate (Resources.Load ("SpecialAttacks/ClawTrap"), transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		this.GetComponent<AudioSource> ().clip = tinyTrapPlace;
		this.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds(0.4f);
		doingAbil3 = false;
		abilityActive = false;
		yield return null;



	}

	public IEnumerator UndeadCompanions(){
		int ranNum;
		doingAbil3 = true;
		yield return new WaitForSeconds(0.1f);
		ranNum = Random.Range (0, 3);
		if (ranNum == 0) {
			createdThing = Instantiate (Resources.Load ("ProjectileAttacks/Leech"), characterPoint1.transform.position, Quaternion.Euler (rotationPoint.transform.eulerAngles.x, rotationPoint.transform.eulerAngles.y, rotationPoint.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			Physics.IgnoreCollision (this.GetComponent<Collider> (), createdThing.GetComponent<Collider> ());
			this.GetComponent<AudioSource> ().clip = decayLeechThrow;
			this.GetComponent<AudioSource> ().Play ();
		}

		if (ranNum == 1) {
			createdThing = Instantiate (Resources.Load ("ProjectileAttacks/Frog"), characterPoint1.transform.position, Quaternion.Euler (rotationPoint.transform.eulerAngles.x, rotationPoint.transform.eulerAngles.y, rotationPoint.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			Physics.IgnoreCollision (this.GetComponent<Collider> (), createdThing.GetComponent<Collider> ());
			this.GetComponent<AudioSource> ().clip = decayFrogThrow;
			this.GetComponent<AudioSource> ().Play ();
		}

		if (ranNum == 2) {
			createdThing = Instantiate (Resources.Load ("ProjectileAttacks/Crow"), characterPoint1.transform.position, Quaternion.Euler (rotationPoint.transform.eulerAngles.x, rotationPoint.transform.eulerAngles.y, rotationPoint.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			Physics.IgnoreCollision (this.GetComponent<Collider> (), createdThing.GetComponent<Collider> ());
			this.GetComponent<AudioSource> ().clip = decayCrowThrow;
			this.GetComponent<AudioSource> ().Play ();
		}

		yield return new WaitForSeconds(0.4f);
		//Do an animation here
		doingAbil3 = false;
		abilityActive = false;
		yield return null;



	}


	public IEnumerator PoisonCloud(){
		doingAbil2 = true;
		this.GetComponent<PlayerMovement> ().canMove = false;
		yield return new WaitForSeconds(0.30f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/SmokeCloud"), transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;

		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/SmokeCloud"), transform.position + (rotationPoint.transform.forward * 10f), Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		yield return new WaitForSeconds(0.05f);
		this.GetComponent<PlayerMovement> ().controller.Move (rotationPoint.transform.forward * 10f);
		this.GetComponent<AudioSource> ().clip = decaySmoke;
		this.GetComponent<AudioSource> ().Play ();
		//createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		//createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		//Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		//yield return new WaitForSeconds(0.1f);
		this.GetComponent<PlayerMovement> ().canMove = true;
		doingAbil2 = false;
		abilityActive = false;
		yield return null;



	}

	public IEnumerator BagOfTricks(){
		doingAbil4 = true;
		this.GetComponent<PlayerMovement> ().canMove = false;
		yield return new WaitForSeconds(0.1f);
		for (int i = 0; i < 10; i++) {
			this.GetComponent<AudioSource> ().clip = decayPotionThrow;
			this.GetComponent<AudioSource> ().Play ();
			createdThing = Instantiate (Resources.Load ("ProjectileAttacks/NormalPotion"), characterPoint1.transform.position, Quaternion.Euler (rotationPoint.transform.eulerAngles.x, rotationPoint.transform.eulerAngles.y + Random.Range (-15, 15), rotationPoint.transform.eulerAngles.z)) as GameObject;
			createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
			createdThing.GetComponent<PotionTossAction> ().dir = -1f;
			Physics.IgnoreCollision (this.GetComponent<Collider> (), createdThing.GetComponent<Collider> ());

			yield return new WaitForSeconds (0.2f);
		}


		//Do an animation here
		this.GetComponent<PlayerMovement> ().canMove = true;
		doingAbil4 = false;
		abilityActive = false;
		yield return null;



	}

	public IEnumerator KnifeSpin(){
		int p = 0;
		doingAbil4 = true;
		this.GetComponent<PlayerMovement> ().canRotate = false;
		yield return new WaitForSeconds(0.1f);
		this.GetComponent<AudioSource> ().clip = tinyUlt;
		this.GetComponent<AudioSource> ().Play ();
		createdThing = Instantiate (Resources.Load ("Particles/TinyUltPart"), transform) as GameObject;
		for (int i = 0; i < 54; i++) {
			//p++;
			if (Random.Range(0,2) == 0) {
				createdThing = Instantiate (Resources.Load ("ProjectileAttacks/KnifeProjectile"), characterPoint1.transform.position, Quaternion.Euler (rotationPoint.transform.eulerAngles.x, rotationPoint.transform.eulerAngles.y + Random.Range (-5, 5), rotationPoint.transform.eulerAngles.z)) as GameObject;
				createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
				createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
				Physics.IgnoreCollision (this.GetComponent<Collider> (), createdThing.GetComponent<Collider> ());
			}
			//if (p > 1) {
			//	p = 0;
			//}
			rotationPoint.transform.eulerAngles = new Vector3 (transform.rotation.eulerAngles.x, rotationPoint.transform.rotation.eulerAngles.y + 30f, transform.rotation.eulerAngles.z);

			yield return new WaitForSeconds (0.01f);
		}


		//Do an animation here
		this.GetComponent<PlayerMovement> ().canRotate = true;
		doingAbil4 = false;
		abilityActive = false;
		yield return null;



	}


	public IEnumerator PushPunch(){
		doingAbil2 = true;


		this.GetComponent<Rigidbody> ().detectCollisions = false;
		this.GetComponent<Rigidbody> ().isKinematic = true;
		this.GetComponent<CharacterController> ().detectCollisions = false;
		this.GetComponent<BoxCollider> ().enabled = false;

		yield return new WaitForSeconds (0.4f);

		createdThing = Instantiate (Resources.Load ("MeleeAttacks/PunchHitbox"), transform.position, Quaternion.Euler (rotationPoint.transform.eulerAngles.x, rotationPoint.transform.eulerAngles.y, rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision (this.GetComponent<Collider> (), createdThing.GetComponent<Collider> ());
		createdThing.GetComponent<AttackAction> ().parentPoint = characterPoint1;
		this.GetComponent<PlayerMovement> ().canMove = false;
		this.GetComponent<PlayerMovement> ().canRotate = false;
		for (int i = 0; i < 18; i++) {
			if (this.GetComponent<PlayerMovement> ().lockedInPlace == false) {
				this.GetComponent<PlayerMovement> ().controller.Move (rotationPoint.transform.forward * 35f * Time.deltaTime);
			}

			yield return new WaitForSeconds (0.01f);


		}



		yield return new WaitForSeconds(0.05f);
		this.GetComponent<BoxCollider> ().enabled = true;
		this.GetComponent<CharacterController> ().detectCollisions = true;
		this.GetComponent<Rigidbody> ().detectCollisions = true;
		this.GetComponent<Rigidbody> ().isKinematic = false;
		abilityActive = false;
		doingAbil2 = false;
		this.GetComponent<PlayerMovement> ().canRotate = true;
		this.GetComponent<PlayerMovement> ().canMove = true;
		yield return null;
	}
	public IEnumerator ClayWall(){
		doingAbil3 = true;

		yield return new WaitForSeconds(0.2f);
		createdThing = Instantiate (Resources.Load ("SpecialAttacks/ClayWallPush"), characterPoint2.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds(0.3f);

		doingAbil3 = false;
		abilityActive = false;
		yield return null;



	}

	public IEnumerator GroundSlam(){
		doingAbil4 = true;
		this.GetComponent<PlayerMovement> ().canMove = false;
		this.GetComponent<PlayerMovement> ().canRotate = false;
		yield return new WaitForSeconds(0.6f);
		createdThing = Instantiate (Resources.Load ("MeleeAttacks/GroundSlamHitbox"), transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		yield return new WaitForSeconds(0.4f);

		this.GetComponent<PlayerMovement> ().canMove = true;
		this.GetComponent<PlayerMovement> ().canRotate = true;
		doingAbil4 = false;
		abilityActive = false;
		yield return null;

	}




	public IEnumerator ClayShards(){
		doingAbil1 = true;
		yield return new WaitForSeconds(0.2f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/ClayShardProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + 30,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/ClayShardProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + 10,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/ClayShardProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y + 20,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());

		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/ClayShardProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y - 30,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/ClayShardProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y - 10,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/ClayShardProjectile"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y - 20,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());
		createdThing = Instantiate (Resources.Load ("Particles/GeoShoot"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;

		yield return new WaitForSeconds(0.3f);
		doingAbil1 = false;
		abilityActive = false;
		yield return null;



	}

	public IEnumerator BasicArrow(){
		doingAbil1 = true;
		yield return new WaitForSeconds(0.25f);
		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/BasicArrow"), characterPoint1.transform.position, Quaternion.Euler(rotationPoint.transform.eulerAngles.x,rotationPoint.transform.eulerAngles.y,rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision(this.GetComponent<Collider>(),createdThing.GetComponent<Collider>());

		yield return new WaitForSeconds(0.2f);
		doingAbil1 = false;
		abilityActive = false;
		yield return null;



	}

	public IEnumerator ArrowArsenal(){
		doingAbil3 = true;
		yield return new WaitForSeconds(0.4f);

		createdThing = Instantiate (Resources.Load ("ProjectileAttacks/GhostArrow"), characterPoint1.transform.position, Quaternion.Euler (rotationPoint.transform.eulerAngles.x, rotationPoint.transform.eulerAngles.y, rotationPoint.transform.eulerAngles.z)) as GameObject;
		createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
		createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
		Physics.IgnoreCollision (this.GetComponent<Collider> (), createdThing.GetComponent<Collider> ());

//		if (selectedArrow == 0) {
//			createdThing = Instantiate (Resources.Load ("ProjectileAttacks/BouncyArrow"), characterPoint1.transform.position, Quaternion.Euler (rotationPoint.transform.eulerAngles.x, rotationPoint.transform.eulerAngles.y, rotationPoint.transform.eulerAngles.z)) as GameObject;
//			createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
//			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
//			Physics.IgnoreCollision (this.GetComponent<Collider> (), createdThing.GetComponent<Collider> ());
//		}
//
//		if (selectedArrow == 1) {
//			createdThing = Instantiate (Resources.Load ("ProjectileAttacks/ScatterArrow"), characterPoint2.transform.position, Quaternion.Euler (rotationPoint.transform.eulerAngles.x, rotationPoint.transform.eulerAngles.y, rotationPoint.transform.eulerAngles.z)) as GameObject;
//			createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
//			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
//			Physics.IgnoreCollision (this.GetComponent<Collider> (), createdThing.GetComponent<Collider> ());
//		}
//
//		if (selectedArrow == 2) {
//			createdThing = Instantiate (Resources.Load ("ProjectileAttacks/StunArrow"), characterPoint1.transform.position, Quaternion.Euler (rotationPoint.transform.eulerAngles.x, rotationPoint.transform.eulerAngles.y, rotationPoint.transform.eulerAngles.z)) as GameObject;
//			createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
//			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
//			Physics.IgnoreCollision (this.GetComponent<Collider> (), createdThing.GetComponent<Collider> ());
//		}
//		if (selectedArrow == 3) {
//			createdThing = Instantiate (Resources.Load ("ProjectileAttacks/GhostArrow"), characterPoint1.transform.position, Quaternion.Euler (rotationPoint.transform.eulerAngles.x, rotationPoint.transform.eulerAngles.y, rotationPoint.transform.eulerAngles.z)) as GameObject;
//			createdThing.GetComponent<AttackAction> ().teamNum = teamNum;
//			createdThing.GetComponent<AttackAction> ().creator = this.gameObject;
//			Physics.IgnoreCollision (this.GetComponent<Collider> (), createdThing.GetComponent<Collider> ());
//		}
		//selectedArrow += 1;
		//if (selectedArrow >= 4) {
		//	selectedArrow = 0;
		//}
		yield return new WaitForSeconds(0.2f);
		//Do an animation here
		doingAbil3 = false;
		abilityActive = false;
		yield return null;



	}



	public IEnumerator BecomeEnraged(){
		doingAbil4 = true;
		this.GetComponent<AudioSource> ().clip = neredyEnrage;
		this.GetComponent<AudioSource> ().Play ();
		ability1.GetComponent<CooldownManager> ().CancelCooldown();
		ability2.GetComponent<CooldownManager> ().CancelCooldown();
		ability3.GetComponent<CooldownManager> ().CancelCooldown();
		StartCoroutine ("Raging");
		yield return new WaitForSeconds(0.6f);
		doingAbil4 = false;
		//StartCoroutine ("Raging");
		abilityActive = false;
		yield return null;
		rageEffectL.SetActive (true);
		rageEffectR.SetActive (true);


	}

	public IEnumerator Raging(){

		isRaging = true;
		yield return new WaitForSeconds(6f);
		isRaging = false;
		rageEffectL.SetActive (false);
		rageEffectR.SetActive (false);

	}





}
