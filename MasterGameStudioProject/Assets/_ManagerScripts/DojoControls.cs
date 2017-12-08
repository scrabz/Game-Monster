using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;
using InControl;

public class DojoControls : MonoBehaviour {






	public InputDevice p1Joystick;



	public bool p1A;
	public bool p1B;
	public bool p1X;
	public bool p1Y;







	public Sprite portrait;
	public Sprite blankPortrait;

	public Sprite brogrePortrait;
	public Sprite skeletonPortrait;
	public Sprite tinyPortrait;
	public Sprite guyPortrait;
	public Sprite drDecayPortrait;
	public Sprite claymondPortrait;
	public Sprite succPortrait;
	public Sprite gorgonPortrait;
	public Sprite wynkPortrait;



	void Awake(){



		if (InputManager.Devices [0] != null) {
			p1Joystick = InputManager.Devices [0];
		}

	

		brogrePortrait = Resources.Load<Sprite> ("DojoCards/BrogreDojo");
		tinyPortrait = Resources.Load<Sprite> ("DojoCards/TinyDojo");
		skeletonPortrait = Resources.Load<Sprite> ("DojoCards/SkeletonDojo");
		claymondPortrait = Resources.Load<Sprite> ("DojoCards/ClaymondDojo");
		drDecayPortrait = Resources.Load<Sprite> ("DojoCards/DrDecayDojo");
		succPortrait = Resources.Load<Sprite> ("DojoCards/SuccDojo");
		guyPortrait = Resources.Load<Sprite> ("DojoCards/GuyDojo");
		gorgonPortrait = Resources.Load<Sprite> ("DojoCards/GorgonDojo");




	}

	void Start () {





	}
	
	// Update is called once per frame
	void Update () {






	
	}

				
}
