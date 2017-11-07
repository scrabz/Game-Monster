﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour {

	public int teamNum = 1;
	public int playerNum = 1;
	public bool isMoving = false;
	public bool isStunned = false;
	public bool isSlowed = false;
	public bool isBeingPushed = false;
	public bool isPoisoned = false;


	public Vector3 pushDir;
	public bool isDying = false;
	public float stunTimer = 2f;
	public float slowTimer = 2f;
	public float pushTimer = 2f;

	public float poisonTimer = 2f;
	public float origSpeed;

	float deathTimer = 2f;

	public bool hasTribute = false;

	public GameObject matchManager;

	public Image itemImage;

	public Sprite tributeImg;

	public Sprite p1indicator;
	public Sprite p2indicator;
	public Sprite p3indicator;
	public Sprite p4indicator;
	// Use this for initialization

	void Awake(){


	}


	void Start () {


		tributeImg = Resources.Load <Sprite> ("ItemImages/TributeImg");
		p1indicator = Resources.Load <Sprite> ("ItemImages/P1indicator");
		p2indicator = Resources.Load <Sprite> ("ItemImages/P2indicator");
		p3indicator = Resources.Load <Sprite> ("ItemImages/P3indicator");
		p4indicator = Resources.Load <Sprite> ("ItemImages/P4indicator");
		itemImage = gameObject.transform.Find("HealthCanvas").transform.Find("ItemImage").gameObject.GetComponent<Image>();

		if (this.gameObject.tag == "Player1") {
			teamNum = 1;
			playerNum = 1;
			itemImage.sprite = p1indicator;
		}
		if (this.gameObject.tag == "Player2") {
			if (MasterGameManager.instance != null) {
				if (MasterGameManager.instance.ffa == true) {
					teamNum = 2;
					itemImage.sprite = p2indicator;
				} else {
					teamNum = 1;
					itemImage.sprite = p1indicator;
				}
			}
			playerNum = 2;
		}
		if (this.gameObject.tag == "Player3") {
			if (MasterGameManager.instance.ffa == true) {
				teamNum = 3;
				itemImage.sprite = p3indicator;
			} else {
				teamNum = 2;
				itemImage.sprite = p2indicator;
			}
			playerNum = 3;
		}
		if (this.gameObject.tag == "Player4") {
			if (MasterGameManager.instance.ffa == true) {
				teamNum = 4;
				itemImage.sprite = p4indicator;
			} else {
				teamNum = 2;
				itemImage.sprite = p2indicator;
			}
			playerNum = 4;
		}


		tributeImg = Resources.Load <Sprite> ("ItemImages/TributeImg");

		//itemImage.enabled = false;
		origSpeed = this.GetComponent<PlayerMovement> ().speed;
		matchManager = GameObject.Find ("MatchManager");


	}
	
	// Update is called once per frame
	void FixedUpdate () {


		if (isDying) {
			deathTimer -= Time.deltaTime;
		
			if (deathTimer <= 0) {
				if (matchManager != null) {
					//mainCam.gameObject.GetComponent<DynamicCamera> ().RemoveCharacterFromView (characterSpawn);
					matchManager.GetComponent<MatchManager> ().SubtractCharacter (playerNum);

				}
				Destroy (this.gameObject);

			}

		}


		if (isBeingPushed) {
			pushTimer -= Time.deltaTime;
			this.GetComponent<CharacterController>().Move(pushDir * 30f * Time.deltaTime);
			if (pushTimer <= 0) {
				isBeingPushed = false;
				this.GetComponent<PlayerMovement> ().speed = origSpeed;
			}

		}

		if (isPoisoned) {
			poisonTimer -= Time.deltaTime;
			this.GetComponent<PlayerHealth> ().GetHit (0.08f);
		
			if (poisonTimer <= 0) {
				isPoisoned = false;
				this.GetComponent<PlayerHealth> ().healthBarFront.color = this.GetComponent<PlayerHealth> ().defHealthColor;
				this.GetComponent<PlayerHealth> ().panelHealthBarFront.color = this.GetComponent<PlayerHealth> ().defHealthColor;
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
		}
	}

	public void InflictStun(float howLong){
		isStunned = true;
		stunTimer = howLong;
		this.GetComponent<PlayerMovement> ().lockedInPlace = true;
	}

	public void InflictPoison(float howLong){
		isPoisoned = true;
		poisonTimer = howLong;
		this.GetComponent<PlayerHealth> ().healthBarFront.color = new Color (0f, 1f, 0f);
		this.GetComponent<PlayerHealth> ().panelHealthBarFront.color = new Color (0f, 1f, 0f);
	}

	public void InflictSlowed(float howLong){
		isSlowed = true;
		slowTimer = howLong;
		this.GetComponent<PlayerMovement> ().speed = this.GetComponent<PlayerMovement> ().speed / 2f;
	}
	public void SpeedBoost(float howLong){
		isSlowed = true;
		slowTimer = howLong;
		this.GetComponent<PlayerMovement> ().speed = this.GetComponent<PlayerMovement> ().speed * 1.4f;
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