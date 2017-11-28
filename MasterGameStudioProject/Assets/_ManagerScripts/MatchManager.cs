using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;
using InControl;

public class MatchManager : MonoBehaviour {

	public bool isSelectingCharacter = true;
	public bool isCountingDown = false;
	public bool isFighting = false;

	public float countdownTimer = 4f;
	public Text countdownText;

	public bool isRoundEnding = false;
	float roundOverTimer = 1.5f;

	public GameObject nextCharacterPanel;

	public GameObject characterSpawn;

	public Animator p1Panel;
	public Animator p2Panel;
	public Animator p3Panel;
	public Animator p4Panel;

	public GameObject p1AbilityPanel;
	public GameObject p2AbilityPanel;
	public GameObject p3AbilityPanel;
	public GameObject p4AbilityPanel;

	public Image player1Ch1;
	public Image player1Ch2;
	public Image player1Ch3;
	public Image player1Ch4;

	public Text player1Ch1Name;
	public Text player1Ch2Name;
	public Text player1Ch3Name;
	public Text player1Ch4Name;


	public Image player2Ch1;
	public Image player2Ch2;
	public Image player2Ch3;
	public Image player2Ch4;



	public Text player2Ch1Name;
	public Text player2Ch2Name;
	public Text player2Ch3Name;
	public Text player2Ch4Name;



	public Image player3Ch1;
	public Image player3Ch2;
	public Image player3Ch3;
	public Image player3Ch4;



	public Text player3Ch1Name;
	public Text player3Ch2Name;
	public Text player3Ch3Name;
	public Text player3Ch4Name;



	public Image player4Ch1;
	public Image player4Ch2;
	public Image player4Ch3;
	public Image player4Ch4;



	public Text player4Ch1Name;
	public Text player4Ch2Name;
	public Text player4Ch3Name;
	public Text player4Ch4Name;



	public InputDevice p1Joystick;
	public InputDevice p2Joystick;
	public InputDevice p3Joystick;
	public InputDevice p4Joystick;


	public bool p1A;
	public bool p1B;
	public bool p1X;
	public bool p1Y;

	public bool p2A;
	public bool p2B;
	public bool p2X;
	public bool p2Y;

	public bool p3A;
	public bool p3B;
	public bool p3X;
	public bool p3Y;

	public bool p4A;
	public bool p4B;
	public bool p4X;
	public bool p4Y;



	public List<Sprite> p1Portraits;
	public List<Sprite> p2Portraits;
	public List<Sprite> p3Portraits;
	public List<Sprite> p4Portraits;



	public Sprite portrait;
	public Sprite blankPortrait;

	public Sprite brogrePortrait;
	public Sprite skeletonPortrait;
	public Sprite tinyPortrait;
	public Sprite guyPortrait;
	public Sprite drDecayPortrait;
	public Sprite claymondPortrait;
	public Sprite succPortrait;
	public Sprite gorgonPortrait;
	public Sprite wynkPortrait;

	public Sprite brogreDead;
	public Sprite skeletonDead;
	public Sprite tinyDead;
	public Sprite guyDead;
	public Sprite drDecayDead;
	public Sprite claymondDead;
	public Sprite succDead;
	public Sprite gorgonDead;
	public Sprite wynkDead;



	public Transform spawn1;
	public Transform spawn2;
	public Transform spawn3;
	public Transform spawn4;

	public GameObject p1ActiveCharacter;
	public GameObject p2ActiveCharacter;
	public GameObject p3ActiveCharacter;
	public GameObject p4ActiveCharacter;

	public Image p1ActiveProfile;
	public Image p2ActiveProfile;
	public Image p3ActiveProfile;
	public Image p4ActiveProfile;

	public GameObject winnerPanel;
	public Text winnerText;

	//public int i = 0;
	//public int o = 0;

	public int player1CharactersLeft = 0;
	public int player2CharactersLeft = 0;
	public int player3CharactersLeft = 0;
	public int player4CharactersLeft = 0;

	public int team1CharactersLeft;
	public int team2CharactersLeft;

	public GameObject mainCam;

	public int howManyPlayers = 2;
	public int playersLeft;


	public int activeTeams = 2;



	void Awake(){

		//decayVictory = Resources.Load ("SFX/BrogreToss") as AudioClip;
		//guyVictory = Resources.Load ("SFX/BrogreSlash") as AudioClip;
		//geoVictory = Resources.Load ("SFX/BrogreShield") as AudioClip;
		//irisVictory = Resources.Load ("SFX/BrogreToss") as AudioClip;

		if (MasterGameManager.instance.ffa == true) {
			if (MasterGameManager.instance.p3Enabled && MasterGameManager.instance.p4Enabled) {
				activeTeams = 4;
			}
			if (MasterGameManager.instance.p3Enabled) {
				activeTeams = 3;
			}
			if (MasterGameManager.instance.p3Enabled == false && MasterGameManager.instance.p4Enabled == false) {
				activeTeams = 2;
			}


		}

		if (MasterGameManager.instance.ffa == false) {
			activeTeams = 2;
		}

		if (MasterGameManager.instance.p3Enabled) {
			howManyPlayers += 1;
		}
		if (MasterGameManager.instance.p4Enabled) {
			howManyPlayers += 1;
		}
		playersLeft = howManyPlayers;

	

		p1Portraits = new List<Sprite> ();
		p2Portraits = new List<Sprite> ();
		p3Portraits = new List<Sprite> ();
		p4Portraits = new List<Sprite> ();

		if (InputManager.Devices [0] != null) {
			p1Joystick = InputManager.Devices [0];
		}
		if (InputManager.Devices [1] != null) {
			p2Joystick = InputManager.Devices [1];
		}

		if (InputManager.Devices [2] != null) {
			p3Joystick = InputManager.Devices [2];
		}
		if (InputManager.Devices [3] != null) {
			p4Joystick = InputManager.Devices [3];
		}


		winnerPanel = GameObject.Find ("WinnerPanel");
		winnerText = GameObject.Find ("WinnerText").GetComponent<Text> ();

		brogrePortrait = Resources.Load<Sprite> ("CharacterPortraits/BrogreP");
		tinyPortrait = Resources.Load<Sprite> ("CharacterPortraits/TinyP");
		skeletonPortrait = Resources.Load<Sprite> ("CharacterPortraits/SkeletonP");
		claymondPortrait = Resources.Load<Sprite> ("CharacterPortraits/ClaymondP");
		drDecayPortrait = Resources.Load<Sprite> ("CharacterPortraits/DrDecayP");
		succPortrait = Resources.Load<Sprite> ("CharacterPortraits/SuccP");
		guyPortrait = Resources.Load<Sprite> ("CharacterPortraits/GuyP");
		gorgonPortrait = Resources.Load<Sprite> ("CharacterPortraits/GorgonP");
		blankPortrait = Resources.Load<Sprite> ("CharacterPortraits/Blank");
		//wynkPortrait = Resources.Load<Sprite> ("CharacterPortraits/WynkP");
		nextCharacterPanel = GameObject.Find ("NextCharacterPanel");

		brogreDead = Resources.Load<Sprite> ("CharacterPortraits/BrDead");
		tinyDead = Resources.Load<Sprite> ("CharacterPortraits/TiDead");
		skeletonDead = Resources.Load<Sprite> ("CharacterPortraits/GaDead");
		claymondDead = Resources.Load<Sprite> ("CharacterPortraits/GeDead");
		drDecayDead = Resources.Load<Sprite> ("CharacterPortraits/DeDead");
		succDead = Resources.Load<Sprite> ("CharacterPortraits/IrDead");
		guyDead = Resources.Load<Sprite> ("CharacterPortraits/GuDead");
		gorgonDead = Resources.Load<Sprite> ("CharacterPortraits/NeDead");

		countdownText = GameObject.Find ("CountdownText").GetComponent<Text> ();

		p1AbilityPanel = GameObject.Find ("P1Panel");
		p2AbilityPanel = GameObject.Find ("P2Panel");
		p3AbilityPanel = GameObject.Find ("P3Panel");
		p4AbilityPanel = GameObject.Find ("P4Panel");

		player1Ch1 = GameObject.Find ("P1TeamPanel").transform.Find ("Ch1Img").gameObject.GetComponent<Image> ();
		player1Ch2 = GameObject.Find ("P1TeamPanel").transform.Find ("Ch2Img").gameObject.GetComponent<Image> ();
		player1Ch3 = GameObject.Find ("P1TeamPanel").transform.Find ("Ch3Img").gameObject.GetComponent<Image> ();
		player1Ch4 = GameObject.Find ("P1TeamPanel").transform.Find ("Ch4Img").gameObject.GetComponent<Image> ();

		player1Ch1Name = GameObject.Find ("P1TeamPanel").transform.Find ("Ch1Img").Find("Ch1Name").gameObject.GetComponent<Text> ();
		player1Ch2Name = GameObject.Find ("P1TeamPanel").transform.Find ("Ch2Img").Find("Ch2Name").gameObject.GetComponent<Text> ();
		player1Ch3Name = GameObject.Find ("P1TeamPanel").transform.Find ("Ch3Img").Find("Ch3Name").gameObject.GetComponent<Text> ();
		player1Ch4Name = GameObject.Find ("P1TeamPanel").transform.Find ("Ch4Img").Find("Ch4Name").gameObject.GetComponent<Text> ();

		player2Ch1 = GameObject.Find ("P2TeamPanel").transform.Find ("Ch1Img").gameObject.GetComponent<Image> ();
		player2Ch2 = GameObject.Find ("P2TeamPanel").transform.Find ("Ch2Img").gameObject.GetComponent<Image> ();
		player2Ch3 = GameObject.Find ("P2TeamPanel").transform.Find ("Ch3Img").gameObject.GetComponent<Image> ();
		player2Ch4 = GameObject.Find ("P2TeamPanel").transform.Find ("Ch4Img").gameObject.GetComponent<Image> ();

		player2Ch1Name = GameObject.Find ("P2TeamPanel").transform.Find ("Ch1Img").Find("Ch1Name").gameObject.GetComponent<Text> ();
		player2Ch2Name = GameObject.Find ("P2TeamPanel").transform.Find ("Ch2Img").Find("Ch2Name").gameObject.GetComponent<Text> ();
		player2Ch3Name = GameObject.Find ("P2TeamPanel").transform.Find ("Ch3Img").Find("Ch3Name").gameObject.GetComponent<Text> ();
		player2Ch4Name = GameObject.Find ("P2TeamPanel").transform.Find ("Ch4Img").Find("Ch4Name").gameObject.GetComponent<Text> ();

		player3Ch1 = GameObject.Find ("P3TeamPanel").transform.Find ("Ch1Img").gameObject.GetComponent<Image> ();
		player3Ch2 = GameObject.Find ("P3TeamPanel").transform.Find ("Ch2Img").gameObject.GetComponent<Image> ();
		player3Ch3 = GameObject.Find ("P3TeamPanel").transform.Find ("Ch3Img").gameObject.GetComponent<Image> ();
		player3Ch4 = GameObject.Find ("P3TeamPanel").transform.Find ("Ch4Img").gameObject.GetComponent<Image> ();

		player3Ch1Name = GameObject.Find ("P3TeamPanel").transform.Find ("Ch1Img").Find("Ch1Name").gameObject.GetComponent<Text> ();
		player3Ch2Name = GameObject.Find ("P3TeamPanel").transform.Find ("Ch2Img").Find("Ch2Name").gameObject.GetComponent<Text> ();
		player3Ch3Name = GameObject.Find ("P3TeamPanel").transform.Find ("Ch3Img").Find("Ch3Name").gameObject.GetComponent<Text> ();
		player3Ch4Name = GameObject.Find ("P3TeamPanel").transform.Find ("Ch4Img").Find("Ch4Name").gameObject.GetComponent<Text> ();

		player4Ch1 = GameObject.Find ("P4TeamPanel").transform.Find ("Ch1Img").gameObject.GetComponent<Image> ();
		player4Ch2 = GameObject.Find ("P4TeamPanel").transform.Find ("Ch2Img").gameObject.GetComponent<Image> ();
		player4Ch3 = GameObject.Find ("P4TeamPanel").transform.Find ("Ch3Img").gameObject.GetComponent<Image> ();
		player4Ch4 = GameObject.Find ("P4TeamPanel").transform.Find ("Ch4Img").gameObject.GetComponent<Image> ();

		player4Ch1Name = GameObject.Find ("P4TeamPanel").transform.Find ("Ch1Img").Find("Ch1Name").gameObject.GetComponent<Text> ();
		player4Ch2Name = GameObject.Find ("P4TeamPanel").transform.Find ("Ch2Img").Find("Ch2Name").gameObject.GetComponent<Text> ();
		player4Ch3Name = GameObject.Find ("P4TeamPanel").transform.Find ("Ch3Img").Find("Ch3Name").gameObject.GetComponent<Text> ();
		player4Ch4Name = GameObject.Find ("P4TeamPanel").transform.Find ("Ch4Img").Find("Ch4Name").gameObject.GetComponent<Text> ();



		p1Panel = GameObject.Find ("P1TeamPanel").GetComponent<Animator> ();
		p2Panel = GameObject.Find ("P2TeamPanel").GetComponent<Animator> ();
		p3Panel = GameObject.Find ("P3TeamPanel").GetComponent<Animator> ();
		p4Panel = GameObject.Find ("P4TeamPanel").GetComponent<Animator> ();


		player1CharactersLeft = MasterGameManager.instance.teamSize;
		player2CharactersLeft = MasterGameManager.instance.teamSize;
		if (MasterGameManager.instance.p3Enabled) {
			player3CharactersLeft = MasterGameManager.instance.teamSize;

		} else {
			p3AbilityPanel.SetActive (false);
		}
		if (MasterGameManager.instance.p4Enabled) {
			player4CharactersLeft = MasterGameManager.instance.teamSize;

		} else {
			p4AbilityPanel.SetActive (false);
		}


		team1CharactersLeft = MasterGameManager.instance.teamSize * 2;
		team2CharactersLeft = MasterGameManager.instance.teamSize * 2;

		spawn1 = GameObject.Find ("Spawn1").transform;
		spawn2 = GameObject.Find ("Spawn2").transform;
		spawn3 = GameObject.Find ("Spawn3").transform;
		spawn4 = GameObject.Find ("Spawn4").transform;

		mainCam = GameObject.Find ("CameraHolder");


	}

	void Start () {
		DontDestroyOnLoad (this.gameObject);
		player1Ch1.sprite = blankPortrait;
		player1Ch2.sprite = blankPortrait;
		player1Ch3.sprite = blankPortrait;
		player1Ch4.sprite = blankPortrait;
		player2Ch1.sprite = blankPortrait;
		player2Ch2.sprite = blankPortrait;
		player2Ch3.sprite = blankPortrait;
		player2Ch4.sprite = blankPortrait;
		player3Ch1.sprite = blankPortrait;
		player3Ch2.sprite = blankPortrait;
		player3Ch3.sprite = blankPortrait;
		player3Ch4.sprite = blankPortrait;
		player4Ch1.sprite = blankPortrait;
		player4Ch2.sprite = blankPortrait;
		player4Ch3.sprite = blankPortrait;
		player4Ch4.sprite = blankPortrait;



		LoadCharacters ();
		winnerPanel.GetComponent<Animator> ().SetBool ("shouldMove", false);
		OpenPanels ();
		countdownText.enabled = false;



	}
	
	// Update is called once per frame
	void Update () {





		if (isRoundEnding) {
			roundOverTimer -= Time.deltaTime;
			if (roundOverTimer <= 0) {

				p1ActiveCharacter = null;
				p2ActiveCharacter = null;
				p3ActiveCharacter = null;
				p4ActiveCharacter = null;
				isFighting = false;
				GameObject[] allPlayersLeft;
				GameObject[] allAttacksLeft;
				GameObject[] allAbilitiesLeft;
				StartCoroutine ("VibrateController", p1Joystick);
				StartCoroutine ("VibrateController", p2Joystick);
				StartCoroutine ("VibrateController", p3Joystick);
				StartCoroutine ("VibrateController", p4Joystick);
				allPlayersLeft = GameObject.FindGameObjectsWithTag ("Player1");

				foreach (GameObject player in allPlayersLeft) {
					//mainCam.gameObject.GetComponent<DynamicCamera> ().RemoveAllPlayersFromView ();
					Destroy (player);
				}
				allPlayersLeft = GameObject.FindGameObjectsWithTag ("Player2");

				foreach (GameObject player in allPlayersLeft) {
					//mainCam.gameObject.GetComponent<DynamicCamera> ().RemoveAllPlayersFromView ();
					Destroy (player);
				}

				allPlayersLeft = GameObject.FindGameObjectsWithTag ("Player3");

				foreach (GameObject player in allPlayersLeft) {
					//mainCam.gameObject.GetComponent<DynamicCamera> ().RemoveAllPlayersFromView ();
					Destroy (player);
				}
				allPlayersLeft = GameObject.FindGameObjectsWithTag ("Player4");

				foreach (GameObject player in allPlayersLeft) {
					//mainCam.gameObject.GetComponent<DynamicCamera> ().RemoveAllPlayersFromView ();
					Destroy (player);
				}

				allAttacksLeft = GameObject.FindGameObjectsWithTag ("Projectile");

				foreach (GameObject attack in allAttacksLeft) {
					Destroy (attack);
				}

				allAbilitiesLeft = GameObject.FindGameObjectsWithTag ("Ability");
				foreach (GameObject ability in allAbilitiesLeft) {
					ability.GetComponent<CooldownManager> ().CancelCooldown ();
				}


				isRoundEnding = false;
				roundOverTimer = 3f;
				isSelectingCharacter = true;
				OpenPanels ();
			}

		}

		if (isCountingDown) {
			
			countdownTimer -= Time.deltaTime;
			countdownText.text = (countdownTimer - 1).ToString("#");
			if (countdownTimer < 1f) {
				countdownText.text = "Fight!";

			}

			if (countdownTimer <= 0) {
				isCountingDown = false;
				isFighting = true;
				countdownText.enabled = false;
				countdownTimer = 4f;
			}
		}


		if (isSelectingCharacter) {

			if (player1CharactersLeft > 0) {
				if (!player1Ch1.sprite.name.Contains("Dead")) {
					p1A = p1Joystick.Action1;
				}
				if (!player1Ch2.sprite.name.Contains("Dead")) {
					p1B = p1Joystick.Action2;
				}
				if (!player1Ch3.sprite.name.Contains("Dead")) {
					p1X = p1Joystick.Action3;
				}
				if (!player1Ch4.sprite.name.Contains("Dead")) {
					p1Y = p1Joystick.Action4;
				}
			}
			if (player2CharactersLeft > 0) {
				if (!player2Ch1.sprite.name.Contains("Dead")) {
					p2A = p2Joystick.Action1;
				}
				if (!player2Ch2.sprite.name.Contains("Dead")) {
					p2B = p2Joystick.Action2;
				}
				if (!player2Ch3.sprite.name.Contains("Dead")) {
					p2X = p2Joystick.Action3;
				}
				if (!player2Ch4.sprite.name.Contains("Dead")) {
					p2Y = p2Joystick.Action4;
				}
			}

			if (MasterGameManager.instance.p3Enabled && player3CharactersLeft > 0) {
				if (!player3Ch1.sprite.name.Contains("Dead")) {
					p3A = p3Joystick.Action1;
				}
				if (!player3Ch2.sprite.name.Contains("Dead")) {
					p3B = p3Joystick.Action2;
				}
				if (!player3Ch3.sprite.name.Contains("Dead")) {
					p3X = p3Joystick.Action3;
				}
				if (!player3Ch4.sprite.name.Contains("Dead")) {
					p3Y = p3Joystick.Action4;
				}
			}
			if (MasterGameManager.instance.p4Enabled && player4CharactersLeft > 0) {
				if (!player4Ch1.sprite.name.Contains("Dead")) {
					p4A = p4Joystick.Action1;
				}
				if (!player4Ch2.sprite.name.Contains("Dead")) {
					p4B = p4Joystick.Action2;
				}
				if (!player4Ch3.sprite.name.Contains("Dead")) {
					p4X = p4Joystick.Action3;
				}
				if (!player4Ch4.sprite.name.Contains("Dead")) {
					p4Y = p4Joystick.Action4;
				}
			}
				
			if (p1ActiveCharacter == null && player1CharactersLeft > 0) {
				if (p1A && player1Ch1.enabled) {
					p1ActiveCharacter = MasterGameManager.instance.player1Characters [0];
					p1ActiveProfile = player1Ch1;
					StartCoroutine ("VibrateController", p1Joystick);
				}
				if (p1B && player1Ch2.enabled) {
					p1ActiveCharacter = MasterGameManager.instance.player1Characters [1];
					p1ActiveProfile = player1Ch2;
					StartCoroutine ("VibrateController", p1Joystick);
				}
				if (p1X && player1Ch3.enabled) {
					p1ActiveCharacter = MasterGameManager.instance.player1Characters [2];
					p1ActiveProfile = player1Ch3;
					StartCoroutine ("VibrateController", p1Joystick);
				}
				if (p1Y && player1Ch4.enabled) {
					p1ActiveCharacter = MasterGameManager.instance.player1Characters [3];
					p1ActiveProfile = player1Ch4;
					StartCoroutine ("VibrateController", p1Joystick);
				}

			}

			if (p2ActiveCharacter == null && player2CharactersLeft > 0) {
				
				if (p2A && player2Ch1.enabled) {
					p2ActiveCharacter = MasterGameManager.instance.player2Characters [0];
					p2ActiveProfile = player2Ch1;
					StartCoroutine ("VibrateController", p2Joystick);
				}
				if (p2B && player2Ch2.enabled) {
					p2ActiveCharacter = MasterGameManager.instance.player2Characters [1];
					p2ActiveProfile = player2Ch2;
					StartCoroutine ("VibrateController", p2Joystick);
				}
				if (p2X && player2Ch3.enabled) {
					p2ActiveCharacter = MasterGameManager.instance.player2Characters [2];
					p2ActiveProfile = player2Ch3;
					StartCoroutine ("VibrateController", p2Joystick);
				}
				if (p2Y && player2Ch4.enabled) {
					p2ActiveCharacter = MasterGameManager.instance.player2Characters [3];
					p2ActiveProfile = player2Ch4;
					StartCoroutine ("VibrateController", p2Joystick);
				}
		
			}
			if (p3ActiveCharacter == null && player3CharactersLeft > 0 && MasterGameManager.instance.p3Enabled) {

				if (p3A && player3Ch1.enabled) {
					p3ActiveCharacter = MasterGameManager.instance.player3Characters [0];
					p3ActiveProfile = player3Ch1;
					StartCoroutine ("VibrateController", p3Joystick);
				}
				if (p3B && player3Ch2.enabled) {
					p3ActiveCharacter = MasterGameManager.instance.player3Characters [1];
					p3ActiveProfile = player3Ch2;
					StartCoroutine ("VibrateController", p3Joystick);
				}
				if (p3X && player3Ch3.enabled) {
					p3ActiveCharacter = MasterGameManager.instance.player3Characters [2];
					p3ActiveProfile = player3Ch3;
					StartCoroutine ("VibrateController", p3Joystick);
				}
				if (p3Y && player3Ch4.enabled) {
					p3ActiveCharacter = MasterGameManager.instance.player3Characters [3];
					p3ActiveProfile = player3Ch4;
					StartCoroutine ("VibrateController", p3Joystick);
				}

			}

			if (p4ActiveCharacter == null && player4CharactersLeft > 0 && MasterGameManager.instance.p4Enabled) {

				if (p4A && player4Ch1.enabled) {
					p4ActiveCharacter = MasterGameManager.instance.player4Characters [0];
					p4ActiveProfile = player4Ch1;
					StartCoroutine ("VibrateController", p4Joystick);
				}
				if (p4B && player4Ch2.enabled) {
					p4ActiveCharacter = MasterGameManager.instance.player4Characters [1];
					p4ActiveProfile = player4Ch2;
					StartCoroutine ("VibrateController", p4Joystick);
				}
				if (p4X && player4Ch3.enabled) {
					p4ActiveCharacter = MasterGameManager.instance.player4Characters [2];
					p4ActiveProfile = player4Ch3;
					StartCoroutine ("VibrateController", p4Joystick);
				}
				if (p4Y && player4Ch4.enabled) {
					p4ActiveCharacter = MasterGameManager.instance.player4Characters [3];
					p4ActiveProfile = player4Ch4;
					StartCoroutine ("VibrateController", p4Joystick);
				}

			}

		

			if (p1ActiveCharacter != null || player1CharactersLeft == 0){
				if (p2ActiveCharacter != null || player2CharactersLeft == 0) {
					if (MasterGameManager.instance.p3Enabled == false || p3ActiveCharacter != null || player3CharactersLeft == 0){
						if (MasterGameManager.instance.p4Enabled == false || p4ActiveCharacter != null || player4CharactersLeft == 0) {
							p1A = false;
							p1B = false;
							p1X = false;
							p1Y = false;

							p2A = false;
							p2B = false;
							p2X = false;
							p2Y = false;

							p3A = false;
							p3B = false;
							p3X = false;
							p3Y = false;

							p4A = false;
							p4B = false;
							p4X = false;
							p4Y = false;




							isSelectingCharacter = false;
							isCountingDown = true;
							countdownText.enabled = true;
							ClosePanels ();
							SpawnCharacters ();
						}
					}
				}
			}

		}
//		if (Input.GetKeyDown (KeyCode.G)) {
//			OpenPanels ();
//		}
//		if (Input.GetKeyDown (KeyCode.H)) {
//			ClosePanels ();
//		}
	}
	public void OpenPanels(){
		p1Panel.SetBool ("isOpen", true);
		p2Panel.SetBool ("isOpen", true);
		if (MasterGameManager.instance.p3Enabled) {
			p3Panel.SetBool ("isOpen", true);
		}
		if (MasterGameManager.instance.p4Enabled) {
			p4Panel.SetBool ("isOpen", true);
		}




	}
	public void ClosePanels(){
		p1Panel.SetBool ("isOpen", false);
		p2Panel.SetBool ("isOpen", false);
		if (MasterGameManager.instance.p3Enabled) {
			p3Panel.SetBool ("isOpen", false);
		}
		if (MasterGameManager.instance.p4Enabled) {
			p4Panel.SetBool ("isOpen", false);
		}
	}

	public void LoadCharacters(){




		for (int i = 0; i < MasterGameManager.instance.player1Characters.Count; i++) {
			//if (character != null) {
			if (MasterGameManager.instance.player1Characters[i].name == "Brogre") {
				p1Portraits.Add (brogrePortrait);
			}
			if (MasterGameManager.instance.player1Characters[i].name == "ToeTip") {
				p1Portraits.Add (skeletonPortrait);
			}
			if (MasterGameManager.instance.player1Characters[i].name == "Tiny") {
				p1Portraits.Add (tinyPortrait);
			}
			if (MasterGameManager.instance.player1Characters[i].name == "Neredy") {
				p1Portraits.Add (gorgonPortrait);
			}
			if (MasterGameManager.instance.player1Characters[i].name == "Claymond") {
				p1Portraits.Add (claymondPortrait);
			}
			if (MasterGameManager.instance.player1Characters[i].name == "Guy") {
				p1Portraits.Add (guyPortrait);
			}
			if (MasterGameManager.instance.player1Characters[i].name == "DrDecay") {
				p1Portraits.Add (drDecayPortrait);
			}
			if (MasterGameManager.instance.player1Characters[i].name == "Iris") {
				p1Portraits.Add (succPortrait);
			}
			if (MasterGameManager.instance.player1Characters[i].name == "Wynk") {
				p1Portraits.Add (wynkPortrait);
			}
			if (MasterGameManager.instance.player1Characters[i].name == "Empty") {
				p1Portraits.Add (blankPortrait);
			}

			//}
		}




		//Debug.Log (p1Portraits [3].name);
		player1Ch1.sprite = p1Portraits [0];
		player1Ch2.sprite = p1Portraits [1];
		player1Ch3.sprite = p1Portraits [2];
		player1Ch4.sprite = p1Portraits [3];

		player1Ch1Name.text = MasterGameManager.instance.player1Characters [0].name;
		player1Ch2Name.text = MasterGameManager.instance.player1Characters [1].name;
		player1Ch3Name.text = MasterGameManager.instance.player1Characters [2].name;
		player1Ch4Name.text = MasterGameManager.instance.player1Characters [3].name;


		if (player1Ch2.sprite == blankPortrait) {
			player1Ch2.enabled = false;
			player1Ch2Name.enabled = false;
			player1Ch2.gameObject.transform.Find ("ButtonImg").GetComponent<Image> ().enabled = false;
		}
		if (player1Ch3.sprite == blankPortrait) {
			player1Ch3.enabled = false;
			player1Ch3Name.enabled = false;
			player1Ch3.gameObject.transform.Find ("ButtonImg").GetComponent<Image> ().enabled = false;
		}

		if (player1Ch4.sprite == blankPortrait) {
			player1Ch4.enabled = false;
			player1Ch4Name.enabled = false;
			player1Ch4.gameObject.transform.Find ("ButtonImg").GetComponent<Image> ().enabled = false;
		}


		for (int o = 0;o < MasterGameManager.instance.player2Characters.Count; o++) {
			//if (character2 != null) {
			if (MasterGameManager.instance.player2Characters[o].name == "Brogre") {
				p2Portraits.Add (brogrePortrait);
			}
			if (MasterGameManager.instance.player2Characters[o].name == "ToeTip") {
				p2Portraits.Add (skeletonPortrait);
			}
			if (MasterGameManager.instance.player2Characters[o].name == "Tiny") {
				p2Portraits.Add (tinyPortrait);
			}
			if (MasterGameManager.instance.player2Characters[o].name == "Neredy") {
				p2Portraits.Add (gorgonPortrait);
			}
			if (MasterGameManager.instance.player2Characters[o].name == "Claymond") {
				p2Portraits.Add (claymondPortrait);
			}
			if (MasterGameManager.instance.player2Characters[o].name == "Guy") {
				p2Portraits.Add (guyPortrait);
			}
			if (MasterGameManager.instance.player2Characters[o].name == "DrDecay") {
				p2Portraits.Add (drDecayPortrait);
			}
			if (MasterGameManager.instance.player2Characters[o].name == "Iris") {
				p2Portraits.Add (succPortrait);
			}
			if (MasterGameManager.instance.player2Characters[o].name == "Wynk") {
				p2Portraits.Add (wynkPortrait);
			}
			if (MasterGameManager.instance.player2Characters[o].name == "Empty") {
				p2Portraits.Add (blankPortrait);
			}
			//}
		}


		player2Ch1.sprite = p2Portraits [0];
		player2Ch2.sprite = p2Portraits [1];
		player2Ch3.sprite = p2Portraits [2];
		player2Ch4.sprite = p2Portraits [3];

		player2Ch1Name.text = MasterGameManager.instance.player2Characters [0].name;
		player2Ch2Name.text = MasterGameManager.instance.player2Characters [1].name;
		player2Ch3Name.text = MasterGameManager.instance.player2Characters [2].name;
		player2Ch4Name.text = MasterGameManager.instance.player2Characters [3].name;



		if (player2Ch2.sprite == blankPortrait) {
			player2Ch2.enabled = false;
			player2Ch2Name.enabled = false;
			player2Ch2.gameObject.transform.Find ("ButtonImg").GetComponent<Image> ().enabled = false;
		}
		if (player2Ch3.sprite == blankPortrait) {
			player2Ch3.enabled = false;
			player2Ch3Name.enabled = false;
			player2Ch3.gameObject.transform.Find ("ButtonImg").GetComponent<Image> ().enabled = false;
		}

		if (player2Ch4.sprite == blankPortrait) {
			player2Ch4.enabled = false;
			player2Ch4Name.enabled = false;
			player2Ch4.gameObject.transform.Find ("ButtonImg").GetComponent<Image> ().enabled = false;
		}
		if (MasterGameManager.instance.p3Enabled) {
			for (int z = 0; z < MasterGameManager.instance.player3Characters.Count; z++) {
				//if (character2 != null) z
				if (MasterGameManager.instance.player3Characters [z].name == "Brogre") {
					p3Portraits.Add (brogrePortrait);
				}
				if (MasterGameManager.instance.player3Characters [z].name == "ToeTip") {
					p3Portraits.Add (skeletonPortrait);
				}
				if (MasterGameManager.instance.player3Characters [z].name == "Tiny") {
					p3Portraits.Add (tinyPortrait);
				}
				if (MasterGameManager.instance.player3Characters [z].name == "Neredy") {
					p3Portraits.Add (gorgonPortrait);
				}
				if (MasterGameManager.instance.player3Characters [z].name == "Empty") {
					p3Portraits.Add (blankPortrait);
				}
				if (MasterGameManager.instance.player3Characters[z].name == "Claymond") {
					p3Portraits.Add (claymondPortrait);
				}
				if (MasterGameManager.instance.player3Characters[z].name == "Guy") {
					p3Portraits.Add (guyPortrait);
				}
				if (MasterGameManager.instance.player3Characters[z].name == "DrDecay") {
					p3Portraits.Add (drDecayPortrait);
				}
				if (MasterGameManager.instance.player3Characters[z].name == "Iris") {
					p3Portraits.Add (succPortrait);
				}
				if (MasterGameManager.instance.player3Characters[z].name == "Wynk") {
					p3Portraits.Add (wynkPortrait);
				}
				//}
			}


			player3Ch1.sprite = p3Portraits [0];
			player3Ch2.sprite = p3Portraits [1];
			player3Ch3.sprite = p3Portraits [2];
			player3Ch4.sprite = p3Portraits [3];

			player3Ch1Name.text = MasterGameManager.instance.player3Characters [0].name;
			player3Ch2Name.text = MasterGameManager.instance.player3Characters [1].name;
			player3Ch3Name.text = MasterGameManager.instance.player3Characters [2].name;
			player3Ch4Name.text = MasterGameManager.instance.player3Characters [3].name;



			if (player3Ch2.sprite == blankPortrait) {
				player3Ch2.enabled = false;
				player3Ch2Name.enabled = false;
				player3Ch2.gameObject.transform.Find ("ButtonImg").GetComponent<Image> ().enabled = false;
			}
			if (player3Ch3.sprite == blankPortrait) {
				player3Ch3.enabled = false;
				player3Ch3Name.enabled = false;
				player3Ch3.gameObject.transform.Find ("ButtonImg").GetComponent<Image> ().enabled = false;
			}

			if (player3Ch4.sprite == blankPortrait) {
				player3Ch4.enabled = false;
				player3Ch4Name.enabled = false;
				player3Ch4.gameObject.transform.Find ("ButtonImg").GetComponent<Image> ().enabled = false;
			}
		}
		if (MasterGameManager.instance.p4Enabled) {
			for (int y = 0; y < MasterGameManager.instance.player4Characters.Count; y++) {
				//if (character2 != null) z
				if (MasterGameManager.instance.player4Characters [y].name == "Brogre") {
					p4Portraits.Add (brogrePortrait);
				}
				if (MasterGameManager.instance.player4Characters [y].name == "ToeTip") {
					p4Portraits.Add (skeletonPortrait);
				}
				if (MasterGameManager.instance.player4Characters [y].name == "Tiny") {
					p4Portraits.Add (tinyPortrait);
				}
				if (MasterGameManager.instance.player4Characters [y].name == "Neredy") {
					p4Portraits.Add (gorgonPortrait);
				}
				if (MasterGameManager.instance.player4Characters [y].name == "Empty") {
					p4Portraits.Add (blankPortrait);
				}
				if (MasterGameManager.instance.player4Characters[y].name == "Claymond") {
					p4Portraits.Add (claymondPortrait);
				}
				if (MasterGameManager.instance.player4Characters[y].name == "Guy") {
					p4Portraits.Add (guyPortrait);
				}
				if (MasterGameManager.instance.player4Characters[y].name == "DrDecay") {
					p4Portraits.Add (drDecayPortrait);
				}
				if (MasterGameManager.instance.player4Characters[y].name == "Iris") {
					p4Portraits.Add (succPortrait);
				}
				if (MasterGameManager.instance.player4Characters[y].name == "Wynk") {
					p4Portraits.Add (wynkPortrait);
				}
				//}
			}


			player4Ch1.sprite = p4Portraits [0];
			player4Ch2.sprite = p4Portraits [1];
			player4Ch3.sprite = p4Portraits [2];
			player4Ch4.sprite = p4Portraits [3];

			player4Ch1Name.text = MasterGameManager.instance.player4Characters [0].name;
			player4Ch2Name.text = MasterGameManager.instance.player4Characters [1].name;
			player4Ch3Name.text = MasterGameManager.instance.player4Characters [2].name;
			player4Ch4Name.text = MasterGameManager.instance.player4Characters [3].name;



			if (player4Ch2.sprite == blankPortrait) {
				player4Ch2.enabled = false;
				player4Ch2Name.enabled = false;
				player4Ch2.gameObject.transform.Find ("ButtonImg").GetComponent<Image> ().enabled = false;
			}
			if (player4Ch3.sprite == blankPortrait) {
				player4Ch3.enabled = false;
				player4Ch3Name.enabled = false;
				player4Ch3.gameObject.transform.Find ("ButtonImg").GetComponent<Image> ().enabled = false;
			}

			if (player4Ch4.sprite == blankPortrait) {
				player4Ch4.enabled = false;
				player4Ch4Name.enabled = false;
				player4Ch4.gameObject.transform.Find ("ButtonImg").GetComponent<Image> ().enabled = false;
			}

		}









	
	}


	public void SpawnCharacters(){
		if (player1CharactersLeft > 0) {
			characterSpawn = Instantiate (p1ActiveCharacter, spawn1.transform.position, spawn1.transform.rotation) as GameObject;
			characterSpawn.tag = "Player1";
			//mainCam.GetComponent<DynamicCamera> ().allPlayers.Add (characterSpawn);
			characterSpawn.GetComponent<PlayerState> ().playerNum = 1;
			characterSpawn.GetComponent<PlayerState> ().teamNum = 1;
			mainCam.gameObject.GetComponent<DynamicCamera> ().AddPlayerToView (characterSpawn);
		}
		if (player2CharactersLeft > 0) {
			characterSpawn = Instantiate (p2ActiveCharacter, spawn2.transform.position, spawn2.transform.rotation) as GameObject;
			characterSpawn.tag = "Player2";
			//mainCam.GetComponent<DynamicCamera> ().allPlayers.Add (characterSpawn);
			characterSpawn.GetComponent<PlayerState> ().playerNum = 2;

			if (MasterGameManager.instance.ffa) {
				characterSpawn.GetComponent<PlayerState> ().teamNum = 2;
			} else {
				characterSpawn.GetComponent<PlayerState> ().teamNum = 1;
			}
			mainCam.gameObject.GetComponent<DynamicCamera> ().AddPlayerToView (characterSpawn);
		}
		if (player3CharactersLeft > 0 && MasterGameManager.instance.p3Enabled) {
			characterSpawn = Instantiate (p3ActiveCharacter, spawn3.transform.position, spawn3.transform.rotation) as GameObject;
			characterSpawn.tag = "Player3";
			//mainCam.GetComponent<DynamicCamera> ().allPlayers.Add (characterSpawn);

			if (MasterGameManager.instance.ffa) {
				characterSpawn.GetComponent<PlayerState> ().teamNum = 3;
			} else {
				characterSpawn.GetComponent<PlayerState> ().teamNum = 2;
			}
			characterSpawn.GetComponent<PlayerState> ().playerNum = 3;
			mainCam.gameObject.GetComponent<DynamicCamera> ().AddPlayerToView (characterSpawn);
		}
		if (player4CharactersLeft > 0 && MasterGameManager.instance.p4Enabled) {
			characterSpawn = Instantiate (p4ActiveCharacter, spawn4.transform.position, spawn4.transform.rotation) as GameObject;
			characterSpawn.tag = "Player4";

			if (MasterGameManager.instance.ffa) {
				characterSpawn.GetComponent<PlayerState> ().teamNum = 4;
			} else {
				characterSpawn.GetComponent<PlayerState> ().teamNum = 2;
			}
			//mainCam.GetComponent<DynamicCamera> ().allPlayers.Add (characterSpawn);
			characterSpawn.GetComponent<PlayerState> ().playerNum = 4;
			mainCam.gameObject.GetComponent<DynamicCamera> ().AddPlayerToView (characterSpawn);
		}
	}

	public void SubtractCharacter(int loser){



		playersLeft -= 1;

			if (loser == 1) {
			GoDead (p1ActiveProfile);
				player1CharactersLeft -= 1;
				if (player1CharactersLeft <= 0) {
				}
			}

			if (loser == 2) {
			GoDead (p2ActiveProfile);
				player2CharactersLeft -= 1;

			}

			if (loser == 3) {
			GoDead (p3ActiveProfile);
				//p3ActiveProfile.color = Color.black;
				player3CharactersLeft -= 1;

			}

			if (loser == 4) {
			GoDead (p4ActiveProfile);
				//p4ActiveProfile.color = Color.black;
				player4CharactersLeft -= 1;

			}

		if (MasterGameManager.instance.ffa == false) {

			if (loser == 1) {
				team1CharactersLeft -= 1;
				if (p2ActiveProfile.name.Contains("Dead")) {
					RoundOver ();
				}
			}
			if (loser == 2) {
				team1CharactersLeft -= 1;
				if (p1ActiveProfile.name.Contains("Dead")) {
					RoundOver ();
				}
			}
			if (loser == 3) {
				team2CharactersLeft -= 1;
				if (p4ActiveProfile.name.Contains("Dead")) {
					RoundOver ();
				}
			}
			if (loser == 4) {
				team2CharactersLeft -= 1;
				if (p3ActiveProfile.name.Contains("Dead")) {
					RoundOver ();
				}
			}

		}

		if (MasterGameManager.instance.ffa) {	
			//Find the winner and add the surviving players back
			if (playersLeft == 1) {
				RoundOver ();

			}
		}

		}

	public void RoundOver(){
		mainCam.gameObject.GetComponent<DynamicCamera> ().RemoveAllPlayersFromView ();
		playersLeft = 0;
		if (player1CharactersLeft > 0) {
			playersLeft += 1;
		}
		if (player2CharactersLeft > 0) {
			playersLeft += 1;
		}
		if (player3CharactersLeft > 0) {
			playersLeft += 1;
		}
		if (player4CharactersLeft > 0) {
			playersLeft += 1;
		}


		GameObject[] allPlayersLeft;
		allPlayersLeft = GameObject.FindGameObjectsWithTag ("Player1");

		foreach (GameObject player in allPlayersLeft) {

			player.GetComponent<PlayerMovement> ().matchOver = true;
			player.GetComponent<PlayerMovement> ().canMove = false;
			player.GetComponent<PlayerMovement> ().canRotate = false;
			player.GetComponent<PlayerAbilities> ().StopAllCoroutines ();
			//player.GetComponent<PlayerAbilities> ().abilityActive = true;
		}
		allPlayersLeft = GameObject.FindGameObjectsWithTag ("Player2");


		foreach (GameObject player in allPlayersLeft) {

			player.GetComponent<PlayerMovement> ().matchOver = true;
			player.GetComponent<PlayerMovement> ().canMove = false;
			player.GetComponent<PlayerMovement> ().canRotate = false;
			player.GetComponent<PlayerAbilities> ().StopAllCoroutines ();
			//player.GetComponent<PlayerAbilities> ().abilityActive = true;
		}

		allPlayersLeft = GameObject.FindGameObjectsWithTag ("Player3");

		foreach (GameObject player in allPlayersLeft) {

			player.GetComponent<PlayerMovement> ().matchOver = true;
			player.GetComponent<PlayerMovement> ().canMove = false;
			player.GetComponent<PlayerMovement> ().canRotate = false;
			player.GetComponent<PlayerAbilities> ().StopAllCoroutines ();
			//player.GetComponent<PlayerAbilities> ().abilityActive = true;
		}

		allPlayersLeft = GameObject.FindGameObjectsWithTag ("Player4");

		foreach (GameObject player in allPlayersLeft) {

			player.GetComponent<PlayerMovement> ().matchOver = true;
			player.GetComponent<PlayerMovement> ().canMove = false;
			player.GetComponent<PlayerMovement> ().canRotate = false;
			player.GetComponent<PlayerAbilities> ().StopAllCoroutines ();
			//player.GetComponent<PlayerAbilities> ().abilityActive = true;
		}

	
		allPlayersLeft = GameObject.FindGameObjectsWithTag ("SoloCup");

		foreach (GameObject player in allPlayersLeft) {
			Destroy (player);
			//player.GetComponent<PlayerAbilities> ().abilityActive = true;
		}

		allPlayersLeft = GameObject.FindGameObjectsWithTag ("Projectile");

		foreach (GameObject player in allPlayersLeft) {
			Destroy (player);
			//player.GetComponent<PlayerAbilities> ().abilityActive = true;
		}

		Camera.main.GetComponent<Grayscale> ().enabled = false;



		if (playersLeft == 1 || team1CharactersLeft == 0 || team2CharactersLeft == 0) {
			winnerPanel.GetComponent<Animator> ().SetBool ("shouldMove", true);
			if (MasterGameManager.instance.ffa == true) {
				if (player1CharactersLeft > 0) {
					winnerText.text = "Player 1 Wins";
				}
				if (player2CharactersLeft > 0) {
					winnerText.text = "Player 2 Wins";
				}
				if (player3CharactersLeft > 0) {
					winnerText.text = "Player 3 Wins";
				}
				if (player4CharactersLeft > 0) {
					winnerText.text = "Player 4 Wins";
				}
			}
			if (MasterGameManager.instance.ffa == false) {
				if (team1CharactersLeft <= 0) {
					winnerText.text = "Team 2 Wins";
				}

				if (team2CharactersLeft <= 0) {
					winnerText.text = "Team 1 Wins";
				}
		
			}


			MasterGameManager.instance.player1Characters.Clear ();
			MasterGameManager.instance.player2Characters.Clear ();
			MasterGameManager.instance.player3Characters.Clear ();
			MasterGameManager.instance.player4Characters.Clear ();
			StartCoroutine ("MatchComplete");
		} else {
			isRoundEnding = true;

		}
	}


	IEnumerator VibrateController(InputDevice whichDevice){
		whichDevice.Vibrate (0.3f);
		yield return new WaitForSeconds(0.3f);
		whichDevice.StopVibration ();
	}

	public void GoDead(Image profile){
		if (profile.sprite.name == "BrogreP") {
			profile.sprite = brogreDead;
		}
		if (profile.sprite.name == "SkeletonP") {
			profile.sprite = skeletonDead;
		}
		if (profile.sprite.name == "SuccP") {
			profile.sprite = succDead;
		}
		if (profile.sprite.name == "GorgonP") {
			profile.sprite = gorgonDead;
		}
		if (profile.sprite.name == "TinyP") {
			profile.sprite = tinyDead;
		}
		if (profile.sprite.name == "GuyP") {
			profile.sprite = guyDead;
		}
		if (profile.sprite.name == "DrDecayP") {
			profile.sprite = drDecayDead;
		}
		if (profile.sprite.name == "ClaymondP") {
			profile.sprite = claymondDead;
		}
	}
	IEnumerator MatchComplete(){
		yield return new WaitForSeconds(4f);
		SceneManager.LoadScene ("Menu");
		Destroy (MasterGameManager.instance);
		Destroy (this.gameObject);
	}
		
}
