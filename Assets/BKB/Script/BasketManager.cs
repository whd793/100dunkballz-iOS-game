using UnityEngine;
using System.Collections;

public class BasketManager : MonoBehaviour {
	public static BasketManager Instance;		
	public enum PlayMode{Endless, Sliding, TimeChallenge};
	[HideInInspector]
	public PlayMode Mode;

	public GameObject endless;
	public GameObject sliding;
	public GameObject timechallenge;

	void Awake(){
		Instance = this;
		endless.SetActive (true);
		sliding.SetActive (false);
		timechallenge.SetActive (false);
	}

	// Use this for initialization
	void Start () {
		
		Mode = PlayMode.Endless;
	}

	public void Endless(){
		endless.SetActive (true);
		sliding.SetActive (false);
		timechallenge.SetActive (false);
		Mode = PlayMode.Endless;

		SoundManager.PlaySfx (SoundManager.Instance.soundClick);
	}

	public void Sliding(){
		endless.SetActive (false);
		sliding.SetActive (true);
		timechallenge.SetActive (false);
		Mode = PlayMode.Sliding;

		SoundManager.PlaySfx (SoundManager.Instance.soundClick);
	}

	public void TimeChallenge(){
		endless.SetActive (false);
		sliding.SetActive (false);
		timechallenge.SetActive (true);
		Mode = PlayMode.TimeChallenge;

		SoundManager.PlaySfx (SoundManager.Instance.soundClick);
	}
}
