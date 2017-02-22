using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

	[SerializeField]
	private Stat health;
	public Animator animation;

	private void Awake () {
		health.InitializeStat();
		animation = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			Debug.Log ("AI Health is decreasing");
			health.CurrentVal -= 10;
			animation.SetTrigger ("TakingDamage");
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			Debug.Log ("AI Health is increasing");
			health.CurrentVal += 10;
		}
	}

	public void Attack () {
		GameObject Kevin = GameObject.Find ("Kevin");
		KevinController KevinScript = Kevin.GetComponent<KevinController> ();
		KevinScript.health.CurrentVal -= 10;
		animation.SetTrigger ("Attack");
	}

}

