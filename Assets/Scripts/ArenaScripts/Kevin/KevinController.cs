using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KevinController : MonoBehaviour {
	[SerializeField]
	public Stat health;
	public Animator animation;
	public float stopanimation = 0;

	private void Awake () {
		health.InitializeStat();
		animation = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A) && health.CurrentVal > 0) {
			Debug.Log ("Health is decreasing");
			health.CurrentVal -= 10;
			animation.SetTrigger ("Taking Damage");
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			Debug.Log ("Health is increasing");
			health.CurrentVal += 10;
		}

		if (health.CurrentVal <= 0) {
			animation.SetTrigger ("Death");
			Debug.Log ("Death");	
		}
	}
}
