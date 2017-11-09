using UnityEngine;
using System.Collections;
using InControl;

public class PlayerRotation : MonoBehaviour {
	public float hMovementR;
	public float vMovementR;
	public float angle;

	public InputDevice currentJoystick;

	public GameObject parentObject;

	// Use this for initialization
	void Start () {
		parentObject = transform.parent.gameObject;

		if (parentObject.gameObject.tag == "Player1") {
			if (InputManager.Devices [0] != null) {
				currentJoystick = InputManager.Devices [0];
			}
		}
		if (parentObject.gameObject.tag == "Player2") {
			if (InputManager.Devices [1] != null) {
				currentJoystick = InputManager.Devices [1];
			}
		}
		if (parentObject.gameObject.tag == "Player3") {
			if (InputManager.Devices [2] != null) {
				currentJoystick = InputManager.Devices [2];
			}
		}
		if (parentObject.gameObject.tag == "Player4") {
			if (InputManager.Devices [3] != null) {
				currentJoystick = InputManager.Devices [3];
			}
		}

		//var inputDevice = (InputManager.Devices.Count > this.GetComponent<PlayerState>().teamNum) ? InputManager.Devices[this.GetComponent<PlayerState>().teamNum] : null;


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (parentObject.GetComponent<PlayerMovement> ().canRotate) {
			if (currentJoystick != null) {
				hMovementR = currentJoystick.RightStickX;
				vMovementR = currentJoystick.RightStickY;

			}
			

			if (parentObject.GetComponent<PlayerState> ().isDying == false && parentObject.GetComponent<PlayerMovement> ().isRolling == false) {
				if (hMovementR != 0f || vMovementR != 0f) {
					angle = Mathf.Atan2 (vMovementR, hMovementR) * Mathf.Rad2Deg;
				} else {
					if (Mathf.RoundToInt (parentObject.GetComponent<PlayerMovement> ().hMovement) != 0 || Mathf.RoundToInt (parentObject.GetComponent<PlayerMovement> ().vMovement) != 0) {
						angle = Mathf.Atan2 (parentObject.GetComponent<PlayerMovement> ().vMovement, parentObject.GetComponent<PlayerMovement> ().hMovement) * Mathf.Rad2Deg;
					}
				}
			
				transform.rotation = Quaternion.Lerp (this.transform.rotation, Quaternion.AngleAxis (90f - angle, Vector3.up), 10f * Time.deltaTime);

		
			}
		}
	}





}
