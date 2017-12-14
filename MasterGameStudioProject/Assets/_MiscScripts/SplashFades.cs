using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashFades : MonoBehaviour {
	public Image blackoutPanel;
	public float i = 1f;
	// Use this for initialization
	void Start () {
		blackoutPanel = GameObject.Find ("BlackoutPanel").GetComponent<Image> ();
		StartCoroutine ("FadeIn");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			StopAllCoroutines ();
			StartCoroutine ("FadeOut");
		}
	}

	public IEnumerator FadeOut(){
		print ("hi");
		while (i < 1f) {
			i = i + 0.025f;
			Color o = blackoutPanel.color;
			o.a = i;
			blackoutPanel.color = o;
			if (i >= 1f) {
				if (SceneManager.GetActiveScene ().name == "SplashOne") {
					SceneManager.LoadScene ("SplashTwo");
				}
				if (SceneManager.GetActiveScene ().name == "SplashTwo") {
					SceneManager.LoadScene ("Menu");
				}
			}
			yield return null;
		}


	}
	public IEnumerator FadeIn(){
		while (i > 0.025f) {
			i = i - 0.025f;
			Color c = blackoutPanel.color;
			c.a = i;
			blackoutPanel.color = c;
			if (i <= 0f) {
				
				i = 0f;

				//yield return null;
			}

			yield return null;
		}
		if (SceneManager.GetActiveScene ().name == "SplashOne") {
			yield return new WaitForSeconds (4f);
		}
		if (SceneManager.GetActiveScene ().name == "SplashTwo") {
			yield return new WaitForSeconds (5f);
		}
		StartCoroutine ("FadeOut");
	}
}
