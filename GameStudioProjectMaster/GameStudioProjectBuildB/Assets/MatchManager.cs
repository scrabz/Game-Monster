using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;

public class MatchManager : MonoBehaviour {

	public bool isSelectingCharacter = true;
	public bool isCountingDown = false;
	public bool isFighting = false;


	public GameObject nextCharacterPanel;

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


		LoadCharacters ();

		OpenPanels ();

	}
	
	// Update is called once per frame
	void Update () {
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
				

			if (p1A) {
				p1ActiveCharacter = MasterGameManager.instance.team1Characters [0];
				StartCoroutine ("VibrateController", p1Joystick);
			}
			if (p1B) {
				p1ActiveCharacter = MasterGameManager.instance.team1Characters [1];
				StartCoroutine ("VibrateController", p1Joystick);
			}
			if (p1X) {
				p1ActiveCharacter = MasterGameManager.instance.team1Characters [2];
				StartCoroutine ("VibrateController", p1Joystick);
			}
			if (p1Y) {
				p1ActiveCharacter = MasterGameManager.instance.team1Characters [3];
				StartCoroutine ("VibrateController", p1Joystick);
			}
			if (MasterGameManager.instance.team2Characters.Count > 0) {
				if (p2A) {
					p2ActiveCharacter = MasterGameManager.instance.team2Characters [0];
					StartCoroutine ("VibrateController", p2Joystick);
				}
				if (p2B) {
					p2ActiveCharacter = MasterGameManager.instance.team2Characters [1];
					StartCoroutine ("VibrateController", p2Joystick);
				}
				if (p2X) {
					p2ActiveCharacter = MasterGameManager.instance.team2Characters [2];
					StartCoroutine ("VibrateController", p2Joystick);
				}
				if (p2Y) {
					p2ActiveCharacter = MasterGameManager.instance.team2Characters [3];
					StartCoroutine ("VibrateController", p2Joystick);
				}
			}

			if (p1ActiveCharacter != null && p2ActiveCharacter != null) {
				isSelectingCharacter = false;
				ClosePanels ();
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
		foreach (GameObject character in MasterGameManager.instance.team1Characters) {
			if (character != null) {
				if (character.name == "Brogre") {
					p1Portraits.Add (brogrePortrait);
				}
				if (character.name == "ToeTip") {
					p1Portraits.Add (skeletonPortrait);
				}
			}
		}

		foreach (GameObject character in MasterGameManager.instance.team2Characters) {
			if (character != null) {
				if (character.name == "Brogre") {
					p2Portraits.Add (brogrePortrait);
				}
				if (character.name == "Skelly") {
					p2Portraits.Add (skeletonPortrait);
				}
			}
		}


		team1Ch1.sprite = p1Portraits[0];
		team1Ch2.sprite = p1Portraits [1];
		team1Ch3.sprite = p1Portraits [2];
		team1Ch4.sprite = p1Portraits [3];

		if (p2Portraits.Count > 0) {
			team2Ch1.sprite = p2Portraits [0];
			team2Ch2.sprite = p2Portraits [1];
			team2Ch3.sprite = p2Portraits [2];
			team2Ch4.sprite = p2Portraits [3];
		}

		team1Ch1Name.text = MasterGameManager.instance.team1Characters [0].name;
		team1Ch2Name.text = MasterGameManager.instance.team1Characters [1].name;
		team1Ch3Name.text = MasterGameManager.instance.team1Characters [2].name;
		team1Ch4Name.text = MasterGameManager.instance.team1Characters [3].name;

		if (p2Portraits.Count > 0) {
			team2Ch1Name.text = MasterGameManager.instance.team2Characters [0].name;
			team2Ch2Name.text = MasterGameManager.instance.team2Characters [1].name;
			team2Ch3Name.text = MasterGameManager.instance.team2Characters [2].name;
			team2Ch4Name.text = MasterGameManager.instance.team2Characters [3].name;
		}
	}

	IEnumerator VibrateController(InputDevice whichDevice){
		whichDevice.Vibrate (1);
		yield return new WaitForSeconds(1f);
		whichDevice.StopVibration ();
	}
}
