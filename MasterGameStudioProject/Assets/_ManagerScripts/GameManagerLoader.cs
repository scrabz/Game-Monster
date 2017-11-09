using UnityEngine;
using System.Collections;

public class GameManagerLoader : MonoBehaviour {
	public GameObject gameManager; //GameManager prefab to instantiate

	void Awake () {
		gameManager = Resources.Load<GameObject>("MasterGameManager");
		//Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
		if (MasterGameManager.instance == null){
			Instantiate(gameManager);
		}
	}
	
}
