using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Script for bars (Health, Stamina)
public class Bar : MonoBehaviour {
	private float fillAmount;

	[SerializeField]
	private float lerpSpeed;

	[SerializeField]
	private Image content;
	[SerializeField]
	private Text valueText;

	public float MaxValue { get; set;}
	public float Value {
		set { 
			string[] tmp = valueText.text.Split(':');
			valueText.text = tmp[0] + ": " + value;
			fillAmount = Map (value, 0, MaxValue, 0, 1);
		}
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		HandleBar ();
	}

	// Function updating health and adjusting values
	public void HandleBar () {
		if (fillAmount != content.fillAmount) {
			content.fillAmount = Mathf.Lerp (content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
		}
	}

	// Tranfer the bar statistic to adjust according to the values (0 is minimum, 1 is maximum) ~ considering better naming
	private float Map (float value, float minimum, float maximum, float outMinimum, float outMaximum) {
	
		return (value - minimum) * (outMaximum - outMinimum) / (maximum - minimum) + outMinimum;
	}
}