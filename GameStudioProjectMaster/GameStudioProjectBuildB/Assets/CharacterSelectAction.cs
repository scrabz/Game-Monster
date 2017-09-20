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

	public int teamSize = 4;

	public Sprite brogrePortrait;
	public Sprite skeletonPortrait;


	public Sprite portrait;
	public Sprite blankPortrait;

	public List<Sprite> team1Characters;
	public List<Sprite> team2Characters;

	// Use this for initialization
	void Start () {

		team1Characters = new List<Sprite>();
		team2Characters = new List<Sprite>();

		brogrePortrait = Resources.Load<Sprite> ("CharacterPortraits/BrogreP");
		skeletonPortrait = Resources.Load<Sprite> ("CharacterPortraits/SkeletonP");
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

	}
	public void RemoveLastCharacter (int whichTeam){
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
	void UpdateChrDisplay(){

	}
	public void ChangeTeamSize(int amount){
			teamSize += amount;
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

			team2Ch1.enabled = true;
			team2Ch2.enabled = true;
			team2Ch3.enabled = true;
			team2Ch4.enabled = false;
		}
		if (teamSize == 2) {
			team1Ch1.enabled = true;
			team1Ch2.enabled = true;
			team1Ch3.enabled = false;
			team1Ch4.enabled = false;

			team2Ch1.enabled = true;
			team2Ch2.enabled = true;
			team2Ch3.enabled = false;
			team2Ch4.enabled = false;
		}
		if (teamSize == 1) {
			team1Ch1.enabled = true;
			team1Ch2.enabled = false;
			team1Ch3.enabled = false;
			team1Ch4.enabled = false;

			team2Ch1.enabled = true;
			team2Ch2.enabled = false;
			team2Ch3.enabled = false;
			team2Ch4.enabled = false;;
		}
		teamSizeDisplay.text = teamSize.ToString ();
	}

	public void FinalizeTeams(){

		team1Characters.Add (team1Ch1.sprite);
		team1Characters.Add (team1Ch2.sprite);
		team1Characters.Add (team1Ch3.sprite);
		team1Characters.Add (team1Ch4.sprite);

		team2Characters.Add (team2Ch1.sprite);
		team2Characters.Add (team2Ch2.sprite);
		team2Characters.Add (team2Ch3.sprite);
		team2Characters.Add (team2Ch4.sprite);

		foreach (Sprite chr in team1Characters) {
			if (chr.name == "BrogreP") {
				MasterGameManager.instance.AddCharacter (1, "Brogre");
			}
			if (chr.name == "SkeletonP") {
				MasterGameManager.instance.AddCharacter (1, "Skelly");
			}
		}

		foreach (Sprite chr in team2Characters) {
			if (chr.name == "BrogreP") {
				MasterGameManager.instance.AddCharacter (2, "Brogre");
			}
			if (chr.name == "SkeletonP") {
				MasterGameManager.instance.AddCharacter (2, "Skelly");
			}
		}
	}


}
