//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//
//public class CharacterLevelSelectAction : MonoBehaviour {
//	public Sprite chrNorm;
//	public Sprite chrWalk;
//
//	public bool leftButton;
//	public bool rightButton;
//	public bool downButton;
//	public bool upButton;
//	public bool jumpButton;
//	public bool escButton;
//
//
//	public string levelName;
//	public Image blackoutPanel;
//	public Text levelNameDisplay;
//	public bool levelReady = false;
//	public float spriteTimer;
//
//	public float i = 0f;
//
//	public GameObject selector;
//	public GameObject easyRun;
//	public GameObject normalRun;
//	public GameObject harderRun;
//
//	public GameObject popupCanvas;
//
//	public bool changedMode = false;
//
//	public Image star1;
//	public Image star2;
//	public Image star3;
//	public Text starWords;
//
//	public Sprite emptyStar;
//	public Sprite fullStar;
//	public Sprite glitterStar;
//	public Sprite nothingStar;
//
//	public int totalStars;
//
//
//	void Awake(){
//
//	}
//	// Use this for initialization
//	void Start () {
//		blackoutPanel = GameObject.Find ("BlackoutPanel").GetComponent<Image> ();
//		levelNameDisplay = GameObject.Find ("LevelName").GetComponent<Text> ();
//		starWords = GameObject.Find ("StarWords").GetComponent <Text> ();
//		popupCanvas = GameObject.Find ("PopUpCanvas");
//
//		selector = GameObject.Find ("Selector");
//		easyRun = GameObject.Find ("Easy");
//		normalRun = GameObject.Find ("Normal");
//		harderRun = GameObject.Find ("Hard");
//
//		star1 = GameObject.Find ("Star1").GetComponent<Image>();
//		star2 = GameObject.Find ("Star2").GetComponent<Image>();
//		star3 = GameObject.Find ("Star3").GetComponent<Image>();
//
//
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//
//		//Animates the Character in the level select screen
//		spriteTimer += Time.deltaTime * 6.5f;
//		if (spriteTimer < 1) {
//			this.GetComponent<SpriteRenderer> ().sprite = chrNorm;
//		}
//		if (spriteTimer > 1 && spriteTimer < 2) {
//			this.GetComponent<SpriteRenderer> ().sprite = chrWalk;
//		}
//
//		if (spriteTimer >= 2) {
//			spriteTimer = 0f;
//
//		}
//		upButton = Input.GetButtonDown ("Up");
//		downButton = Input.GetButtonDown ("Down");
//		leftButton = Input.GetButtonDown ("Left");
//		rightButton = Input.GetButtonDown ("Right");
//		jumpButton = Input.GetButtonDown ("Jump");
//		escButton = Input.GetButtonDown ("Escape");
//
//
//
//		if (popupCanvas.activeSelf == false) {
//			if (escButton) {
//				levelName = "StartMenu";
//				StartCoroutine ("FadeOut");
//			}
//		}
//
//
//		if (popupCanvas.activeSelf == true) {
//
//			if (escButton) {
//				popupCanvas.SetActive (false);
//			}
//			if (upButton) {
//				if (selector.transform.parent.name == "Easy" && changedMode == false) {
//					MasterGameManager.instance.difficultySelect = 3;
//					selector.transform.SetParent (harderRun.transform);
//					selector.GetComponent<RectTransform>().position = harderRun.GetComponent<RectTransform>().position;
//					changedMode = true;
//				}
//				if (selector.transform.parent.name == "Normal" && changedMode == false) {
//					MasterGameManager.instance.difficultySelect = 1;
//					selector.transform.SetParent (easyRun.transform);
//					selector.GetComponent<RectTransform>().position = easyRun.GetComponent<RectTransform>().position;
//					changedMode = true;
//				}
//				if (selector.transform.parent.name == "Hard" && changedMode == false) {
//					selector.GetComponent<RectTransform>().position = normalRun.GetComponent<RectTransform>().position;
//					selector.transform.SetParent (normalRun.transform);
//					MasterGameManager.instance.difficultySelect = 2;
//					changedMode = true;
//				}
//				changedMode = false;
//			}
//
//			if (downButton) {
//				if (selector.transform.parent.name == "Normal" && changedMode == false) {
//					MasterGameManager.instance.difficultySelect = 3;
//					selector.transform.SetParent (harderRun.transform);
//					selector.GetComponent<RectTransform>().position = harderRun.GetComponent<RectTransform>().position;
//					changedMode = true;
//				}
//				if (selector.transform.parent.name == "Hard" && changedMode == false) {
//					MasterGameManager.instance.difficultySelect = 1;
//					selector.transform.SetParent (easyRun.transform);
//					selector.GetComponent<RectTransform>().position = easyRun.GetComponent<RectTransform>().position;
//					changedMode = true;
//				}
//				if (selector.transform.parent.name == "Easy" && changedMode == false) {
//					selector.GetComponent<RectTransform>().position = normalRun.GetComponent<RectTransform>().position;
//					selector.transform.SetParent (normalRun.transform);
//					MasterGameManager.instance.difficultySelect = 2;
//					changedMode = true;
//				}
//				changedMode = false;
//			}
//
//
//
//
//
//
//			if (jumpButton) {
//				StartCoroutine ("FadeOut");
//			}
//		}
//
//		if (popupCanvas.activeSelf == false) {
//
//			if (jumpButton) {
//
//				//Needs to be copypasted
//				if (MasterGameManager.instance.selectedLevel == "City Streets") {
//					if (popupCanvas.activeSelf == false) {
//						popupCanvas.SetActive (true);
//					}
//				}
//				if (MasterGameManager.instance.selectedLevel == "The Marketplace") {
//					if (popupCanvas.activeSelf == false) {
//						popupCanvas.SetActive (true);
//					}
//				}
//
//				if (MasterGameManager.instance.selectedLevel == "Icy Caverns") {
//					if (popupCanvas.activeSelf == false) {
//						popupCanvas.SetActive (true);
//					}
//				}
//
//
//
//
//			}
//
//			if (rightButton || leftButton) {
//				RaycastHit2D hit;
//				hit = Physics2D.Raycast (new Vector3 (this.transform.position.x + 1f, this.transform.position.y, this.transform.position.z), Vector2.right, 20f, 1 << LayerMask.NameToLayer ("MapPoints"));
//				this.GetComponent<SpriteRenderer> ().flipX = false;
//				if (leftButton) {
//					this.GetComponent<SpriteRenderer> ().flipX = true;
//					hit = Physics2D.Raycast (new Vector3 (this.transform.position.x - 1f, this.transform.position.y, this.transform.position.z), -Vector2.right, 20f, 1 << LayerMask.NameToLayer ("MapPoints"));
//				}
//				if (hit.collider != null) {
//
//					if (hit.collider.tag == "LevelLock") {
//
//					}
//
//					if (hit.collider.gameObject.tag == "LevelPoint") {
//						this.transform.position = hit.collider.gameObject.transform.position;
//
//						//Needs to be copypasted
//
//
//						if (hit.collider.gameObject.name == "Point0") {
//							DisplayLevel ("Backyard Practice");
//							UpdateStars (MasterGameManager.instance.level0Clear);
//						}
//						if (hit.collider.gameObject.name == "Point1") {
//							DisplayLevel ("City Streets");
//							UpdateStars (MasterGameManager.instance.level1Stars);
//						}
//						if (hit.collider.gameObject.name == "Point2") {
//							DisplayLevel ("The Marketplace");
//							UpdateStars (MasterGameManager.instance.level2Stars);
//						}
//						if (hit.collider.gameObject.name == "Point3") {
//							DisplayLevel ("Urban Park");
//							UpdateStars (MasterGameManager.instance.level3Stars);
//						}
//						if (hit.collider.gameObject.name == "Point4") {
//							DisplayLevel ("City Limits");
//							UpdateStars (MasterGameManager.instance.level4Stars);
//						}
//						if (hit.collider.gameObject.name == "Point5") {
//							DisplayLevel ("Jungle Trail");
//							UpdateStars (MasterGameManager.instance.level5Stars);
//						}
//						if (hit.collider.gameObject.name == "Point6") {
//							DisplayLevel ("Icy Caverns");
//							UpdateStars (MasterGameManager.instance.level6Stars);
//						}
//						if (hit.collider.gameObject.name == "Point7") {
//							DisplayLevel ("Desert Pass");
//							UpdateStars (MasterGameManager.instance.level7Stars);
//						}
//						if (hit.collider.gameObject.name == "Point8") {
//							DisplayLevel ("The Ascension");
//							UpdateStars (MasterGameManager.instance.level8Stars);
//						}
//						if (hit.collider.gameObject.name == "Point9") {
//							DisplayLevel ("End Of The Road Pt. 1");
//							UpdateStars (MasterGameManager.instance.level9Stars);
//						}
//						if (hit.collider.gameObject.name == "Point10") {
//							DisplayLevel ("End Of The Road Pt. 2");
//							UpdateStars (MasterGameManager.instance.level10Stars);
//						}
//						if (hit.collider.gameObject.name == "Point11") {
//							DisplayLevel ("Credits");
//							UpdateStars (MasterGameManager.instance.level11Clear);
//						}
//
//					}
//
//				}
//			}
//		}
//	}
//
//	public void UpdateStars(int howManyStars){
//		if (howManyStars != 9 && howManyStars != 10) {
//			starWords.enabled = false;
//			if (howManyStars == 0) {
//				star1.sprite = emptyStar;
//				star2.sprite = emptyStar;
//				star3.sprite = emptyStar;
//			}
//			if (howManyStars == 1) {
//				star1.sprite = fullStar;
//				star2.sprite = emptyStar;
//				star3.sprite = emptyStar;
//			}
//			if (howManyStars == 2) {
//				star1.sprite = fullStar;
//				star2.sprite = fullStar;
//				star3.sprite = emptyStar;
//			}
//			if (howManyStars == 3) {
//				star1.sprite = glitterStar;
//				star2.sprite = glitterStar;
//				star3.sprite = glitterStar;
//			}
//
//		} 	
//		if (howManyStars == 9 || howManyStars == 10){
//			star1.sprite = nothingStar;
//			star2.sprite = nothingStar;
//			star3.sprite = nothingStar;
//			starWords.enabled = false;
//			if (howManyStars == 10) {
//				starWords.enabled = true;
//			}
//		}
//			
//	}
//
//
//	public void DisplayLevel(string name){
//		//levelName = name;
//		MasterGameManager.instance.selectedLevel = name;
//		levelNameDisplay.text = name;
//
//
//	}
//
//	public IEnumerator FadeOut(){
//		while (i < 1f) {
//			i = i + 0.05f;
//			Color c = blackoutPanel.color;
//			c.a = i;
//			blackoutPanel.color = c;
//			if (i >= 1) {
//				LoadSelectedLevel ();
//			}
//			yield return null;
//		}
//	}
//
//	public void LoadSelectedLevel(){
//		SceneManager.LoadScene (levelName);
//	}
//
//
//}
