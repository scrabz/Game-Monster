using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {

	public Button thisButt;
	public bool wasClicked = false;
	public Vector3 origScale;
	// Use this for initialization
	void Start () {
		origScale = this.transform.localScale;
		thisButt = this.GetComponent<Button> ();
		if (thisButt != null) {
			thisButt.onClick.AddListener (TaskOnClick);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void TaskOnClick(){
		this.GetComponent<AudioSource> ().volume = 0.15f;
		this.GetComponent<AudioSource> ().Play ();
		StartCoroutine ("ButtonPress");
	}

	IEnumerator ButtonPress(){
		wasClicked = true;
		this.transform.localScale = this.transform.localScale - new Vector3(0.00f,0.12f,0.12f);
		while (this.transform.localScale.y < origScale.y) {

			this.transform.localScale = this.transform.localScale + new Vector3(0.00f,0.02f,0.02f);


			if (this.transform.localScale.y >= origScale.y) {
				this.transform.localScale = origScale;
				wasClicked = false;
			}
			yield return null;
		}



	}
}
