using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour {

	private float health;

	public Slider currentHealthBar;
	public Text healthText;

	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		health = 100;
		Update ();
	}
	

	private void HealthUpdate()
	{
		currentHealthBar.value = health;
		if (health > 100)
		{
			health = 100;
		}
		if (health < 0)
		{
			health = 0;
		}
		healthText.text = (currentHealthBar.value).ToString ("0") + '%';
	}

	public void Actions(string action)
	{
		switch (action) 
		{
		case "Bite":
			health -= 10;
			break;
		case "Punch":
			health -= 15;
			break;
		case "Kick":
			health -= 20;
			break;
		default:
			break;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")) {
			anim.Play ("EnemyAnim", -1, 0f);
		}
		HealthUpdate ();
	}
}
