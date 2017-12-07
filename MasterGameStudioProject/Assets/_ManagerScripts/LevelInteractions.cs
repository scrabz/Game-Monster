using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInteractions : MonoBehaviour {

	public float matchActionTimer = 15f;
	public GameObject thingToSpawn;
	public int ranNum;
	public GameObject matchObject;



	public Transform tributeSpawn1;
	public Transform tributeSpawn2;
	public Transform tributeSpawn3;

	public Transform soloCupSpawn;

	public GameObject fireSpawn;
	public GameObject light;
	// Use this for initialization
	void Start () {
		
		matchObject = GameObject.Find ("MatchManager");
		fireSpawn = GameObject.Find ("FireSpawn");

		if (SceneManager.GetActiveScene ().name == "VolcanoLevel") {

			tributeSpawn1 = GameObject.Find ("TributeSpawn1").transform;
			tributeSpawn2 = GameObject.Find ("TributeSpawn2").transform;
			tributeSpawn3 = GameObject.Find ("TributeSpawn3").transform;
			light = GameObject.Find ("Directional Light");
		}

		if (SceneManager.GetActiveScene ().name == "HallOfBrosLevel") {

			soloCupSpawn = GameObject.Find ("SoloCupSpawn").transform;
		}
		//StartCoroutine ("FireRain");
	}
		
	
	// Update is called once per frame
	void Update () {
		if (matchObject.GetComponent<MatchManager> ().isFighting) {
			matchActionTimer -= Time.deltaTime;

			if (matchActionTimer <= 0f) {
				if (SceneManager.GetActiveScene ().name == "VolcanoLevel") {
					ranNum = Random.Range (0, 3);
					if (ranNum == 0) {
						thingToSpawn = Instantiate (Resources.Load ("Tribute"), tributeSpawn1.position, tributeSpawn1.rotation) as GameObject;
					}
					if (ranNum == 1) {
						thingToSpawn = Instantiate (Resources.Load ("Tribute"), tributeSpawn2.position, tributeSpawn2.rotation) as GameObject;
					}
					if (ranNum == 2) {
						thingToSpawn = Instantiate (Resources.Load ("Tribute"), tributeSpawn3.position, tributeSpawn3.rotation) as GameObject;
					}
					matchActionTimer = 15f + Random.Range(0f,25f);
				}
				Debug.Log("hit 0");
				if (SceneManager.GetActiveScene ().name == "HallOfBrosLevel") {
					GameObject cup;
					cup = GameObject.FindGameObjectWithTag ("SoloCup");
					//Debug.Log (cup.name);
					//if (cup == null) {
						Debug.Log ("instanciated cup");
						matchActionTimer = 15f + Random.Range(0f,25f);
						thingToSpawn = Instantiate (Resources.Load ("SoloCup"), soloCupSpawn.position, soloCupSpawn.rotation) as GameObject;
					//}
				}

			}
		} else {
			matchActionTimer = 15f + Random.Range(0f,25f);
		}
	}

	public IEnumerator FireRain(){
		light.GetComponent<Light> ().intensity = 0.2f;
		for (int i = 0; i < 88; i++) {
			print ("spawned");
			thingToSpawn = Instantiate (Resources.Load ("ProjectileAttacks/FallingFire"), fireSpawn.transform.position + new Vector3 (Random.Range (-50f, 50f), 0, Random.Range (-30f, 30f)), fireSpawn.transform.rotation) as GameObject;
			thingToSpawn.GetComponent<AttackAction> ().teamNum = 5;
			thingToSpawn.GetComponent<AttackAction> ().creator = this.gameObject;
			yield return new WaitForSeconds (0.05f);
		}
		yield return new WaitForSeconds (1.5f);
		light.GetComponent<Light> ().intensity = 0.4f;
		yield return null;
	}
}
