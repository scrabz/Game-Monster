using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour {

	public int teamNum = 1;
	public bool isMoving = false;
	public bool isStunned = false;
	public bool isSlowed = false;
	public bool isBeingPushed = false;


	public Vector3 pushDir;

	public float stunTimer = 2f;
	public float slowTimer = 2f;
	public float pushTimer = 2f;
	public float origSpeed;

	public bool hasTribute = false;

	public GameObject matchManager;

	public Image itemImage;

	public Sprite tributeImg;
	// Use this for initialization

	void Awake(){
		if (this.gameObject.tag == "Player1") {
			teamNum = 1;
		}
		if (this.gameObject.tag == "Player2") {
			teamNum = 2;
		}
		if (this.gameObject.tag == "Player3") {
			teamNum = 3;
		}
		if (this.gameObject.tag == "Player4") {
			teamNum = 4;
		}
	}


	void Start () {
		tributeImg = Resources.Load <Sprite> ("ItemImages/TributeImg");
		itemImage = gameObject.transform.Find("HealthCanvas").transform.Find("ItemImage").gameObject.GetComponent<Image>();
		itemImage.enabled = false;
		origSpeed = this.GetComponent<PlayerMovement> ().speed;
		matchManager = GameObject.Find ("MatchManager");
		//TEMP CODE

	}
	
	// Update is called once per frame
	void Update () {

		if (isBeingPushed) {
			pushTimer -= Time.deltaTime;
			this.GetComponent<CharacterController>().Move(pushDir * 30f * Time.deltaTime);
			if (pushTimer <= 0) {
				isBeingPushed = false;
				this.GetComponent<PlayerMovement> ().speed = origSpeed;
			}

		}


		if (isSlowed) {
			slowTimer -= Time.deltaTime;
			if (slowTimer <= 0) {
				isSlowed = false;
				this.GetComponent<PlayerMovement> ().speed = origSpeed;
			}

		}
		if (isStunned) {
			stunTimer -= Time.deltaTime;
			if (stunTimer <= 0) {
				isStunned = false;
				this.GetComponent<PlayerMovement> ().lockedInPlace = false;
				this.GetComponent<PlayerMovement> ().speed = origSpeed;
			}

		}
		
	}
	public void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Tribute") {
			Destroy (col.gameObject);
			print ("gottribute");
			hasTribute = true;

			itemImage.enabled = true;
			itemImage.sprite = tributeImg;
		}

		if (col.gameObject.tag == "TributeDropOff" && hasTribute) {
			hasTribute = false;
			itemImage.enabled = false;
			print ("thishappened");
			matchManager.GetComponent<MatchManager> ().StartFireRain();
		}
	}

	public void InflictStun(float howLong){
		isStunned = true;
		stunTimer = howLong;
		this.GetComponent<PlayerMovement> ().lockedInPlace = true;
	}

	public void InflictSlowed(float howLong){
		isSlowed = true;
		slowTimer = howLong;
		this.GetComponent<PlayerMovement> ().speed = this.GetComponent<PlayerMovement> ().speed / 2f;
	}

	public void Pushback(float howLong, Vector3 importedDir){
		if (this.GetComponent<PlayerMovement> ().lockedInPlace == false) {
			isBeingPushed = true;
			pushTimer = howLong;
			pushDir = importedDir;
			this.GetComponent<PlayerMovement> ().speed = 0;
		}

	}

}
