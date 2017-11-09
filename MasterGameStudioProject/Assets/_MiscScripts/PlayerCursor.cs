using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;
using UnityEngine.SceneManagement;


public class PlayerCursor : MonoBehaviour {


	public InputDevice currentJoystick;

	public RaycastHit hit;
	public float hMovement;
	public float vMovement;
	float mouseSpeed = 12f;
	public bool aButton;
	public bool bButton;
	public bool startButton;
	public bool xButton;
	public GameObject characterSelectObject;
	public GameObject buttonManagerObject;
	public int currentPlayer;

	public Image cardPanel;

	public Sprite brogreCard;
	public Sprite skeletonCard;
	public Sprite gorgonCard;
	public Sprite drDecayCard;
	public Sprite tinyCard;
	public Sprite succCard;
	public Sprite guyCard;
	public Sprite geoCard;
	public Sprite blankCard;

	public Vector3 oldPosition;

	public Rect screenRect;
	public bool canMoveCursor = true;
	// Use this for initialization
	void Start () {

		screenRect = new Rect(0f, 0f, Screen.width, Screen.height);

		brogreCard = Resources.Load<Sprite> ("CharacterCards/BrogreCard");
		tinyCard = Resources.Load<Sprite> ("CharacterCards/TinyCard");
		skeletonCard = Resources.Load<Sprite> ("CharacterCards/SkeletonCard");
		drDecayCard = Resources.Load<Sprite> ("CharacterCards/DrDecayCard");
		succCard = Resources.Load<Sprite> ("CharacterCards/SuccCard");
		guyCard = Resources.Load<Sprite> ("CharacterCards/GuyCard");
		geoCard = Resources.Load<Sprite> ("CharacterCards/GeoCard");
		gorgonCard = Resources.Load<Sprite> ("CharacterCards/GorgonCard");
		blankCard = Resources.Load<Sprite>("CharacterCards/BlankCard");
		buttonManagerObject = GameObject.Find ("ButtonManager");
		characterSelectObject = GameObject.Find ("CharacterSelectManager");


		if (this.gameObject.tag == "Player1") {
			currentPlayer = 1;
			if (InputManager.Devices [0] != null) {
				cardPanel = GameObject.Find ("P1CardPanel").GetComponent<Image> ();

				currentJoystick = InputManager.Devices [0];
			} 
		}
		if (this.gameObject.tag == "Player2") {
			currentPlayer = 2;
			if (InputManager.Devices [1] != null) {
				cardPanel = GameObject.Find ("P2CardPanel").GetComponent<Image> ();
				currentJoystick = InputManager.Devices [1];
			}
		}
		if (this.gameObject.tag == "Player3") {
			currentPlayer = 3;
			if (InputManager.Devices [2] != null) {
				cardPanel = GameObject.Find ("P3CardPanel").GetComponent<Image> ();
				currentJoystick = InputManager.Devices [2];
			}
		}
		if (this.gameObject.tag == "Player4") {
			currentPlayer = 4;
			if (InputManager.Devices [3] != null) {
				cardPanel = GameObject.Find ("P4CardPanel").GetComponent<Image> ();
				currentJoystick = InputManager.Devices [3];
			}
		}
		cardPanel.enabled = false;

		//var inputDevice = (InputManager.Devices.Count > currentPlayer) ? InputManager.Devices[currentPlayer] : null;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3[] objectCorners = new Vector3[4];
		this.GetComponent<RectTransform>().GetWorldCorners(objectCorners);

		if (currentJoystick != null) {
			hMovement = currentJoystick.LeftStickX.RawValue;
			vMovement = currentJoystick.LeftStickY.RawValue;
			aButton = currentJoystick.Action1.WasPressed;
			bButton = currentJoystick.Action2.WasPressed;
			startButton = currentJoystick.Command.WasPressed;
		} else {
			hMovement = Input.GetAxis("Horizontal");
			vMovement = Input.GetAxis("Vertical");
			aButton = Input.GetButtonDown ("Space");
			bButton = Input.GetButtonDown ("Backspace");
			startButton = Input.GetButtonDown ("Enter");
		}
		if (Physics.Raycast (transform.position, transform.forward, out hit, 500f)) {
			if (hit.collider.gameObject.name == "BrogreButton") {
				cardPanel.sprite = brogreCard;
				cardPanel.enabled = true;
			}
			if (hit.collider.gameObject.name == "SkeletonButton") {
				cardPanel.sprite = skeletonCard;
				cardPanel.enabled = true;
			}

			if (hit.collider.gameObject.name == "TinyButton") {
				cardPanel.sprite = tinyCard;
				cardPanel.enabled = true;
			}

			if (hit.collider.gameObject.name == "SuccButton") {
				cardPanel.sprite = succCard;
			}

			if (hit.collider.gameObject.name == "GuyButton") {
				cardPanel.sprite = guyCard;
			}

			if (hit.collider.gameObject.name == "ClaymondButton") {
				cardPanel.sprite = geoCard;
			}

			if (hit.collider.gameObject.name == "GorgonButton") {
				cardPanel.sprite = gorgonCard;
				cardPanel.enabled = true;
			}
			if (hit.collider.gameObject.name == "DrDecayButton") {
				cardPanel.enabled = true;
				cardPanel.sprite = drDecayCard;
			}
		} else {
			//cardPanel.sprite = blankCard;
		}

		//Debug.DrawRay (this.transform.position, transform.forward);
		if (aButton) {
			if (Physics.Raycast(transform.position, transform.forward, out hit,500f)){

				if (hit.collider.gameObject.name == "StartGameButton") {
					hit.collider.gameObject.GetComponent<ButtonClick> ().TaskOnClick ();
				}


				if (hit.collider.gameObject.name == "BrogreButton") {
					hit.collider.gameObject.GetComponent<ButtonClick> ().TaskOnClick ();
					characterSelectObject.GetComponent<CharacterSelectAction> ().AddCharacter (currentPlayer, "Brogre");
				}
				if (hit.collider.gameObject.name == "SkeletonButton") {
					hit.collider.gameObject.GetComponent<ButtonClick> ().TaskOnClick ();
					characterSelectObject.GetComponent<CharacterSelectAction> ().AddCharacter (currentPlayer, "Skelly");
				}

				if (hit.collider.gameObject.name == "TinyButton") {
					hit.collider.gameObject.GetComponent<ButtonClick> ().TaskOnClick ();
					characterSelectObject.GetComponent<CharacterSelectAction> ().AddCharacter (currentPlayer, "Tiny");
				}

				if (hit.collider.gameObject.name == "SuccButton") {
					hit.collider.gameObject.GetComponent<ButtonClick> ().TaskOnClick ();
					characterSelectObject.GetComponent<CharacterSelectAction> ().AddCharacter (currentPlayer, "Succ");
				}

				if (hit.collider.gameObject.name == "GuyButton") {
					hit.collider.gameObject.GetComponent<ButtonClick> ().TaskOnClick ();
					characterSelectObject.GetComponent<CharacterSelectAction> ().AddCharacter (currentPlayer, "Guy");
				}

				if (hit.collider.gameObject.name == "ClaymondButton") {
					hit.collider.gameObject.GetComponent<ButtonClick> ().TaskOnClick ();
					characterSelectObject.GetComponent<CharacterSelectAction> ().AddCharacter (currentPlayer, "Claymond");
				}

				if (hit.collider.gameObject.name == "GorgonButton") {
					hit.collider.gameObject.GetComponent<ButtonClick> ().TaskOnClick ();
					characterSelectObject.GetComponent<CharacterSelectAction> ().AddCharacter (currentPlayer, "Gorgon");
				}
				if (hit.collider.gameObject.name == "DrDecayButton") {
					hit.collider.gameObject.GetComponent<ButtonClick> ().TaskOnClick ();
					characterSelectObject.GetComponent<CharacterSelectAction> ().AddCharacter (currentPlayer, "DrDecay");
				}
				if (hit.collider.gameObject.name == "WynkButton") {
					hit.collider.gameObject.GetComponent<ButtonClick> ().TaskOnClick ();
					characterSelectObject.GetComponent<CharacterSelectAction> ().AddCharacter (currentPlayer, "Wynk");
				}

				if (hit.collider.gameObject.name == "StartBut") {
					hit.collider.gameObject.GetComponent<ButtonClick> ().TaskOnClick ();
					buttonManagerObject.GetComponent<ButtonManager> ().StartVersusMatch ();
				}
				if (hit.collider.gameObject.name == "VolcanoButton") {
					hit.collider.gameObject.GetComponent<ButtonClick> ().TaskOnClick ();
					SceneManager.LoadScene ("VolcanoLevel");
				}

				if (hit.collider.gameObject.name == "HallOfBrosButton") {
					hit.collider.gameObject.GetComponent<ButtonClick> ().TaskOnClick ();
					SceneManager.LoadScene ("HallOfBrosLevel");
				}


				if (hit.collider.gameObject.name == "ChangeMode") {
					hit.collider.gameObject.GetComponent<ButtonClick> ().TaskOnClick ();
					buttonManagerObject.GetComponent<ButtonManager> ().ChangeMode ();
				}

				if (hit.collider.gameObject.name == "DecreaseTeam") {
					hit.collider.gameObject.GetComponent<ButtonClick> ().TaskOnClick ();
					characterSelectObject.GetComponent<CharacterSelectAction> ().ChangeTeamSize(-1);
				}
				if (hit.collider.gameObject.name == "IncreaseTeam") {
					hit.collider.gameObject.GetComponent<ButtonClick> ().TaskOnClick ();
					characterSelectObject.GetComponent<CharacterSelectAction> ().ChangeTeamSize(1);
				}
				if (hit.collider.gameObject.name == "BackButton") {
					hit.collider.gameObject.GetComponent<ButtonClick> ().TaskOnClick ();
					buttonManagerObject.GetComponent<ButtonManager> ().BackFromCharacterSelect();
				}
				if (hit.collider.gameObject.name == "LevelSelectButton") {
					hit.collider.gameObject.GetComponent<ButtonClick> ().TaskOnClick ();
					characterSelectObject.GetComponent<CharacterSelectAction> ().FinalizePlayers();

				}


			}

		}
		if (startButton) {
			characterSelectObject.GetComponent<CharacterSelectAction> ().FinalizePlayers ();
		}
		if (bButton) {
			characterSelectObject.GetComponent<CharacterSelectAction> ().RemoveLastCharacter (currentPlayer);
		}

		this.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (Mathf.Clamp(this.GetComponent<RectTransform> ().anchoredPosition.x + (hMovement * mouseSpeed), 16, this.transform.parent.GetComponent<RectTransform>().rect.width - 16), Mathf.Clamp(this.GetComponent<RectTransform> ().anchoredPosition.y + (vMovement * mouseSpeed), 16, this.transform.parent.GetComponent<RectTransform>().rect.height - 16), -10f);


		oldPosition = this.GetComponent<RectTransform> ().anchoredPosition;


		//this.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (this.GetComponent<RectTransform> ().anchoredPosition.x + (hMovement * mouseSpeed), this.GetComponent<RectTransform> ().anchoredPosition.y + (vMovement * mouseSpeed), -10f);

//		foreach (Vector3 corner in objectCorners) {
//			if (!screenRect.Contains (corner)) {
//				//this.GetComponent<RectTransform> ().anchoredPosition = oldPosition + new Vector3(screenRect.center.magnitude,screenRect.center.magnitude,-10);
//				canMoveCursor = false;
//			}
//		}
//		if (canMoveCursor){
//			this.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (this.GetComponent<RectTransform> ().anchoredPosition.x + (hMovement * mouseSpeed), this.GetComponent<RectTransform> ().anchoredPosition.y + (vMovement * mouseSpeed), -10f);
//		} else {
//			
//			this.GetComponent<RectTransform> ().anchoredPosition = Vector3.MoveTowards (this.GetComponent<RectTransform> ().anchoredPosition, screenRect.center, 0.5f);
//			canMoveCursor = true;
//
//		}


	}
}
