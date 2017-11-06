using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInteractions : MonoBehaviour {

	public float matchActionTimer = 30f;
	public GameObject thingToSpawn;
	public int ranNum;
	public GameObject matchObject;



	public Transform tributeSpawn1;
	public Transform tributeSpawn2;
	public Transform tributeSpawn3;
	// Use this for initialization
	void Start () {
		matchObject = GameObject.Find ("MatchManager");


		if (SceneManager.GetActiveScene ().name == "VolcanoLevel") {

			tributeSpawn1 = GameObject.Find ("TributeSpawn1").transform;
			tributeSpawn2 = GameObject.Find ("TributeSpawn2").transform;
			tributeSpawn3 = GameObject.Find ("TributeSpawn3").transform;
		}
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
				}
				matchActionTimer = 30f;

			}
		} else {
			matchActionTimer = 30f;
		}
	}
}
