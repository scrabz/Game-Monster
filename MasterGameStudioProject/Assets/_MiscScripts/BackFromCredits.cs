using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;
using UnityEngine.SceneManagement;


public class BackFromCredits : MonoBehaviour {


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
	// Use this for initialization
	void Start () {
		currentJoystick = InputManager.Devices[0];


	}
	
	// Update is called once per frame
	void FixedUpdate () {

	

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

		if (bButton) {
			SceneManager.LoadScene ("Menu");
		}

}
}
