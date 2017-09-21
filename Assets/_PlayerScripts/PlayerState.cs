using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

	public int teamNum = 1;
	public bool isMoving = false;
	public bool isStunned = false;
	public bool isSlowed = false;

	public float stunTimer = 2f;
	public float slowTimer = 2f;

	public float origSpeed;
	// Use this for initialization
	void Start () {
		origSpeed = this.GetComponent<PlayerMovement> ().speed;

		//TEMP CODE
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
	
	// Update is called once per frame
	void Update () {

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
				this.GetComponent<PlayerMovement> ().speed = origSpeed;
			}

		}
		
	}
	public void OnCollisionEnter(Collision col){

	}

	public void InflictStun(float howLong){
		isStunned = true;
		stunTimer = howLong;
		this.GetComponent<PlayerMovement> ().speed = 0;
	}

	public void InflictSlowed(float howLong){
		isSlowed = true;
		slowTimer = howLong;
		this.GetComponent<PlayerMovement> ().speed = this.GetComponent<PlayerMovement> ().speed / 2f;
	}

}
