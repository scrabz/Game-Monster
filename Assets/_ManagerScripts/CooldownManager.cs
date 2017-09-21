using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CooldownManager : MonoBehaviour {

	// Use this for initialization
	public Image darkMask;
	//public Text cooldownTextDisplay;

	//[SerializeField] private ProjectileAbility ability;
	//[SerializeField] private GameObject characterLoadout;

	private float cooldownDuration;
	private float nextReadyTime;
	private float cooldownTimeLeft;
	public bool abilityCooling = false;

	// Use this for initialization
	void Start () {
		darkMask = transform.Find ("Mask").GetComponent<Image>();
	}

	//public void Initialize(ProjectileAbility selectedAbility){
		//ability = selectedAbility;

		//myButtonImage = GetComponent<Image> ();
		//myButtonImage.sprite = ability.aIcon;
	//}
	// Update is called once per frame
	void Update () {

		if (Time.time >= nextReadyTime) {
			AbilityReady ();

		} else {
			Cooldown ();
		}



	}
	void AbilityReady(){
		darkMask.enabled = false;
		abilityCooling = false;

	}
	void Cooldown(){
		cooldownTimeLeft -= Time.deltaTime;
		darkMask.fillAmount = (cooldownTimeLeft / cooldownDuration);

	}
	public void StartCooldown(float cooldown){
		abilityCooling = true;
		cooldownDuration = cooldown;
		nextReadyTime = cooldownDuration + Time.time;
		cooldownTimeLeft = cooldownDuration;
		darkMask.enabled = true;


		//ability.TriggerAbility ();

	}
}
