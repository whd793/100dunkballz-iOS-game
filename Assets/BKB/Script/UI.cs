using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {
	public Text stars;
	public Text gameMode;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		stars.text = GameManager.Instance.SavedStars +"";
		gameMode.text = TheBall.Instance.numballs.ToString();
	}
}
