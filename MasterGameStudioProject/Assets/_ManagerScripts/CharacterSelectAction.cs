using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterSelectAction : MonoBehaviour {

	public Image team1Ch1;
	public Image team1Ch2;
	public Image team1Ch3;
	public Image team1Ch4;

	public Image team2Ch1;
	public Image team2Ch2;
	public Image team2Ch3;
	public Image team2Ch4;


	public Text teamSizeDisplay;

	public int team1CurrentSelection = 1;
	public int team2CurrentSelection = 1;

	public int teamSize = 3;

	public Sprite brogrePortrait;
	public Sprite skeletonPortrait;
	public Sprite tinyPortrait;
	public Sprite guyPortrait;
	public Sprite drDecayPortrait;
	public Sprite claymondPortrait;
	public Sprite succPortrait;
	public Sprite gorgonPortrait;


	public Sprite portrait;
	public Sprite blankPortrait;

	public List<Sprite> team1Characters;
	public List<Sprite> team2Characters;

	public GameObject buttonManagerObject;


	// Use this for initialization
	void Start () {

		teamSize = MasterGameManager.instance.teamSize;

		team1Characters = new List<Sprite>();
		team2Characters = new List<Sprite>();

		brogrePortrait = Resources.Load<Sprite> ("CharacterPortraits/BrogreP");
		tinyPortrait = Resources.Load<Sprite> ("CharacterPortraits/TinyP");
		skeletonPortrait = Resources.Load<Sprite> ("CharacterPortraits/SkeletonP");
		claymondPortrait = Resources.Load<Sprite> ("CharacterPortraits/ClaymondP");
		drDecayPortrait = Resources.Load<Sprite> ("CharacterPortraits/DrDecayP");
		succPortrait = Resources.Load<Sprite> ("CharacterPortraits/SuccP");
		guyPortrait = Resources.Load<Sprite> ("CharacterPortraits/GuyP");
		gorgonPortrait = Resources.Load<Sprite> ("CharacterPortraits/GorgonP");

		blankPortrait = Resources.Load<Sprite> ("CharacterPortraits/Blank");

		teamSizeDisplay = GameObject.Find ("TeamSizeNum").GetComponent<Text> ();

		team1Ch1 = GameObject.Find ("P1SelectedCharacters").transform.Find ("Ch1").gameObject.GetComponent<Image> ();
		team1Ch2 = GameObject.Find ("P1SelectedCharacters").transform.Find ("Ch2").gameObject.GetComponent<Image> ();
		team1Ch3 = GameObject.Find ("P1SelectedCharacters").transform.Find ("Ch3").gameObject.GetComponent<Image> ();
		team1Ch4 = GameObject.Find ("P1SelectedCharacters").transform.Find ("Ch4").gameObject.GetComponent<Image> ();


		team2Ch1 = GameObject.Find ("P2SelectedCharacters").transform.Find ("Ch1").gameObject.GetComponent<Image> ();
		team2Ch2 = GameObject.Find ("P2SelectedCharacters").transform.Find ("Ch2").gameObject.GetComponent<Image> ();
		team2Ch3 = GameObject.Find ("P2SelectedCharacters").transform.Find ("Ch3").gameObject.GetComponent<Image> ();
		team2Ch4 = GameObject.Find ("P2SelectedCharacters").transform.Find ("Ch4").gameObject.GetComponent<Image> ();
		buttonManagerObject = GameObject.Find ("ButtonManager");
		ChangeTeamSize (0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddCharacter(int whichTeam, string whichCharacter){
		
		if (whichCharacter == "Brogre") {
			portrait = brogrePortrait;

		}
		if (whichCharacter == "Skelly") {
			portrait = skeletonPortrait;

		}
		if (whichCharacter == "Tiny") {
			portrait = tinyPortrait;

		}
		if (whichCharacter == "DrDecay") {
			portrait = drDecayPortrait;

		}
		if (whichCharacter == "Gorgon") {
			portrait = gorgonPortrait;

		}
		if (whichCharacter == "Claymond") {
			portrait = claymondPortrait;

		}
		if (whichCharacter == "Guy") {
			portrait = guyPortrait;

		}
		if (whichCharacter == "Succ") {
			portrait = succPortrait;

		}

		if (whichTeam == 1 && team1CurrentSelection <= teamSize) {
			


			switch (team1CurrentSelection) {
			case 1:
				team1Ch1.sprite = portrait;
				break;
			case 2:
				team1Ch2.sprite = portrait;
				break;
			case 3:
				team1Ch3.sprite = portrait;
				break;
			case 4:
				team1Ch4.sprite = portrait;
				break;


			}
			team1CurrentSelection += 1;
		}


		if (whichTeam == 2 && team2CurrentSelection <= teamSize) {



			switch (team2CurrentSelection) {
			case 1:
				team2Ch1.sprite = portrait;
				break;
			case 2:
				team2Ch2.sprite = portrait;
				break;
			case 3:
				team2Ch3.sprite = portrait;
				break;
			case 4:
				team2Ch4.sprite = portrait;
				break;


			}
			team2CurrentSelection += 1;
		}


	}
	public void RemoveLastCharacter (int whichTeam){
		if (whichTeam == 1) {
			if (team1CurrentSelection > 1) {
				team1CurrentSelection -= 1;
				switch (team1CurrentSelection) {
				case 1:
					team1Ch1.sprite = blankPortrait;
					break;
				case 2:
					team1Ch2.sprite = blankPortrait;
					break;
				case 3:
					team1Ch3.sprite = blankPortrait;
					break;
				case 4:
					team1Ch4.sprite = blankPortrait;
					break;


				}
			}
		}


		if (whichTeam == 2) {
			if (team2CurrentSelection > 1) {
				team2CurrentSelection -= 1;
				switch (team2CurrentSelection) {
				case 1:
					team2Ch1.sprite = blankPortrait;
					break;
				case 2:
					team2Ch2.sprite = blankPortrait;
					break;
				case 3:
					team2Ch3.sprite = blankPortrait;
					break;
				case 4:
					team2Ch4.sprite = blankPortrait;
					break;


				}
			}
		}


			}
	void UpdateChrDisplay(){

	}
	public void ChangeTeamSize(int amount){


		teamSize += amount;
		print (teamSize);
		if (teamSize <= 0) {
			teamSize = 1;
		}
		if (teamSize >= 5) {
			teamSize = 4;

		}
		if (teamSize == 4) {
			team1Ch1.enabled = true;
			team1Ch2.enabled = true;
			team1Ch3.enabled = true;
			team1Ch4.enabled = true;

			team2Ch1.enabled = true;
			team2Ch2.enabled = true;
			team2Ch3.enabled = true;
			team2Ch4.enabled = true;
		}
		if (teamSize == 3) {
			team1Ch1.enabled = true;
			team1Ch2.enabled = true;
			team1Ch3.enabled = true;
			team1Ch4.enabled = false;
			team1Ch4.sprite = blankPortrait;


			team2Ch1.enabled = true;
			team2Ch2.enabled = true;
			team2Ch3.enabled = true;
			team2Ch4.enabled = false;
			team1Ch4.sprite = blankPortrait;
		}
		if (teamSize == 2) {
			team1Ch1.enabled = true;
			team1Ch2.enabled = true;
			team1Ch3.enabled = false;
			team1Ch4.enabled = false;
			team1Ch3.sprite = blankPortrait;
			team1Ch4.sprite = blankPortrait;


			team2Ch1.enabled = true;
			team2Ch2.enabled = true;
			team2Ch3.enabled = false;
			team2Ch4.enabled = false;
			team2Ch3.sprite = blankPortrait;
			team2Ch4.sprite = blankPortrait;
		}
		if (teamSize == 1) {
			team1Ch1.enabled = true;
			team1Ch2.enabled = false;
			team1Ch3.enabled = false;
			team1Ch4.enabled = false;
			team1Ch2.sprite = blankPortrait;
			team1Ch3.sprite = blankPortrait;
			team1Ch4.sprite = blankPortrait;

			team2Ch1.enabled = true;
			team2Ch2.enabled = false;
			team2Ch3.enabled = false;
			team2Ch4.enabled = false;
			team2Ch2.sprite = blankPortrait;
			team2Ch3.sprite = blankPortrait;
			team2Ch4.sprite = blankPortrait;
		}
		teamSizeDisplay.text = teamSize.ToString ();
	}

	public void FinalizeTeams(){
		if (team1CurrentSelection - 1 >= teamSize && team2CurrentSelection - 1 >= teamSize) {

			MasterGameManager.instance.teamSize = teamSize;
			team1Characters.Add (team1Ch1.sprite);
			team1Characters.Add (team1Ch2.sprite);
			team1Characters.Add (team1Ch3.sprite);
			team1Characters.Add (team1Ch4.sprite);

			team2Characters.Add (team2Ch1.sprite);
			team2Characters.Add (team2Ch2.sprite);
			team2Characters.Add (team2Ch3.sprite);
			team2Characters.Add (team2Ch4.sprite);

			foreach (Sprite chr in team1Characters) {
				print (chr.name);
				if (chr.name == "BrogreP") {
					MasterGameManager.instance.AddCharacter (1, "Brogre");
				}
				if (chr.name == "SkeletonP") {
					MasterGameManager.instance.AddCharacter (1, "Skelly");
				}
				if (chr.name == "TinyP") {
					MasterGameManager.instance.AddCharacter (1, "Tiny");
				}
				if (chr.name == "GorgonP") {
					MasterGameManager.instance.AddCharacter (1, "Neredy");
				}
				if (chr.name == "SuccP") {
					MasterGameManager.instance.AddCharacter (1, "Succ");
				}
				if (chr.name == "ClaymondP") {
					MasterGameManager.instance.AddCharacter (1, "Claymond");
				}
				if (chr.name == "GuyP") {
					MasterGameManager.instance.AddCharacter (1, "Guy");
				}
				if (chr.name == "DrDecayP") {
					MasterGameManager.instance.AddCharacter (1, "DrDecay");
				}

				if (chr.name == "Blank") {
					Debug.Log ("added null");
					MasterGameManager.instance.AddCharacter (1, "Empty");
				}


			}

			foreach (Sprite chr in team2Characters) {
				print (chr.name);
				if (chr.name == "BrogreP") {
					MasterGameManager.instance.AddCharacter (2, "Brogre");
				}
				if (chr.name == "SkeletonP") {
					MasterGameManager.instance.AddCharacter (2, "Skelly");
				}
				if (chr.name == "TinyP") {
					MasterGameManager.instance.AddCharacter (2, "Tiny");
				}
				if (chr.name == "GorgonP") {
					MasterGameManager.instance.AddCharacter (2, "Neredy");
				}
				if (chr.name == "SuccP") {
					MasterGameManager.instance.AddCharacter (2, "Succ");
				}
				if (chr.name == "ClaymondP") {
					MasterGameManager.instance.AddCharacter (2, "Claymond");
				}
				if (chr.name == "GuyP") {
					MasterGameManager.instance.AddCharacter (2, "Guy");
				}
				if (chr.name == "DrDecayP") {
					MasterGameManager.instance.AddCharacter (2, "DrDecay");
				}
				if (chr.name == "Blank") {
					Debug.Log ("added null");
					MasterGameManager.instance.AddCharacter (2, "Empty");
				}
			}
			buttonManagerObject.GetComponent<ButtonManager> ().LevelSelect ();
		}
	}





}
