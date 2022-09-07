using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour {
	public Transform displayPos;
	public GameObject Display;
	public Text time;
	public float second, ss;
	string timer;
	
	// Update is called once per frame
	void Update () {
		transform.position = Camera.main.WorldToScreenPoint (displayPos.position);
		if (BasketManager.Instance.Mode == BasketManager.PlayMode.TimeChallenge) {
			Display.SetActive (true);
			if (BasketTimeChallenge.Instance.isRunning) {
				second = (int)BasketTimeChallenge.Instance.timeLeft / 1f;
				ss = (BasketTimeChallenge.Instance.timeLeft % 1f) * 100;
				timer = string.Format ("{0:00},{1:00}", second, ss);
				time.text = timer;
			} else {
				second = (int)BasketTimeChallenge.Instance.timer / 1f;
				ss = (BasketTimeChallenge.Instance.timer % 1f) * 100;
				timer = string.Format ("{0:00},{1:00}", second, ss);
				time.text = timer;
			}
		} else
			Display.SetActive (false);
	}
}
