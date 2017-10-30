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

	public Text modeText;
	public Image redPanel;
	public Image bluePanel;

	public GameObject cursorCanvas;

	public GameObject p1Cur;
	public GameObject p2Cur;
	public GameObject p3Cur;
	public GameObject p4Cur;
	void Start () {
		modeText = GameObject.Find ("ModeText").GetComponent<Text>();
		redPanel = GameObject.Find ("RedPanel").GetComponent<Image>();
		bluePanel = GameObject.Find ("BluePanel").GetComponent<Image>();
		redPanel.enabled = false;
		bluePanel.enabled = false;
		cursorCanvas = GameObject.Find ("CursorCanvas");
		p1Cur = GameObject.Find ("P1Cursor");
		p2Cur = GameObject.Find ("P2Cursor");
		p3Cur = GameObject.Find ("P3Cursor");
		p4Cur = GameObject.Find ("P4Cursor");
		p2Cur.SetActive (false);
		p3Cur.SetActive (false);
		p4Cur.SetActive (false);
		mainMenuAnimator = GameObject.Find ("MainMenuPanel").GetComponent<Animator> ();
		characterSelectAnimator = GameObject.Find ("CharacterSelectPanel").GetComponent<Animator> ();
		levelSelectAnimator = GameObject.Find ("LevelSelectPanel").GetComponent<Animator> ();
		cursorCanvas.SetActive (true);
		//blackoutPanel = GameObject.Find ("BlackoutPanel").GetComponent<Image> ();



	}

	public void ExitGame(){
		Application.Quit ();
	}

	public void StartVersusMatch(){
		p2Cur.SetActive (true);
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
		p2Cur.SetActive (false);
		p3Cur.SetActive (false);
		p4Cur.SetActive (false);
		MasterGameManager.instance.p3Enabled = false;
		MasterGameManager.instance.p4Enabled = false;
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

	public void EnablePlayer3(){
		if (characterSelectAnimator.GetBool ("upFromBottom") == true) {
			p3Cur.SetActive (true);
			MasterGameManager.instance.p3Enabled = true;
		}


	}

	public void EnablePlayer4(){
		if (characterSelectAnimator.GetBool ("upFromBottom") == true) {
			p4Cur.SetActive (true);
			MasterGameManager.instance.p4Enabled = true;
		}

	}

	public void ChangeMode(){
		if (MasterGameManager.instance.ffa) {
			MasterGameManager.instance.ffa = false;
			modeText.text = "TEAM";
			redPanel.enabled = true;
			bluePanel.enabled = true;
		} else {
			MasterGameManager.instance.ffa = true;
			modeText.text = "FFA";
			redPanel.enabled = false;
			bluePanel.enabled = false;
		}

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
