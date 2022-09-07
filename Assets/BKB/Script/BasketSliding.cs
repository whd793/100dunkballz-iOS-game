using UnityEngine;
using System.Collections;

public class BasketSliding : MonoBehaviour {
	public Transform des1;
	public Transform des2;

	public float speed = 1;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards (transform.position, des1.position, speed * Time.deltaTime);
		if (Vector2.Distance (transform.position, des1.position) < 0.01f) {
			transform.position = des2.position;
		}
	}
}
