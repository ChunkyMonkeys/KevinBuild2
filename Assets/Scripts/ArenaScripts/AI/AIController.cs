using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

	[SerializeField]
	private Stat health;
	public Animator anim;

	private void Awake () {
		health.InitializeStat();

		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			Debug.Log ("AI Health is decreasing");
			health.CurrentVal -= 10;
			anim.SetTrigger ("TakingDamage");
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
		anim.SetBool ("Attack", true);
	}

}

