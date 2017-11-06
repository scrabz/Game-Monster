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






	void Start () {
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


		if (invincible) {
			invincibleTimer -= Time.deltaTime;
			if (invincibleTimer % 2 == 0) {
				model.GetComponent<Renderer> ().material.color = Color.white;
			} else {
				model.GetComponent<Renderer> ().material.color = Color.gray;
			}

			if (invincibleTimer <= 0) {
				model.GetComponent<Renderer> ().material.color = Color.white;
				invincible = false;
				invincibleTimer = 2f;
			}
		}



	}
		



	public void GetHit(float healthLost){
		if (this.GetComponent<PlayerAbilities> ().doingAbil2 == false) {
			//Subtract the Lost Health
			currentHealth -= healthLost;
			if (healthLost != 0) {
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

			if (currentHealth <= 0f) {
				currentHealth = 0f;
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
		this.GetComponent<PlayerState> ().isDying = true;
		this.transform.Translate (0, -100f, 0);

	}
}
		
