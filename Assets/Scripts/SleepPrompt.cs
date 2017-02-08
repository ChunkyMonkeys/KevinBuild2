using UnityEngine;
using System.Collections;

public class SleepPrompt : MonoBehaviour {
	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerStay2D(Collider2D col)
	{
		//Check the provided Collider2D parameter other to see if it is tagged "Bread", if it is...
		if (col.gameObject.CompareTag ("Player") && Input.GetTouch(0).phase == TouchPhase.Ended) {
			
		}
		else {
			//Do Nothing
		}
	}
}