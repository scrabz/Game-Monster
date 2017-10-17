using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterGameManager : MonoBehaviour {

	public static MasterGameManager instance = null;

	public AudioSource soundSource;
	public AudioSource musicSource;
	public GameObject matchManagerObject;

	//0 = FFA, 1 = 2v2
	public int currentMode = 0;



//	public GameObject team1Ch1;
//	public GameObject team1Ch2;
//	public GameObject team1Ch3;
//	public GameObject team1Ch4;
//	public GameObject team1Ch5;
//
//	public GameObject team2Ch1;
//	public GameObject team2Ch2;
//	public GameObject team2Ch3;
//	public GameObject team2Ch4;
//	public GameObject team2Ch5;


	public List<GameObject> team1Characters;
	public List<GameObject> team2Characters;

	public float musicVolume = 0.2f;


	public bool screenShaking = false;
	public float screenShakeTimer = 0.2f;
	public GameObject currentCamera;

	public float shakeDuration = 0f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.2f;
	public float decreaseFactor = 1.0f;

	public Vector3 originalPos;

	public bool inDialogue = false;


	public GameObject Empty;
	public GameObject Brogre;
	public GameObject Skelly;
	public GameObject Tiny;
	public GameObject Neredy;

	public int teamSize = 4;

	//Awake is always called before any Start functions
	void Awake()
	{
		team1Characters = new List<GameObject> ();
		team2Characters = new List<GameObject> ();

		if (instance == null) {

			//if not, set instance to this
			instance = this;
		}

		//If instance already exists and it's not this:
		//				else if (instance != this)
		//
		//					//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
		//					Destroy(gameObject);    


		DontDestroyOnLoad(gameObject);
		//Level1HighScore = PlayerPrefs.GetInt ("SpeakerRack1HS");

	}
	void Start(){
		Empty = Resources.Load("Characters/Empty") as GameObject;
		Brogre = Resources.Load("Characters/Brogre") as GameObject;
		Skelly = Resources.Load("Characters/ToeTip") as GameObject;
		Tiny = Resources.Load("Characters/Tiny") as GameObject;
		Neredy = Resources.Load("Characters/Neredy") as GameObject;

	}
	void Update(){

	}

	public void AddCharacter(int teamNumber, string name){
		if (teamNumber == 1) {
			if (name == "Empty"){
				team1Characters.Add (Empty);
			}
			if (name == "Brogre"){
				team1Characters.Add (Brogre);
			}
			if (name == "Skelly") {
				team1Characters.Add (Skelly);
			}
			if (name == "Tiny") {
				team1Characters.Add (Tiny);
			}
			if (name == "Neredy") {
				team1Characters.Add (Neredy);
			}
		}

		if (teamNumber == 2) {
			if (name == "Empty"){
				team2Characters.Add (Empty);
			}
			if (name == "Brogre"){
				team2Characters.Add (Brogre);
			}
			if (name == "Skelly") {
				team2Characters.Add (Skelly);
			}
			if (name == "Tiny") {
				team2Characters.Add (Tiny);
			}
			if (name == "Neredy") {
				team2Characters.Add (Neredy);
			}
		}


	}

	public void ResetCharacters(){

		team1Characters.Clear ();
		team2Characters.Clear ();

	}

	public void PlaySingleSound(AudioClip sound){
		soundSource.clip = sound;
		soundSource.Play ();
	}

	public void PlayMusic(AudioClip musicTrack){
		musicSource.clip = musicTrack;
		musicSource.Play ();
	}
		
	public void RedScreenShake(GameObject camObject){
		currentCamera = camObject;
		originalPos = currentCamera.transform.localPosition;
		screenShaking = true;
	}
		

}
