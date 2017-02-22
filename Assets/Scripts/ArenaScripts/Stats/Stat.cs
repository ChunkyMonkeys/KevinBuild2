using UnityEngine;
using System.Collections;
using System;

// Controls all changes in values for the Health and Stamina bars plus possible upgrades (health items, stamina items, etc)

[Serializable]
public class Stat {
	[SerializeField]
	private Bar bar;

	[SerializeField]
	private float maxVal;

	[SerializeField]
	private float currentVal;

	public float CurrentVal {
		get {
			return currentVal;
		}
		set { 
			this.currentVal = Mathf.Clamp (value, 0, MaxVal);
			bar.Value = currentVal;
		}
	}

	public float MaxVal {
		get {
			return maxVal;
		}
		set { 
			this.maxVal = value;
			bar.MaxValue = maxVal;
		}
	}

	public void InitializeStat() {
		this.MaxVal = maxVal;
		this.CurrentVal = currentVal;
	}
}
