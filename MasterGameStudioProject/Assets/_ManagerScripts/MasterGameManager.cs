using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterGameManager : MonoBehaviour {

	public static MasterGameManager instance = null;

	public AudioSource soundSource;
	public AudioSource musicSource;
	public GameObject matchManagerObject;

	public bool ffa = true;





	public List<GameObject> player1Characters;
	public List<GameObject> player2Characters;
	public List<GameObject> player3Characters;
	public List<GameObject> player4Characters;

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

	public bool p3Enabled = false;
	public bool p4Enabled = false;

	//Awake is always called before any Start functions
	void Awake()
	{
		player1Characters = new List<GameObject> ();
		player2Characters = new List<GameObject> ();
		player3Characters = new List<GameObject> ();
		player4Characters = new List<GameObject> ();

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

	public void AddCharacter(int playerNumber, string name){
		if (playerNumber == 1) {
			if (name == "Empty"){
				player1Characters.Add (Empty);
			}
			if (name == "Brogre"){
				player1Characters.Add (Brogre);
			}
			if (name == "Skelly") {
				player1Characters.Add (Skelly);
			}
			if (name == "Tiny") {
				player1Characters.Add (Tiny);
			}
			if (name == "Neredy") {
				player1Characters.Add (Neredy);
			}
		}

		if (playerNumber == 2) {
			if (name == "Empty"){
				player2Characters.Add (Empty);
			}
			if (name == "Brogre"){
				player2Characters.Add (Brogre);
			}
			if (name == "Skelly") {
				player2Characters.Add (Skelly);
			}
			if (name == "Tiny") {
				player2Characters.Add (Tiny);
			}
			if (name == "Neredy") {
				player2Characters.Add (Neredy);
			}
		}
		if (playerNumber == 3) {
			if (name == "Empty"){
				player3Characters.Add (Empty);
			}
			if (name == "Brogre"){
				player3Characters.Add (Brogre);
			}
			if (name == "Skelly") {
				player3Characters.Add (Skelly);
			}
			if (name == "Tiny") {
				player3Characters.Add (Tiny);
			}
			if (name == "Neredy") {
				player3Characters.Add (Neredy);
			}
		}
		if (playerNumber == 4) {
			if (name == "Empty"){
				player4Characters.Add (Empty);
			}
			if (name == "Brogre"){
				player4Characters.Add (Brogre);
			}
			if (name == "Skelly") {
				player4Characters.Add (Skelly);
			}
			if (name == "Tiny") {
				player4Characters.Add (Tiny);
			}
			if (name == "Neredy") {
				player4Characters.Add (Neredy);
			}
		}


	}

	public void ResetCharacters(){

		player1Characters.Clear ();
		player2Characters.Clear ();
		player3Characters.Clear ();
		player4Characters.Clear ();

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
