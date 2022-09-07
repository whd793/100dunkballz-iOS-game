using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {
	public Transform[] Destination;		//moving destinations
	public Transform centerDes;	

	int currentDestination;	
	Vector2 target;
	public int pointToMove = 10;
	public int pointToMove2 = 20;
	public float speed = 1;
	int limitDes = 2;
	bool allowMoving = false;

	// Use this for initialization
	void Start () {
		if (Destination.Length < 2) {
			Debug.Log ("You must place at least 2 destination points to Destination");
		}

		currentDestination = 0;
		target = Destination [currentDestination].position;
	}
	
	// Update is called once per frame
	void Update () {
		if (allowMoving) {
			transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
			if (Vector2.Distance (transform.position, target) < 0.01f) {
				currentDestination++;
				if (((currentDestination + 1) > Destination.Length) || (currentDestination + 1) > limitDes)
					currentDestination = 0;
			
				target = Destination [currentDestination].position;
			}
		}else //alway moving to the first point, that's mean the center point
			transform.position = Vector2.MoveTowards (transform.position, centerDes.position, speed * Time.deltaTime);

		if (GameManager.Instance.Point >= pointToMove)
			allowMoving = true;
		if (GameManager.Instance.Point >= pointToMove2)
			limitDes = 3;
	}

	//called by GameManager when gameover
	public void Reset(){
		currentDestination = 0;
		target = Destination [currentDestination].position;
		allowMoving = false;
	}
}
