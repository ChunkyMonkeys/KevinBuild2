using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	//flag to check if the user has tapped / clicked. 
	//Set to true on click. Reset to false on reaching destination
	private bool flag = false;
	//destination point
	private Vector3 endPoint;
	//alter this to change the speed of the movement of player / gameobject
	public float duration = 1.0f;
	public float speed = 2.0f;
	//Animation
	private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		//check if the screen is touched / clicked   
		if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0))) {
			//declare a variable of RaycastHit struct
			RaycastHit hit;
			//Create a Ray on the tapped / clicked position
			Ray ray;
			//for unity editor
			#if UNITY_EDITOR
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//for touch device
			#elif (UNITY_ANDROID)
			ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			#endif

			//Check if the ray hits any collider
			if(Physics.Raycast(ray,out hit)){
				//set a flag to indicate to move the gameobject
				flag = true;
				//Animate the walk
				animator.SetBool("isWalking", true);
				//save the click / tap position
				endPoint = hit.point;
				Debug.Log(endPoint);
			}
		}
		//check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
		if(flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)){ //&& !(V3Equal(transform.position, endPoint))){
			//move the gameobject to the desired position
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, speed/(duration*(Vector3.Distance(gameObject.transform.position, endPoint))));
		}
		//set the movement indicator flag to false if the endPoint and current gameobject position are equal
		else if(flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)) {
			flag = false;
			//Return to an idle animation
			animator.SetBool("isWalking", false);
			Debug.Log("I am here");
		}
		//animation.Play ("WalkAnimation");
	}
}