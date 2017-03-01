using UnityEngine;
using System.Collections;

public class CombatTurns : MonoBehaviour {

	public AIController other;

	public enum Turns
	{
		PLAYERTURN,
		ENEMYTURN,
		LOSE,
		WIN
	}

	private Turns currentState;

	// Use this for initialization
	void Start () {
		currentState = Turns.PLAYERTURN;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (currentState);
		switch (currentState) {
		case (Turns.PLAYERTURN):
			break;
		case (Turns.ENEMYTURN):
			other.Attack ();
			other.anim.SetBool ("Attack", false);
			currentState = Turns.PLAYERTURN;
			break;
		case (Turns.LOSE):
			break;
		case (Turns.WIN):
			break;
		}
	}

	public void ChangeState() {
		if (currentState == Turns.PLAYERTURN) {
			currentState = Turns.ENEMYTURN;
		}
	}
}
