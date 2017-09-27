using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using InControl;

public class MatchManager : MonoBehaviour {

	public bool isSelectingCharacter = true;
	public bool isCountingDown = false;
	public bool isFighting = false;

	public float countdownTimer = 4f;
	public Text countdownText;

	public GameObject nextCharacterPanel;

	public GameObject characterSpawn;

	public Animator p1Panel;
	public Animator p2Panel;

	public Image team1Ch1;
	public Image team1Ch2;
	public Image team1Ch3;
	public Image team1Ch4;

	public Text team1Ch1Name;
	public Text team1Ch2Name;
	public Text team1Ch3Name;
	public Text team1Ch4Name;


	public Image team2Ch1;
	public Image team2Ch2;
	public Image team2Ch3;
	public Image team2Ch4;



	public Text team2Ch1Name;
	public Text team2Ch2Name;
	public Text team2Ch3Name;
	public Text team2Ch4Name;

	public InputDevice p1Joystick;
	public InputDevice p2Joystick;

	public bool p1A;
	public bool p1B;
	public bool p1X;
	public bool p1Y;

	public bool p2A;
	public bool p2B;
	public bool p2X;
	public bool p2Y;

	public List<Sprite> p1Portraits;
	public List<Sprite> p2Portraits;

	public Sprite brogrePortrait;
	public Sprite skeletonPortrait;


	public Sprite portrait;
	public Sprite blankPortrait;

	public Transform spawn1;
	public Transform spawn2;

	public GameObject p1ActiveCharacter;
	public GameObject p2ActiveCharacter;

	public Image p1ActiveProfile;
	public Image p2ActiveProfile;

	//public int i = 0;
	//public int o = 0;

	public int team1CharactersLeft;
	public int team2CharactersLeft;


	void Start () {
		DontDestroyOnLoad (this.gameObject);
		if (InputManager.Devices [0] != null) {
			p1Joystick = InputManager.Devices [0];
		}
		if (InputManager.Devices [1] != null) {
			p2Joystick = InputManager.Devices [1];
		}
	
		brogrePortrait = Resources.Load<Sprite> ("CharacterPortraits/BrogreP");
		skeletonPortrait = Resources.Load<Sprite> ("CharacterPortraits/SkeletonP");
		blankPortrait = Resources.Load<Sprite> ("CharacterPortraits/Blank");

		nextCharacterPanel = GameObject.Find ("NextCharacterPanel");

		countdownText = GameObject.Find ("CountdownText").GetComponent<Text> ();
		team1Ch1 = GameObject.Find ("P1TeamPanel").transform.Find ("Ch1Img").gameObject.GetComponent<Image> ();
		team1Ch2 = GameObject.Find ("P1TeamPanel").transform.Find ("Ch2Img").gameObject.GetComponent<Image> ();
		team1Ch3 = GameObject.Find ("P1TeamPanel").transform.Find ("Ch3Img").gameObject.GetComponent<Image> ();
		team1Ch4 = GameObject.Find ("P1TeamPanel").transform.Find ("Ch4Img").gameObject.GetComponent<Image> ();

		team2Ch1 = GameObject.Find ("P2TeamPanel").transform.Find ("Ch1Img").gameObject.GetComponent<Image> ();
		team2Ch2 = GameObject.Find ("P2TeamPanel").transform.Find ("Ch2Img").gameObject.GetComponent<Image> ();
		team2Ch3 = GameObject.Find ("P2TeamPanel").transform.Find ("Ch3Img").gameObject.GetComponent<Image> ();
		team2Ch4 = GameObject.Find ("P2TeamPanel").transform.Find ("Ch4Img").gameObject.GetComponent<Image> ();


		team1Ch1Name = GameObject.Find ("P1TeamPanel").transform.Find ("Ch1Img").Find("Ch1Name").gameObject.GetComponent<Text> ();
		team1Ch2Name = GameObject.Find ("P1TeamPanel").transform.Find ("Ch2Img").Find("Ch2Name").gameObject.GetComponent<Text> ();
		team1Ch3Name = GameObject.Find ("P1TeamPanel").transform.Find ("Ch3Img").Find("Ch3Name").gameObject.GetComponent<Text> ();
		team1Ch4Name = GameObject.Find ("P1TeamPanel").transform.Find ("Ch4Img").Find("Ch4Name").gameObject.GetComponent<Text> ();

		team2Ch1Name = GameObject.Find ("P2TeamPanel").transform.Find ("Ch1Img").Find("Ch1Name").gameObject.GetComponent<Text> ();
		team2Ch2Name = GameObject.Find ("P2TeamPanel").transform.Find ("Ch2Img").Find("Ch2Name").gameObject.GetComponent<Text> ();
		team2Ch3Name = GameObject.Find ("P2TeamPanel").transform.Find ("Ch3Img").Find("Ch3Name").gameObject.GetComponent<Text> ();
		team2Ch4Name = GameObject.Find ("P2TeamPanel").transform.Find ("Ch4Img").Find("Ch4Name").gameObject.GetComponent<Text> ();
	
		p1Panel = GameObject.Find ("P1TeamPanel").GetComponent<Animator> ();
		p2Panel = GameObject.Find ("P2TeamPanel").GetComponent<Animator> ();

		p1Portraits = new List<Sprite> ();
		p2Portraits = new List<Sprite> ();

		team1CharactersLeft = MasterGameManager.instance.teamSize;
		team2CharactersLeft = MasterGameManager.instance.teamSize;

		spawn1 = GameObject.Find ("Spawn1").transform;
		spawn2 = GameObject.Find ("Spawn2").transform;

		LoadCharacters ();

		OpenPanels ();
		countdownText.enabled = false;



	}
	
	// Update is called once per frame
	void Update () {

		if (isCountingDown) {
			
			countdownTimer -= Time.deltaTime;
			countdownText.text = (countdownTimer - 1).ToString("#");
			if (countdownTimer < 1f) {
				countdownText.text = "Fight!";

			}

			if (countdownTimer <= 0) {
				isCountingDown = false;
				countdownText.enabled = false;
				countdownTimer = 4f;
			}
		}


		if (isSelectingCharacter) {
			if (team1Ch1.color == Color.white) {
				p1A = p1Joystick.Action1;
			}
			if (team1Ch2.color == Color.white) {
				p1B = p1Joystick.Action2;
			}
			if (team1Ch3.color == Color.white) {
				p1X = p1Joystick.Action3;
			}
			if (team1Ch4.color == Color.white) {
				p1Y = p1Joystick.Action4;
			}

			if (team2Ch1.color == Color.white) {
				p2A = p2Joystick.Action1;
			}
			if (team2Ch2.color == Color.white) {
				p2B = p2Joystick.Action2;
			}
			if (team2Ch3.color == Color.white) {
				p2X = p2Joystick.Action3;
			}
			if (team2Ch4.color == Color.white) {
				p2Y = p2Joystick.Action4;
			}
				
			if (p1ActiveCharacter == null) {
				if (p1A && team1Ch1.enabled) {
					p1ActiveCharacter = MasterGameManager.instance.team1Characters [0];
					p1ActiveProfile = team1Ch1;
					StartCoroutine ("VibrateController", p1Joystick);
				}
				if (p1B && team1Ch3.enabled) {
					p1ActiveCharacter = MasterGameManager.instance.team1Characters [1];
					p1ActiveProfile = team1Ch2;
					StartCoroutine ("VibrateController", p1Joystick);
				}
				if (p1X && team1Ch3.enabled) {
					p1ActiveCharacter = MasterGameManager.instance.team1Characters [2];
					p1ActiveProfile = team1Ch3;
					StartCoroutine ("VibrateController", p1Joystick);
				}
				if (p1Y && team1Ch4.enabled) {
					p1ActiveCharacter = MasterGameManager.instance.team1Characters [3];
					p1ActiveProfile = team1Ch4;
					StartCoroutine ("VibrateController", p1Joystick);
				}

			}

			if (p2ActiveCharacter == null) {
				
				if (p2A && team2Ch1.enabled) {
					p2ActiveCharacter = MasterGameManager.instance.team2Characters [0];
					p2ActiveProfile = team2Ch1;
					StartCoroutine ("VibrateController", p2Joystick);
				}
				if (p2B && team2Ch2.enabled) {
					p2ActiveCharacter = MasterGameManager.instance.team2Characters [1];
					p2ActiveProfile = team2Ch2;
					StartCoroutine ("VibrateController", p2Joystick);
				}
				if (p2X && team2Ch3.enabled) {
					p2ActiveCharacter = MasterGameManager.instance.team2Characters [2];
					p2ActiveProfile = team2Ch3;
					StartCoroutine ("VibrateController", p2Joystick);
				}
				if (p2Y && team2Ch4.enabled) {
					p2ActiveCharacter = MasterGameManager.instance.team2Characters [3];
					p2ActiveProfile = team2Ch4;
					StartCoroutine ("VibrateController", p2Joystick);
				}
		
			}

			if (p1ActiveCharacter != null && p2ActiveCharacter != null) {

				p1A = false;
				p1B = false;
				p1X = false;
				p1Y = false;

				p2A = false;
				p2B = false;
				p2X = false;
				p2Y = false;



				isSelectingCharacter = false;
				isCountingDown = true;
				countdownText.enabled = true;
				ClosePanels ();
				SpawnCharacters ();
				//StartCountdown ();
			}

		}
		if (Input.GetKeyDown (KeyCode.G)) {
			OpenPanels ();
		}
		if (Input.GetKeyDown (KeyCode.H)) {
			ClosePanels ();
		}
	}
	public void OpenPanels(){
		p1Panel.SetBool ("isOpen", true);
		p2Panel.SetBool ("isOpen", true);



	}
	public void ClosePanels(){
		p1Panel.SetBool ("isOpen", false);
		p2Panel.SetBool ("isOpen", false);
	}

	public void LoadCharacters(){




		for (int i = 0; i < MasterGameManager.instance.team1Characters.Count; i++) {
			//if (character != null) {
			if (MasterGameManager.instance.team1Characters[i].name == "Brogre") {
				p1Portraits.Add (brogrePortrait);
			}
			if (MasterGameManager.instance.team1Characters[i].name == "ToeTip") {
				p1Portraits.Add (skeletonPortrait);
			}
			if (MasterGameManager.instance.team1Characters[i].name == "Empty") {
				p1Portraits.Add (blankPortrait);
			}
			//}
		}





		team1Ch1.sprite = p1Portraits[0];
		team1Ch2.sprite = p1Portraits [1];
		team1Ch3.sprite = p1Portraits [2];
		team1Ch4.sprite = p1Portraits [3];

		team1Ch1Name.text = MasterGameManager.instance.team1Characters [0].name;
		team1Ch2Name.text = MasterGameManager.instance.team1Characters [1].name;
		team1Ch3Name.text = MasterGameManager.instance.team1Characters [2].name;
		team1Ch4Name.text = MasterGameManager.instance.team1Characters [3].name;


		if (team1Ch2.sprite == blankPortrait) {
			team1Ch2.enabled = false;
			team1Ch2Name.enabled = false;
			team1Ch2.gameObject.transform.Find ("ButtonImg").GetComponent<Image> ().enabled = false;
		}
		if (team1Ch3.sprite == blankPortrait) {
			team1Ch3.enabled = false;
			team1Ch3Name.enabled = false;
			team1Ch3.gameObject.transform.Find ("ButtonImg").GetComponent<Image> ().enabled = false;
		}

		if (team1Ch4.sprite == blankPortrait) {
			team1Ch4.enabled = false;
			team1Ch4Name.enabled = false;
			team1Ch4.gameObject.transform.Find ("ButtonImg").GetComponent<Image> ().enabled = false;
		}


		for (int o = 0;o < MasterGameManager.instance.team2Characters.Count; o++) {
			//if (character2 != null) {
			if (MasterGameManager.instance.team2Characters[o].name == "Brogre") {
				p2Portraits.Add (brogrePortrait);
			}
			if (MasterGameManager.instance.team2Characters[o].name == "ToeTip") {
				p2Portraits.Add (skeletonPortrait);
			}
			if (MasterGameManager.instance.team2Characters[o].name == "Empty") {
				p2Portraits.Add (blankPortrait);
			}
			//}
		}


		team2Ch1.sprite = p2Portraits [0];
		team2Ch2.sprite = p2Portraits [1];
		team2Ch3.sprite = p2Portraits [2];
		team2Ch4.sprite = p2Portraits [3];

		team2Ch1Name.text = MasterGameManager.instance.team2Characters [0].name;
		team2Ch2Name.text = MasterGameManager.instance.team2Characters [1].name;
		team2Ch3Name.text = MasterGameManager.instance.team2Characters [2].name;
		team2Ch4Name.text = MasterGameManager.instance.team2Characters [3].name;



		if (team2Ch2.sprite == blankPortrait) {
			team2Ch2.enabled = false;
			team2Ch2Name.enabled = false;
			team2Ch2.gameObject.transform.Find ("ButtonImg").GetComponent<Image> ().enabled = false;
		}
		if (team2Ch3.sprite == blankPortrait) {
			team2Ch3.enabled = false;
			team2Ch3Name.enabled = false;
			team2Ch3.gameObject.transform.Find ("ButtonImg").GetComponent<Image> ().enabled = false;
		}

		if (team2Ch4.sprite == blankPortrait) {
			team2Ch4.enabled = false;
			team2Ch4Name.enabled = false;
			team2Ch4.gameObject.transform.Find ("ButtonImg").GetComponent<Image> ().enabled = false;
		}














	
	}


	public void SpawnCharacters(){
		characterSpawn = Instantiate (p1ActiveCharacter, spawn1.transform.position, spawn1.transform.rotation) as GameObject;
		characterSpawn.tag = "Player1";
		characterSpawn.GetComponent<PlayerState> ().teamNum = 1;
		characterSpawn = Instantiate (p2ActiveCharacter, spawn2.transform.position, spawn2.transform.rotation) as GameObject;
		characterSpawn.tag = "Player2";
		characterSpawn.GetComponent<PlayerState> ().teamNum = 2;

	}

	public void RoundOver(int loser){

		p1ActiveCharacter = null;
		p2ActiveCharacter = null;

		GameObject[] allPlayersLeft;

		allPlayersLeft = GameObject.FindGameObjectsWithTag ("Player1");

		foreach (GameObject player in allPlayersLeft) {
			Destroy (player);
		}
		allPlayersLeft = GameObject.FindGameObjectsWithTag ("Player2");

		foreach (GameObject player in allPlayersLeft) {
			Destroy (player);
		}



		if (loser == 1) {
			p1ActiveProfile.color = Color.black;
			team1CharactersLeft -= 1;
			if (team1CharactersLeft <= 0) {
				SceneManager.LoadScene ("CharacterAndLevelSelect");
			}
		}

		if (loser == 2) {
			p2ActiveProfile.color = Color.black;
			team2CharactersLeft -= 1;
			if (team2CharactersLeft <= 0) {
				SceneManager.LoadScene ("CharacterAndLevelSelect");
			}
		}

			
		isSelectingCharacter = true;
		OpenPanels ();
	}

	IEnumerator VibrateController(InputDevice whichDevice){
		whichDevice.Vibrate (0.3f);
		yield return new WaitForSeconds(0.3f);
		whichDevice.StopVibration ();
	}
}
