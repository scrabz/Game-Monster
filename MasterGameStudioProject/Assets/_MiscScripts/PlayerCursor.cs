using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;



public class PlayerCursor : MonoBehaviour {


	public InputDevice currentJoystick;

	public RaycastHit hit;
	public float hMovement;
	public float vMovement;
	float mouseSpeed = 8f;
	public bool aButton;
	public bool bButton;
	public bool startButton;
	public bool xButton;
	public GameObject characterSelectObject;
	public GameObject buttonManagerObject;
	public int currentPlayer;

	// Use this for initialization
	void Start () {
		buttonManagerObject = GameObject.Find ("ButtonManager");
		characterSelectObject = GameObject.Find ("CharacterSelectManager");


		if (this.gameObject.tag == "Player1") {
			currentPlayer = 1;
			if (InputManager.Devices [0] != null) {
				currentJoystick = InputManager.Devices [0];
			} else {
				currentJoystick = null;
			}
		}
		if (this.gameObject.tag == "Player2") {
			currentPlayer = 2;
			if (InputManager.Devices [1] != null) {
				currentJoystick = InputManager.Devices [1];
			}
		}
		if (this.gameObject.tag == "Player3") {
			currentPlayer = 3;
			if (InputManager.Devices [2] != null) {
				currentJoystick = InputManager.Devices [2];
			}
		}
		if (this.gameObject.tag == "Player4") {
			currentPlayer = 4;
			if (InputManager.Devices [3] != null) {
				currentJoystick = InputManager.Devices [3];
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
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

		//Debug.DrawRay (this.transform.position, transform.forward);
		if (aButton) {
			if (Physics.Raycast(transform.position, transform.forward, out hit,500f)){
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
					characterSelectObject.GetComponent<CharacterSelectAction> ().FinalizeTeams();

				}


			}

		}
		if (startButton) {
			characterSelectObject.GetComponent<CharacterSelectAction> ().FinalizeTeams ();
		}
		if (bButton) {
			characterSelectObject.GetComponent<CharacterSelectAction> ().RemoveLastCharacter (currentPlayer);
		}


		this.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (this.GetComponent<RectTransform> ().anchoredPosition.x + (hMovement * mouseSpeed), this.GetComponent<RectTransform> ().anchoredPosition.y + (vMovement * mouseSpeed), -10f);

	}
}
