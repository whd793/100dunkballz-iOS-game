using UnityEngine;
using System.Collections;

public class BasketTimeChallenge : MonoBehaviour {
	public static BasketTimeChallenge Instance;

	public Transform[] Destination;		//moving destinations
	public Transform centerDes;	

	int currentDestination;	
	Vector2 target;
	public float timer = 20f;
	public float timerToMove = 12f;
	public float speed = 1;
	int limitDes = 3;
	bool allowMoving = false;

	public float timeStart,timeLeft;
	float _timer;

	[HideInInspector]
	public bool isRunning;

	void Awake(){
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		if (Destination.Length < 3) {
			Debug.Log ("You must place 3 destination points to Destination");
		}

		currentDestination = 0;
		target = Destination [currentDestination].position;
		_timer = timer;
	}

	// Update is called once per frame
	void Update () {
		if (!isRunning) {
			transform.position = Vector2.MoveTowards (transform.position, centerDes.position, speed * Time.deltaTime);
			return;
		}
		
		if (allowMoving) {
			transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
			if (Vector2.Distance (transform.position, target) < 0.01f) {
				currentDestination++;
				if (((currentDestination + 1) > Destination.Length) || (currentDestination + 1) > limitDes)
					currentDestination = 0;

				target = Destination [currentDestination].position;
			}
		}else
			transform.position = Vector2.MoveTowards (transform.position, centerDes.position, speed * Time.deltaTime);
			

		timeLeft = _timer - (Time.realtimeSinceStartup - timeStart);

		if (timeLeft <= timerToMove)
			allowMoving = true;

		if (timeLeft <= 0) {
			GameManager.Instance.GameOver ();
			Reset ();
		}
	}

	public void StartRun(){
		if (isRunning)		//prevent the Ball send this event again
			return;
		
		isRunning = true;
		timeStart = Time.realtimeSinceStartup;
	}

	//called by GameManager when gameover
	public void Reset(){
		currentDestination = 0;
		target = Destination [currentDestination].position;
		allowMoving = false;
		_timer = timer;
		isRunning = false;
	}
}
