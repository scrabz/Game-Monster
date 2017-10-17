using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
	public float i = 0f;
	public Image blackoutPanel;

	public GameObject chrManager;

	public Animator mainMenuAnimator;
	public Animator characterSelectAnimator;
	public Animator levelSelectAnimator;

	public GameObject cursorCanvas;
	void Start () {
		cursorCanvas = GameObject.Find ("CursorCanvas");
		mainMenuAnimator = GameObject.Find ("MainMenuPanel").GetComponent<Animator> ();
		characterSelectAnimator = GameObject.Find ("CharacterSelectPanel").GetComponent<Animator> ();
		levelSelectAnimator = GameObject.Find ("LevelSelectPanel").GetComponent<Animator> ();
		cursorCanvas.SetActive (false);
		//blackoutPanel = GameObject.Find ("BlackoutPanel").GetComponent<Image> ();

		if (SceneManager.GetActiveScene ().name == "CharacterCreator") {
			chrManager = GameObject.Find ("CharacterCreatorManager");
		}


	}


	public void StartVersusMatch(){
		cursorCanvas.SetActive (true);
		mainMenuAnimator.SetBool ("upFromMid", true);
		mainMenuAnimator.SetBool ("upFromBottom", false);
		mainMenuAnimator.SetBool ("downFromTop", false);
		mainMenuAnimator.SetBool ("downFromMid", false);

		characterSelectAnimator.SetBool ("upFromBottom", true);
		characterSelectAnimator.SetBool ("upFromMid", false);
		characterSelectAnimator.SetBool ("downFromTop", false);
		characterSelectAnimator.SetBool ("downFromMid", false);
	}
	public void BackFromCharacterSelect(){
		cursorCanvas.SetActive (false);
		mainMenuAnimator.SetBool ("downFromTop", true);
		mainMenuAnimator.SetBool ("upFromBottom", false);
		mainMenuAnimator.SetBool ("upFromMid", false);
		mainMenuAnimator.SetBool ("downFromMid", false);

		characterSelectAnimator.SetBool ("downFromMid", true);
		characterSelectAnimator.SetBool ("upFromMid", false);
		characterSelectAnimator.SetBool ("downFromTop", false);
		characterSelectAnimator.SetBool ("upFromBottom", false);
	}

	public void LevelSelect(){

		characterSelectAnimator.SetBool ("upFromMid", true);
		characterSelectAnimator.SetBool ("upFromBottom", false);
		characterSelectAnimator.SetBool ("downFromTop", false);
		characterSelectAnimator.SetBool ("downFromMid", false);

		levelSelectAnimator.SetBool ("upFromBottom", true);
		levelSelectAnimator.SetBool ("upFromMid", false);
		levelSelectAnimator.SetBool ("downFromTop", false);
		levelSelectAnimator.SetBool ("downFromMid", false);


	}
		



	public IEnumerator FadeOut(string levelName){
		while (i < 1f) {
			i = i + 0.025f;
			Color c = blackoutPanel.color;
			c.a = i;
			blackoutPanel.color = c;
			if (i >= 1f) {
				SceneManager.LoadScene (levelName);
			}
			yield return null;
		}
	}
	public IEnumerator FadeIn(){
		while (i > 0f) {
			i = i - 0.025f;
			Color c = blackoutPanel.color;
			c.a = i;
			blackoutPanel.color = c;
			if (i <= 0f) {
			}

			yield return null;
		}
	}

}
