using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoveUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<RectTransform> ().anchoredPosition = this.GetComponent<RectTransform> ().anchoredPosition + new Vector2 (0, 1.45f);
	}
}
