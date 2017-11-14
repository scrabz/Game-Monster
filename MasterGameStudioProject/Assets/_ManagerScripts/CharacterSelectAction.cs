using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;

public class CharacterSelectAction : MonoBehaviour {

	public Image player1Ch1;
	public Image player1Ch2;
	public Image player1Ch3;
	public Image player1Ch4;

	public Image player2Ch1;
	public Image player2Ch2;
	public Image player2Ch3;
	public Image player2Ch4;



	public Image player3Ch1;
	public Image player3Ch2;
	public Image player3Ch3;
	public Image player3Ch4;

	public Image player4Ch1;
	public Image player4Ch2;
	public Image player4Ch3;
	public Image player4Ch4;



	public Text playerSizeDisplay;

	public int player1CurrentSelection = 1;
	public int player2CurrentSelection = 1;
	public int player3CurrentSelection = 1;
	public int player4CurrentSelection = 1;

	public int playerSize = 3;

	public Sprite brogrePortrait;
	public Sprite skeletonPortrait;
	public Sprite tinyPortrait;
	public Sprite guyPortrait;
	public Sprite drDecayPortrait;
	public Sprite claymondPortrait;
	public Sprite succPortrait;
	public Sprite gorgonPortrait;
	public Sprite wynkPortrait;


	public Sprite portrait;
	public Sprite blankPortrait;

	public List<Sprite> player1Characters;
	public List<Sprite> player2Characters;
	public List<Sprite> player3Characters;
	public List<Sprite> player4Characters;

	public GameObject buttonManagerObject;


	// Use this for initialization
	void Start () {





		playerSize = MasterGameManager.instance.teamSize;

		player1Characters = new List<Sprite>();
		player2Characters = new List<Sprite>();

		brogrePortrait = Resources.Load<Sprite> ("CharacterPortraits/BrogreP");
		tinyPortrait = Resources.Load<Sprite> ("CharacterPortraits/TinyP");
		skeletonPortrait = Resources.Load<Sprite> ("CharacterPortraits/SkeletonP");
		claymondPortrait = Resources.Load<Sprite> ("CharacterPortraits/ClaymondP");
		drDecayPortrait = Resources.Load<Sprite> ("CharacterPortraits/DrDecayP");
		succPortrait = Resources.Load<Sprite> ("CharacterPortraits/SuccP");
		guyPortrait = Resources.Load<Sprite> ("CharacterPortraits/GuyP");
		gorgonPortrait = Resources.Load<Sprite> ("CharacterPortraits/GorgonP");
		//wynkPortrait = Resources.Load<Sprite> ("CharacterPortraits/WynkP");
		blankPortrait = Resources.Load<Sprite> ("CharacterPortraits/Blank");

		playerSizeDisplay = GameObject.Find ("TeamSizeNum").GetComponent<Text> ();

		player1Ch1 = GameObject.Find ("P1SelectedCharacters").transform.Find ("Ch1").gameObject.GetComponent<Image> ();
		player1Ch2 = GameObject.Find ("P1SelectedCharacters").transform.Find ("Ch2").gameObject.GetComponent<Image> ();
		player1Ch3 = GameObject.Find ("P1SelectedCharacters").transform.Find ("Ch3").gameObject.GetComponent<Image> ();
		player1Ch4 = GameObject.Find ("P1SelectedCharacters").transform.Find ("Ch4").gameObject.GetComponent<Image> ();


		player2Ch1 = GameObject.Find ("P2SelectedCharacters").transform.Find ("Ch1").gameObject.GetComponent<Image> ();
		player2Ch2 = GameObject.Find ("P2SelectedCharacters").transform.Find ("Ch2").gameObject.GetComponent<Image> ();
		player2Ch3 = GameObject.Find ("P2SelectedCharacters").transform.Find ("Ch3").gameObject.GetComponent<Image> ();
		player2Ch4 = GameObject.Find ("P2SelectedCharacters").transform.Find ("Ch4").gameObject.GetComponent<Image> ();


		player3Ch1 = GameObject.Find ("P3SelectedCharacters").transform.Find ("Ch1").gameObject.GetComponent<Image> ();
		player3Ch2 = GameObject.Find ("P3SelectedCharacters").transform.Find ("Ch2").gameObject.GetComponent<Image> ();
		player3Ch3 = GameObject.Find ("P3SelectedCharacters").transform.Find ("Ch3").gameObject.GetComponent<Image> ();
		player3Ch4 = GameObject.Find ("P3SelectedCharacters").transform.Find ("Ch4").gameObject.GetComponent<Image> ();


		player4Ch1 = GameObject.Find ("P4SelectedCharacters").transform.Find ("Ch1").gameObject.GetComponent<Image> ();
		player4Ch2 = GameObject.Find ("P4SelectedCharacters").transform.Find ("Ch2").gameObject.GetComponent<Image> ();
		player4Ch3 = GameObject.Find ("P4SelectedCharacters").transform.Find ("Ch3").gameObject.GetComponent<Image> ();
		player4Ch4 = GameObject.Find ("P4SelectedCharacters").transform.Find ("Ch4").gameObject.GetComponent<Image> ();

		buttonManagerObject = GameObject.Find ("ButtonManager");
		ChangeTeamSize (0);
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.Devices [2] != null) {
			if (InputManager.Devices [2].Action1.WasPressed) {
				buttonManagerObject.GetComponent<ButtonManager> ().EnablePlayer3 ();
			}
		}


		if (InputManager.Devices [3] != null) {
			if (InputManager.Devices [3].Action1.WasPressed) {
				buttonManagerObject.GetComponent<ButtonManager> ().EnablePlayer4 ();
			}
		}
	}

	public void AddCharacter(int whichplayer, string whichCharacter){
		
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

		if (whichCharacter == "Wynk") {
			portrait = wynkPortrait;

		}

		if (whichplayer == 1 && player1CurrentSelection <= playerSize) {
			


			switch (player1CurrentSelection) {
			case 1:
				player1Ch1.sprite = portrait;
				break;
			case 2:
				player1Ch2.sprite = portrait;
				break;
			case 3:
				player1Ch3.sprite = portrait;
				break;
			case 4:
				player1Ch4.sprite = portrait;
				break;


			}
			player1CurrentSelection += 1;
		}


		if (whichplayer == 2 && player2CurrentSelection <= playerSize) {



			switch (player2CurrentSelection) {
			case 1:
				player2Ch1.sprite = portrait;
				break;
			case 2:
				player2Ch2.sprite = portrait;
				break;
			case 3:
				player2Ch3.sprite = portrait;
				break;
			case 4:
				player2Ch4.sprite = portrait;
				break;


			}
			player2CurrentSelection += 1;
		}

		if (whichplayer == 3 && player3CurrentSelection <= playerSize) {



			switch (player3CurrentSelection) {
			case 1:
				player3Ch1.sprite = portrait;
				break;
			case 2:
				player3Ch2.sprite = portrait;
				break;
			case 3:
				player3Ch3.sprite = portrait;
				break;
			case 4:
				player3Ch4.sprite = portrait;
				break;


			}
			player3CurrentSelection += 1;
		}

		if (whichplayer == 4 && player4CurrentSelection <= playerSize) {



			switch (player4CurrentSelection) {
			case 1:
				player4Ch1.sprite = portrait;
				break;
			case 2:
				player4Ch2.sprite = portrait;
				break;
			case 3:
				player4Ch3.sprite = portrait;
				break;
			case 4:
				player4Ch4.sprite = portrait;
				break;


			}
			player4CurrentSelection += 1;
		}
	}
	public void RemoveLastCharacter (int whichplayer){
		if (whichplayer == 1) {
			if (player1CurrentSelection > 1) {
				player1CurrentSelection -= 1;
				switch (player1CurrentSelection) {
				case 1:
					player1Ch1.sprite = blankPortrait;
					break;
				case 2:
					player1Ch2.sprite = blankPortrait;
					break;
				case 3:
					player1Ch3.sprite = blankPortrait;
					break;
				case 4:
					player1Ch4.sprite = blankPortrait;
					break;


				}
			}
		}


		if (whichplayer == 2) {
			if (player2CurrentSelection > 1) {
				player2CurrentSelection -= 1;
				switch (player2CurrentSelection) {
				case 1:
					player2Ch1.sprite = blankPortrait;
					break;
				case 2:
					player2Ch2.sprite = blankPortrait;
					break;
				case 3:
					player2Ch3.sprite = blankPortrait;
					break;
				case 4:
					player2Ch4.sprite = blankPortrait;
					break;


				}
			}
		}
		if (whichplayer == 3) {
			if (player3CurrentSelection > 1) {
				player3CurrentSelection -= 1;
				switch (player3CurrentSelection) {
				case 1:
					player3Ch1.sprite = blankPortrait;
					break;
				case 2:
					player3Ch2.sprite = blankPortrait;
					break;
				case 3:
					player3Ch3.sprite = blankPortrait;
					break;
				case 4:
					player3Ch4.sprite = blankPortrait;
					break;


				}
			}
		}
		if (whichplayer == 4) {
			if (player4CurrentSelection > 1) {
				player4CurrentSelection -= 1;
				switch (player4CurrentSelection) {
				case 1:
					player4Ch1.sprite = blankPortrait;
					break;
				case 2:
					player4Ch2.sprite = blankPortrait;
					break;
				case 3:
					player4Ch3.sprite = blankPortrait;
					break;
				case 4:
					player4Ch4.sprite = blankPortrait;
					break;


				}
			}
		}


			}
	void UpdateChrDisplay(){

	}
	public void ChangeTeamSize(int amount){


		playerSize += amount;
		print (playerSize);
		if (playerSize <= 0) {
			playerSize = 1;
		}
		if (playerSize >= 5) {
			playerSize = 4;

		}
		if (playerSize == 4) {
			player1Ch1.enabled = true;
			player1Ch2.enabled = true;
			player1Ch3.enabled = true;
			player1Ch4.enabled = true;

			player2Ch1.enabled = true;
			player2Ch2.enabled = true;
			player2Ch3.enabled = true;
			player2Ch4.enabled = true;

			player3Ch1.enabled = true;
			player3Ch2.enabled = true;
			player3Ch3.enabled = true;
			player3Ch4.enabled = true;

			player4Ch1.enabled = true;
			player4Ch2.enabled = true;
			player4Ch3.enabled = true;
			player4Ch4.enabled = true;
		}
		if (playerSize == 3) {
			player1Ch1.enabled = true;
			player1Ch2.enabled = true;
			player1Ch3.enabled = true;
			player1Ch4.enabled = false;
			player1Ch4.sprite = blankPortrait;


			player2Ch1.enabled = true;
			player2Ch2.enabled = true;
			player2Ch3.enabled = true;
			player2Ch4.enabled = false;
			player2Ch4.sprite = blankPortrait;

			player3Ch1.enabled = true;
			player3Ch2.enabled = true;
			player3Ch3.enabled = true;
			player3Ch4.enabled = false;
			player3Ch4.sprite = blankPortrait;

			player4Ch1.enabled = true;
			player4Ch2.enabled = true;
			player4Ch3.enabled = true;
			player4Ch4.enabled = false;
			player4Ch4.sprite = blankPortrait;

		}
		if (playerSize == 2) {
			player1Ch1.enabled = true;
			player1Ch2.enabled = true;
			player1Ch3.enabled = false;
			player1Ch4.enabled = false;
			player1Ch3.sprite = blankPortrait;
			player1Ch4.sprite = blankPortrait;


			player2Ch1.enabled = true;
			player2Ch2.enabled = true;
			player2Ch3.enabled = false;
			player2Ch4.enabled = false;
			player2Ch3.sprite = blankPortrait;
			player2Ch4.sprite = blankPortrait;

			player3Ch1.enabled = true;
			player3Ch2.enabled = true;
			player3Ch3.enabled = false;
			player3Ch4.enabled = false;
			player3Ch3.sprite = blankPortrait;
			player3Ch4.sprite = blankPortrait;


			player4Ch1.enabled = true;
			player4Ch2.enabled = true;
			player4Ch3.enabled = false;
			player4Ch4.enabled = false;
			player4Ch3.sprite = blankPortrait;
			player4Ch4.sprite = blankPortrait;

		}
		if (playerSize == 1) {
			player1Ch1.enabled = true;
			player1Ch2.enabled = false;
			player1Ch3.enabled = false;
			player1Ch4.enabled = false;
			player1Ch2.sprite = blankPortrait;
			player1Ch3.sprite = blankPortrait;
			player1Ch4.sprite = blankPortrait;

			player2Ch1.enabled = true;
			player2Ch2.enabled = false;
			player2Ch3.enabled = false;
			player2Ch4.enabled = false;
			player2Ch2.sprite = blankPortrait;
			player2Ch3.sprite = blankPortrait;
			player2Ch4.sprite = blankPortrait;


			player3Ch1.enabled = true;
			player3Ch2.enabled = false;
			player3Ch3.enabled = false;
			player3Ch4.enabled = false;
			player3Ch2.sprite = blankPortrait;
			player3Ch3.sprite = blankPortrait;
			player3Ch4.sprite = blankPortrait;


			player4Ch1.enabled = true;
			player4Ch2.enabled = false;
			player4Ch3.enabled = false;
			player4Ch4.enabled = false;
			player4Ch2.sprite = blankPortrait;
			player4Ch3.sprite = blankPortrait;
			player4Ch4.sprite = blankPortrait;
		}
		playerSizeDisplay.text = playerSize.ToString ();
	}

	public void FinalizePlayers(){
		//HERE
		if (player1CurrentSelection - 1 >= playerSize && player2CurrentSelection - 1 >= playerSize) {
			if (player3CurrentSelection - 1 >= playerSize || MasterGameManager.instance.p3Enabled == false) {

				if (player4CurrentSelection - 1 >= playerSize || MasterGameManager.instance.p4Enabled == false) {
					MasterGameManager.instance.teamSize = playerSize;
					player1Characters.Add (player1Ch1.sprite);
					player1Characters.Add (player1Ch2.sprite);
					player1Characters.Add (player1Ch3.sprite);
					player1Characters.Add (player1Ch4.sprite);

					player2Characters.Add (player2Ch1.sprite);
					player2Characters.Add (player2Ch2.sprite);
					player2Characters.Add (player2Ch3.sprite);
					player2Characters.Add (player2Ch4.sprite);

					player3Characters.Add (player3Ch1.sprite);
					player3Characters.Add (player3Ch2.sprite);
					player3Characters.Add (player3Ch3.sprite);
					player3Characters.Add (player3Ch4.sprite);

					player4Characters.Add (player4Ch1.sprite);
					player4Characters.Add (player4Ch2.sprite);
					player4Characters.Add (player4Ch3.sprite);
					player4Characters.Add (player4Ch4.sprite);


					foreach (Sprite chr in player1Characters) {
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
						if (chr.name == "WynkP") {
							MasterGameManager.instance.AddCharacter (1, "Wynk");
						}
						if (chr.name == "Blank") {
							Debug.Log ("added null");
							MasterGameManager.instance.AddCharacter (1, "Empty");
						}


					}

					foreach (Sprite chr in player2Characters) {
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
						if (chr.name == "WynkP") {
							MasterGameManager.instance.AddCharacter (2, "Wynk");
						}
						if (chr.name == "Blank") {
							Debug.Log ("added null");
							MasterGameManager.instance.AddCharacter (2, "Empty");
						}
					}

					foreach (Sprite chr in player3Characters) {
						print (chr.name);
						if (chr.name == "BrogreP") {
							MasterGameManager.instance.AddCharacter (3, "Brogre");
						}
						if (chr.name == "SkeletonP") {
							MasterGameManager.instance.AddCharacter (3, "Skelly");
						}
						if (chr.name == "TinyP") {
							MasterGameManager.instance.AddCharacter (3, "Tiny");
						}
						if (chr.name == "GorgonP") {
							MasterGameManager.instance.AddCharacter (3, "Neredy");
						}
						if (chr.name == "SuccP") {
							MasterGameManager.instance.AddCharacter (3, "Succ");
						}
						if (chr.name == "ClaymondP") {
							MasterGameManager.instance.AddCharacter (3, "Claymond");
						}
						if (chr.name == "GuyP") {
							MasterGameManager.instance.AddCharacter (3, "Guy");
						}
						if (chr.name == "DrDecayP") {
							MasterGameManager.instance.AddCharacter (3, "DrDecay");
						}
						if (chr.name == "WynkP") {
							MasterGameManager.instance.AddCharacter (3, "Wynk");
						}
						if (chr.name == "Blank") {
							Debug.Log ("added null");
							MasterGameManager.instance.AddCharacter (3, "Empty");
						}
					}

					foreach (Sprite chr in player4Characters) {
						print (chr.name);
						if (chr.name == "BrogreP") {
							MasterGameManager.instance.AddCharacter (4, "Brogre");
						}
						if (chr.name == "SkeletonP") {
							MasterGameManager.instance.AddCharacter (4, "Skelly");
						}
						if (chr.name == "TinyP") {
							MasterGameManager.instance.AddCharacter (4, "Tiny");
						}
						if (chr.name == "GorgonP") {
							MasterGameManager.instance.AddCharacter (4, "Neredy");
						}
						if (chr.name == "SuccP") {
							MasterGameManager.instance.AddCharacter (4, "Succ");
						}
						if (chr.name == "ClaymondP") {
							MasterGameManager.instance.AddCharacter (4, "Claymond");
						}
						if (chr.name == "GuyP") {
							MasterGameManager.instance.AddCharacter (4, "Guy");
						}
						if (chr.name == "DrDecayP") {
							MasterGameManager.instance.AddCharacter (4, "DrDecay");
						}
						if (chr.name == "WynkP") {
							MasterGameManager.instance.AddCharacter (4, "Wynk");
						}
						if (chr.name == "Blank") {
							Debug.Log ("added null");
							MasterGameManager.instance.AddCharacter (4, "Empty");
						}
					}
				}
			}


			buttonManagerObject.GetComponent<ButtonManager> ().LevelSelect ();
		}
	}





}
