using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	bool collected = false;
	public float speed = 3f;
	Vector2 destination;
	public AudioClip sound;

	// Use this for initialization
	void Start () {
		destination = Camera.main.ScreenToWorldPoint (MenuManager.Instance.star_menu.position);		//convert star menu screen position to world position
	}
	
	// Update is called once per frame
	void Update () {
		if (!collected)
			return;

		transform.position = Vector2.MoveTowards (transform.position, destination, speed * Time.deltaTime);	//move this star to the star menu
		if (Vector2.Distance (transform.position, destination) < 0.01f)
			Destroy (gameObject);		//destroy the star when it is nearly the menu star enough
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Ball")) {
			if (other.transform.position.y < transform.position.y)
				return;

			collected = true;	//allow the star moving
			GameManager.Instance.SavedStars++;
			SoundManager.PlaySfx (sound);
		}
	}
}
