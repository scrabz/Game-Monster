using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	// Use this for initialization

	public float currentHealth = 0f;
	public float maxHealth = 50f;
	public Image healthBarFront;
	public Image healthBarBack;
	public Image panelHealthBarFront;
	public Image panelHealthBarBack;
	public Text healthText;
	public Text maxHealthText;

	public float calcHealth;
	public GameObject healthPanel;
	public bool healthBarActive = true;
	float healthBarTimer = 2.5f;
	public GameObject matchManagerObject;

	public bool invincible = false;
	public float invincibleTimer = 2f;

	public GameObject model;
	public int playerNum;

	public GameObject mainCam;

	public Color defHealthColor;

	public GameObject createdThing;

	public Image currentPortrait;

	public Sprite brFull;
	public Sprite brNeutral;
	public Sprite brLow;
	public Sprite brDead;


	void Start () {
		if (this.gameObject.name == "Brogre(Clone)") {
			brFull = Resources.Load<Sprite> ("CharacterPortraits/BrFull");
			brNeutral = Resources.Load<Sprite> ("CharacterPortraits/BrNeutral");
			brLow = Resources.Load<Sprite> ("CharacterPortraits/BrLow");
			brDead = Resources.Load<Sprite> ("CharacterPortraits/BrDead");


		}

		if (this.gameObject.name == "ToeTip(Clone)") {
			brFull = Resources.Load<Sprite> ("CharacterPortraits/GaFull");
			brNeutral = Resources.Load<Sprite> ("CharacterPortraits/GaNeutral");
			brLow = Resources.Load<Sprite> ("CharacterPortraits/GaLow");
			brDead = Resources.Load<Sprite> ("CharacterPortraits/GaDead");


		}

		if (this.gameObject.name == "Tiny(Clone)") {
			brFull = Resources.Load<Sprite> ("CharacterPortraits/TiFull");
			brNeutral = Resources.Load<Sprite> ("CharacterPortraits/TiNeutral");
			brLow = Resources.Load<Sprite> ("CharacterPortraits/TiLow");
			brDead = Resources.Load<Sprite> ("CharacterPortraits/TiDead");


		}

		if (this.gameObject.name == "Neredy(Clone)") {
			brFull = Resources.Load<Sprite> ("CharacterPortraits/NeFull");
			brNeutral = Resources.Load<Sprite> ("CharacterPortraits/NeNeutral");
			brLow = Resources.Load<Sprite> ("CharacterPortraits/NeLow");
			brDead = Resources.Load<Sprite> ("CharacterPortraits/NeDead");


		}

		if (this.gameObject.name == "DrDecay(Clone)") {
			brFull = Resources.Load<Sprite> ("CharacterPortraits/DeFull");
			brNeutral = Resources.Load<Sprite> ("CharacterPortraits/DeNeutral");
			brLow = Resources.Load<Sprite> ("CharacterPortraits/DeLow");
			brDead = Resources.Load<Sprite> ("CharacterPortraits/DeDead");


		}

		if (this.gameObject.name == "Guy(Clone)") {
			brFull = Resources.Load<Sprite> ("CharacterPortraits/GuFull");
			brNeutral = Resources.Load<Sprite> ("CharacterPortraits/GuNeutral");
			brLow = Resources.Load<Sprite> ("CharacterPortraits/GuLow");
			brDead = Resources.Load<Sprite> ("CharacterPortraits/GuDead");


		}

		if (this.gameObject.name == "Iris(Clone)") {
			brFull = Resources.Load<Sprite> ("CharacterPortraits/IrFull");
			brNeutral = Resources.Load<Sprite> ("CharacterPortraits/IrNeutral");
			brLow = Resources.Load<Sprite> ("CharacterPortraits/IrLow");
			brDead = Resources.Load<Sprite> ("CharacterPortraits/IrDead");


		}

		if (this.gameObject.name == "Claymond(Clone)") {
			brFull = Resources.Load<Sprite> ("CharacterPortraits/GeFull");
			brNeutral = Resources.Load<Sprite> ("CharacterPortraits/GeNeutral");
			brLow = Resources.Load<Sprite> ("CharacterPortraits/GeLow");
			brDead = Resources.Load<Sprite> ("CharacterPortraits/GeDead");


		}
		//matchManagerObject = GameObject.Find ("MatchManager");
		healthBarActive = true;
		currentHealth = maxHealth;
		mainCam = GameObject.Find ("CameraHolder");
		//healthBar = gameObject.transform.FindChild("Canvas").transform.FindChild("HealthBar").gameObject.GetComponent<Image>();

		matchManagerObject = GameObject.Find ("MatchManager");

		if (this.gameObject.tag == "Player1") {
			healthPanel = GameObject.Find ("P1Panel");
			playerNum = 1;
		}
		if (this.gameObject.tag == "Player2") {
			healthPanel = GameObject.Find ("P2Panel");
			playerNum = 2;
		}
		if (this.gameObject.tag == "Player3") {
			healthPanel = GameObject.Find ("P3Panel");
			playerNum = 3;
		}
		if (this.gameObject.tag == "Player4") {
			playerNum = 4;
			healthPanel = GameObject.Find ("P4Panel");
		}

		healthBarFront = gameObject.transform.Find("HealthCanvas").transform.Find("HealthBarBack").Find("HealthBarFront").gameObject.GetComponent<Image>();
		defHealthColor = healthBarFront.color;
		healthBarBack = gameObject.transform.Find("HealthCanvas").transform.Find("HealthBarBack").gameObject.GetComponent<Image>();
		healthText = healthPanel.transform.Find ("HealthNum").GetComponent<Text> ();
		maxHealthText = healthPanel.transform.Find ("MaxHealthNum").GetComponent<Text> ();
		panelHealthBarFront = healthPanel.transform.Find ("HealthBarBack").Find ("HealthBarFront").gameObject.GetComponent<Image> ();
		panelHealthBarBack = healthPanel.transform.Find ("HealthBarBack").gameObject.GetComponent<Image> ();



		healthBarFront.transform.localScale = new Vector3 (Mathf.Clamp (maxHealth, 0f, 1f), healthBarFront.transform.localScale.y, healthBarFront.transform.localScale.z);
		model = this.gameObject.transform.Find ("RotationPoint").Find ("Model").gameObject;
		maxHealthText.text = maxHealth.ToString ();

		//currentPortrait = healthPanel.transform.Find ("ChrPortrait").gameObject.GetComponent<Image> ();
		currentPortrait = healthPanel.transform.GetChild(8).gameObject.GetComponent<Image> ();

		GetHit (0);
	}

	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < -50f) {
			if (matchManagerObject != null) {
				//matchManagerObject.GetComponent<MatchManager> ().SubtractPlayer (playerNum);
			}

			//Destroy (this.gameObject);
		}


		if (healthBarActive) {
			healthBarTimer -= Time.deltaTime;
			if (healthBarTimer <= 0f) {
				healthBarFront.enabled = false;
				healthBarBack.enabled = false;
				healthBarActive = false;
			}
		}
			



	}
		



	public void GetHit(float healthLost){
		if (this.GetComponent<PlayerAbilities> ().doingAbil2 == false && this.GetComponent<PlayerState>().isDying == false && this.GetComponent<PlayerState>().isInvincible == false) {
			//Subtract the Lost Health
			if (this.GetComponent<PlayerState> ().isWeakened) {
				healthLost = healthLost * 1.5f;
			}
			currentHealth -= healthLost;
			if (currentHealth > maxHealth) {
				currentHealth = maxHealth;
			}

			if (healthLost > 0.9f) {
				transform.Find ("RotationPoint").GetComponent<AudioSource> ().Play ();
				createdThing = Instantiate (Resources.Load ("Particles/NewGetHit"), this.transform.position, this.transform.rotation) as GameObject;
			}
			if (healthLost > 0) {
				StartCoroutine ("FlashRed");
				this.GetComponent<PlayerMovement> ().StartCoroutine ("Rumble");
			}



			calcHealth = currentHealth / maxHealth;
			healthText.text = currentHealth.ToString ("####");
			healthBarFront.transform.localScale = new Vector3 (Mathf.Clamp (calcHealth, 0f, 1f), healthBarFront.transform.localScale.y, healthBarFront.transform.localScale.z);
			panelHealthBarFront.transform.localScale = new Vector3 (Mathf.Clamp (calcHealth, 0f, 1f), healthBarFront.transform.localScale.y, healthBarFront.transform.localScale.z);
			healthBarTimer = 2.5f;
			healthBarActive = true;
			healthBarFront.enabled = true;
			healthBarBack.enabled = true;
			SwitchPortrait ();
			if (currentHealth <= 0f) {
				currentHealth = 0f;
				healthText.text = currentHealth.ToString ("####");
				StopAllCoroutines ();
				this.GetComponent<PlayerMovement> ().currentJoystick.StopVibration ();
				Death ();
				if (matchManagerObject == null) {
					SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
				} else {
					mainCam.gameObject.GetComponent<DynamicCamera> ().RemovePlayerFromView (this.gameObject);
				}

			}
		}

	}
		

	public IEnumerator FlashRed(){
		foreach(Renderer variableName in GetComponentsInChildren<Renderer>()){
			variableName.material.color = Color.red;
		}
		yield return new WaitForSeconds(0.2f);
		foreach(Renderer variableName in GetComponentsInChildren<Renderer>()){
			variableName.material.color = Color.white;
		}
		yield return null;


	}

	public void Death(){
		StopAllCoroutines ();
		this.GetComponent<PlayerMovement> ().matchOver = true;
		this.GetComponent<PlayerState> ().isDying = true;

		if (matchManagerObject != null) {
			//mainCam.gameObject.GetComponent<DynamicCamera> ().RemoveCharacterFromView (characterSpawn);
			foreach(Renderer variableName in GetComponentsInChildren<Renderer>()){
				variableName.material.color = Color.white;
			}
			matchManagerObject.GetComponent<MatchManager> ().SubtractCharacter (this.GetComponent<PlayerState>().playerNum);

		}
		//this.transform.Translate (0, -100f, 0);

	}

	public void SwitchPortrait(){

			if (currentHealth / maxHealth <= 0) {
				currentPortrait.sprite = brDead;
			}
			if (currentHealth / maxHealth >= 0.25f) {
				currentPortrait.sprite = brLow;
			}

			if (currentHealth / maxHealth >= 0.50f) {
				currentPortrait.sprite = brNeutral;
			}

			if (currentHealth / maxHealth >= 0.75f) {
				currentPortrait.sprite = brFull;
			}


		}
}
		
