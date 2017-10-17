using UnityEngine;
using System.Collections;
using InControl;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour {

	public float speed = 6.0F;
	public float gravity = 20.0F;

	public bool isDying = false;
	public bool canMove = true;
	public bool canRotate = true;
	float dyingTimer = 0.7f;

	public float hMovement;
	public float vMovement;
	public bool rollButton;



	RaycastHit hit;
	public float dist = 2f;
	public Vector3 downDir;
	public Vector3 oldPosition;

	public float rollTimer = 0.3f;
	public float rollTimerDef = 0.3f;
	public float rollTimerCool = 1f;
	public float rollTimerCoolDef = 1f;
	public bool isRolling = false;
	public bool isRollCooling = false;
	public Vector3 rollDirection;

	public Vector3 moveDirection = Vector3.zero;
	public CharacterController controller;

	public GameObject matchManager;

	public float stunTimer;

	public InputDevice currentJoystick;

	public Image staminaBack;
	public Image staminaFront;
	public float calcRecoverTime;

	public GameObject thisModel;

	void Start() {
		rollTimer = rollTimerDef;
		controller = this.GetComponent<CharacterController> ();
		matchManager = GameObject.Find ("MatchManager");
		thisModel = this.transform.Find("RotationPoint").Find("Model").gameObject;
		downDir = new Vector3 (0, -1, 0);

		if (this.gameObject.tag == "Player1") {
			if (InputManager.Devices [0] != null) {
				currentJoystick = InputManager.Devices [0];
			}
		}
		if (this.gameObject.tag == "Player2") {
			if (InputManager.Devices [1] != null) {
				currentJoystick = InputManager.Devices [1];
			}
		}
		if (this.gameObject.tag == "Player3") {
			if (InputManager.Devices [2] != null) {
				currentJoystick = InputManager.Devices [2];
			}
		}
		if (this.gameObject.tag == "Player4") {
			if (InputManager.Devices [3] != null) {
				currentJoystick = InputManager.Devices [3];
			}
		}
		staminaFront = gameObject.transform.Find("HealthCanvas").transform.Find("StaminaBack").Find("StaminaFront").gameObject.GetComponent<Image>();
		staminaBack = gameObject.transform.Find("HealthCanvas").transform.Find("StaminaBack").gameObject.GetComponent<Image>();
		staminaBack.enabled = false;
		staminaFront.enabled = false;
	}

	void Update() {

		if (matchManager != null) {
			if (matchManager.GetComponent<MatchManager> ().isCountingDown) {
				canMove = false;
			} else {
				canMove = true;
			}
		}

		if (currentJoystick != null && canMove) {
			if (matchManager != null) {
				if (!matchManager.GetComponent<MatchManager> ().isCountingDown) {
					hMovement = Mathf.RoundToInt(currentJoystick.LeftStickX.RawValue);
					vMovement = Mathf.RoundToInt(currentJoystick.LeftStickY.RawValue);
					rollButton = currentJoystick.Action1.WasPressed;
				}
			} else {
				hMovement = Mathf.RoundToInt(currentJoystick.LeftStickX.RawValue);
				vMovement =  Mathf.RoundToInt(currentJoystick.LeftStickY.RawValue);
				rollButton = currentJoystick.Action1.WasPressed;
			}
		}



		oldPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		if (stunTimer > 0) {
			stunTimer -= Time.deltaTime;

		}

		if (isRolling) {
			//Temp Code
			//thisModel.transform.Rotate(0,0,40f * Time.deltaTime);
			//thisModel.transform.Rotate(Vector3.up * Time.deltaTime,Space.World);
			controller.Move (rollDirection * Time.deltaTime * (speed * 6f));
			rollTimer -= Time.deltaTime;
			if (rollTimer <= 0) {
				isRolling = false;
				isRollCooling = true;
				rollTimer = rollTimerDef;
				//thisModel.transform.rotation = Quaternion.identity;
			}

		}

		if (isRollCooling) {
			calcRecoverTime =  1f - (rollTimerCool / rollTimerCoolDef);
			staminaBack.enabled = true;
			staminaFront.enabled = true;
			staminaFront.transform.localScale = new Vector3 (Mathf.Clamp (calcRecoverTime, 0f, 1f), staminaFront.transform.localScale.y, staminaFront.transform.localScale.z);
			rollTimerCool -= Time.deltaTime;
			if (rollTimerCool <= 0) {
				isRollCooling = false;
				rollTimerCool = rollTimerCoolDef;
				staminaBack.enabled = false;
				staminaFront.enabled = false;
			}

		}


		if (stunTimer <= 0) {
			canMove = true;

		}



		if (isDying == true) {
			dyingTimer -= Time.deltaTime;
			if (dyingTimer <= 0) {
				Die ();
			}
		}

	

		if (isDying == false && canMove == true) {
			
		
			//if (controller.isGrounded) {
			if (rollButton && !isRolling && !isRollCooling && !this.GetComponent<PlayerState>().isSlowed && !this.GetComponent<PlayerAbilities>().abilityActive) {
				isRolling = true;
				rollDirection = this.transform.Find ("RotationPoint").forward;
				}
				if (isRolling == false) {
				moveDirection = new Vector3 (hMovement, 0, vMovement);
					moveDirection = transform.TransformDirection (moveDirection);
					moveDirection *= speed;
					moveDirection.y -= gravity * Time.deltaTime;
				if (this.GetComponent<PlayerAbilities> ().abilityActive) {
					controller.Move ((moveDirection / 1.5f) * Time.deltaTime);
				} else {
					controller.Move (moveDirection * Time.deltaTime);
				}
				}
			//}

		}



		if (Physics.Raycast (transform.position, downDir, out hit, dist)) {
			if (hit.collider.tag == "Ground") {
				
			}
		} else {
			this.transform.position = new Vector3(oldPosition.x, oldPosition.y, oldPosition.z);
		}



	}

	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "InstantDeath") {
			isDying = true;
		}
		if (col.gameObject.tag == "Projectile") {

		}

	}

	public void Stun(float stunTime){
		stunTimer = stunTime;
		canMove = false;

	}

	public void Die(){
		Destroy (this.gameObject);
		if (matchManager != null) {
			//matchManager.GetComponent<MatchManager> ().AddDeath (this.gameObject);
		} else {
			Debug.Log ("MatchManager was null");
		}
	}

	public IEnumerator Rumble(){
		currentJoystick.Vibrate (0.3f);
		yield return new WaitForSeconds(0.3f);
		currentJoystick.StopVibration ();
	}
}
