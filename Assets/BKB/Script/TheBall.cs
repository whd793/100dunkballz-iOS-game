using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TheBall : MonoBehaviour {
	public static TheBall Instance;

	//public float force = 10f;		//the push force
	//public float mulDistaceDrag = 1.5f;	//scale the distance of the begin touch and the current touch	
	public GameObject theBall;
	//public float allowFireDistance = 2f;	//when the distance of the begin and the current touch over this value then fire the ball
	//public Transform[] SpawnPoint;	//random spawn the ball with this postion list

	[HideInInspector]
	public Sprite BallSprite;	//change every Ball sprite with this BallSprite 

	public GameObject Star;
	[Range(10,100)]
	public float percentShowStar = 20;

	GameObject _Star;

	public float numballs = 10;


	public GameObject Shop;

	//private Vector2 pos2;	//the current or end touch position
	//private bool isDragging = false;
	//public float distance;
	//Rigidbody2D rigBall;

	public AudioClip fireSound;
	[Range(0,1)]
	public float fireSoundVolume = 0.5f;

	//public Vector2 direction;

	GameObject Ball;
	Camera camera;
	Basket _Basket;
	StartMenu _StartMenu;

	void Awake(){
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		//StartCoroutine (SpawnBallCo());
		//ChangeBallSprite();
		_Basket = FindObjectOfType<Basket> ();
		_StartMenu = FindObjectOfType<StartMenu> ();

		camera = Camera.main;

		//get the choosen ball sprite
		BallSprite = ItemManager.Instance.GetItemImage (PlayerPrefs.GetInt (GlobalValue.ChoosenBall, 0));

	}


	void Update () {
		if (GameManager.Instance.State != GameManager.GameState.Playing)
			return;
		else {

			if (Input.touchCount > 0) {
				Touch touch = Input.GetTouch (0);
				Vector2 touchPos = Camera.main.ScreenToWorldPoint (touch.position);

				if (touch.phase == TouchPhase.Began)
					Instantiate (theBall, new Vector2 (touchPos.x, 4), Quaternion.identity);
			}

			if (numballs > 0) {
				if (Input.GetButtonDown ("Fire1")) {

					numballs = numballs - 1;
					Vector2 touchPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					Instantiate (theBall, new Vector2 (touchPos.x, 4), Quaternion.identity);
					SoundManager.PlaySfx (fireSound, fireSoundVolume);

					SpawnTheStar ();
					ChangeBallSprite ();
					//	StartCoroutine (SpawnBallCo ());
					Fire ();
				}


			} else if (numballs == 0 && GameObject.FindGameObjectsWithTag ("Ball").Length < 1) {



				GameManager.Instance.GameOver ();



			}

		
		}
	}
	//public float a;
	void Fire(){
	//	_StartMenu.HideMenu ();

	//	if (BasketManager.Instance.Mode == BasketManager.PlayMode.TimeChallenge)
	//		BasketTimeChallenge.Instance.StartRun ();

	//	direction = (pos2 - (Vector2)Ball.transform.position).normalized;

	//	 a = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
	//	if (a > 110) {
	//		direction.x = -Mathf.Sin (10*Mathf.Deg2Rad);
	//		direction.y = Mathf.Cos (10*Mathf.Deg2Rad);
	//	} else if (a < 80) {
	//		direction.x = Mathf.Sin (10*Mathf.Deg2Rad);
	//		direction.y = Mathf.Cos (10*Mathf.Deg2Rad);
	//	}
		
		
		 
	//	rigBall.isKinematic = false;
	//	rigBall.AddForce (direction * force);
	//	rigBall.gameObject.GetComponent<Ball> ().Fire ();

		//make the ball rotate a little bit
	//	rigBall.AddTorque (direction.x > 0 ? -100 : 100);

		Ball = null;

	//	var spawnPoint = SpawnPoint.Length > 0 ? SpawnPoint [Random.Range (0, SpawnPoint.Length)].position : transform.position;
	//	StartCoroutine (SpawnBallCo (.5f, spawnPoint));

SpawnTheStar ();
	}


	//spawn the new ball after the delay time
	//IEnumerator SpawnBallCo(){
	//	yield return new WaitForSeconds (delay);

	//	Ball = Instantiate (theBall, spawnPoint, Quaternion.identity) as GameObject;

	//	ChangeBallSprite ();

	//	rigBall = Ball.GetComponent<Rigidbody2D> ();

	//}

	//change the ball's sprite
	public void ChangeBallSprite(){
		
		Ball = theBall;

			Ball.GetComponent<Ball> ().ChangeSprite (BallSprite);


	}

	//spawn the star with the random chance
	void SpawnTheStar(){
		if (_Star != null)
			return;

		if (Random.Range (0, 100) < percentShowStar) {
			Vector2 pos = _Basket.gameObject.transform.position;

			if (BasketManager.Instance.Mode == BasketManager.PlayMode.Sliding)
				pos = new Vector2 (pos.x + Random.Range (-2, 2), pos.y);
				
			_Star = Instantiate (Star, pos, Quaternion.identity) as GameObject;
		}
	}


	//Called by GameManager
	//public void Reset(){
	//	if (Ball != null)
	//		Ball.transform.position = transform.position;
	//}

	//private Vector2 Normal(Vector2 vec2){
	//	Vector2 result;
	//	result.x = vec2.x / Screen.width;
	//	result.y = vec2.y / Screen.height;
	//
	//	return result;
	//}
}
