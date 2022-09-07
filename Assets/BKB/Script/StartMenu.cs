using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {
	public GameObject PlayBut;
	Animator anim;
	public Text score1;
	public Text score2;
	public Text best;
	public Text titlez;
	public GameObject ScorePanel;
	public GameObject AddCoins;
	public Image SoundImage;
	public Sprite soundOn;
	public Sprite soundOff;
	public string facebookLink = "Your facebook link";
	public string yourAppLink = "Your app link";

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		PlayBut.SetActive (true);
		ScorePanel.SetActive (false);
		score1.gameObject.SetActive (false);
		score2.text = "";
		best.text = "";

	}
	
	// Update is called once per frame
	void Update () {
		score1.text = GameManager.Instance.Point.ToString ();
	}

	public void Play(){
		PlayBut.SetActive (false);
		titlez.text = "";
		GameManager.Instance.StartGame ();
		MenuManager.Instance.StartGame ();
		HideMenu ();
		SoundManager.PlaySfx (SoundManager.Instance.soundClick);
	}

	public void ShowMenu(){
		anim.SetBool ("isHide",false);
		score1.gameObject.SetActive (false);
		ScorePanel.SetActive (true);
		score2.text = GameManager.Instance.Point + "";
		best.text = GameManager.Instance.SavedPoints + "";
		PlayBut.SetActive (true);
	}

	public void HideMenu (){
		anim.SetBool ("isHide",true);
		score1.gameObject.SetActive (true);
		ScorePanel.SetActive (false);
	}

	public void Sound(){
		if (AudioListener.volume == 1) {
			AudioListener.volume = 0;
			SoundImage.sprite = soundOff;
		} else {
			AudioListener.volume = 1;
			SoundImage.sprite = soundOn;
			SoundManager.PlaySfx (SoundManager.Instance.soundClick);
		}
	}

	public void Facebook(){
		Application.OpenURL (facebookLink);
	}

	public void Like(){
		Application.OpenURL (yourAppLink);
	}
}
