using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DummyHealth : MonoBehaviour {

	// Use this for initialization

	public float currentHealth = 0f;
	public float maxHealth = 50f;
	public Image healthBarFront;
	public Image healthBarBack;

	public float calcHealth;
	public GameObject healthPanel;
	public bool healthBarActive = true;
	float healthBarTimer = 2.5f;

	public bool invincible = false;
	public float invincibleTimer = 2f;

	public GameObject model;
	public int playerNum;

	public GameObject mainCam;

	public Color defHealthColor;

	public GameObject createdThing;

	public Transform dummySpawn;

	public Animator dummy;

	void Start () {
		
		//matchManagerObject = GameObject.Find ("MatchManager");
		healthBarActive = true;
		currentHealth = maxHealth;
		mainCam = GameObject.Find ("CameraHolder");
		//healthBar = gameObject.transform.FindChild("Canvas").transform.FindChild("HealthBar").gameObject.GetComponent<Image>();

		dummySpawn = GameObject.Find ("DummySpawn").transform;

		healthBarFront = gameObject.transform.Find("HealthCanvas").transform.Find("HealthBarBack").Find("HealthBarFront").gameObject.GetComponent<Image>();
		defHealthColor = healthBarFront.color;
		healthBarBack = gameObject.transform.Find("HealthCanvas").transform.Find("HealthBarBack").gameObject.GetComponent<Image>();



		healthBarFront.transform.localScale = new Vector3 (Mathf.Clamp (maxHealth, 0f, 1f), healthBarFront.transform.localScale.y, healthBarFront.transform.localScale.z);
		model = this.gameObject.transform.Find ("RotationPoint").Find ("Model").gameObject;

		GetHit (0);
	}

	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < -50f) {

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
			if (!dummy.GetCurrentAnimatorStateInfo (0).IsName ("DefeatAnimation")) {
				dummy.Play ("DefeatAnimation", 0, 0f);
			}
				this.GetComponent<PlayerMovement> ().StartCoroutine ("Rumble");
			}



			calcHealth = currentHealth / maxHealth;
			healthBarFront.transform.localScale = new Vector3 (Mathf.Clamp (calcHealth, 0f, 1f), healthBarFront.transform.localScale.y, healthBarFront.transform.localScale.z);
			healthBarActive = true;
			healthBarFront.enabled = true;
			healthBarBack.enabled = true;
			if (currentHealth <= 0f) {
				currentHealth = 0f;
				StopAllCoroutines ();
			
				Death ();
				createdThing = Instantiate (Resources.Load ("Characters/Dummy"), dummySpawn.position, dummySpawn.rotation) as GameObject;
				Destroy (this.gameObject);
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

		//this.transform.Translate (0, -100f, 0);

	}
		
}
		
