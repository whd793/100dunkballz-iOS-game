using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	public static MenuManager Instance;

	public GameObject Startmenu;
	public GameObject GUI;
	public GameObject Shop;
	public GameObject PlayMode;
	public GameObject NotEnoughCoins;


	public Transform star_menu;

	void Awake(){
		Instance = this;
		Startmenu.SetActive (true);
		GUI.SetActive (true);
		Shop.SetActive (false);
		PlayMode.SetActive (false);
		NotEnoughCoins.SetActive (false);
	}

	public void RestartGame(){
		SoundManager.PlaySfx (SoundManager.Instance.soundClick);
		SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex);
	}

	public void HomeScene(){
		SoundManager.PlaySfx (SoundManager.Instance.soundClick);
		Time.timeScale = 1;
		SceneManager.LoadSceneAsync ("MainMenu");

	}

	public void GameOver(){
		Startmenu.GetComponent<StartMenu> ().ShowMenu ();
	}

//	public void Pause(){
//		SoundManager.PlaySfx (SoundManager.Instance.soundClick);
//		if (Time.timeScale == 0) {
//			GUI.SetActive (true);
//			Time.timeScale = 1;
//		} else {
//			GUI.SetActive (false);
//			Time.timeScale = 0;
//		}
//	}

	public void StartGame(){
		GUI.SetActive (true);
		GameManager.Instance.StartGame ();
	}

	IEnumerator GameOverCo(float time){
		yield return new WaitForSeconds (time);

		Startmenu.SetActive (true);
	}

	public void OpenShop(){
		Shop.SetActive (true);
	
		SoundManager.PlaySfx (SoundManager.Instance.soundClick); 
	}

	public void OpenPlayMode(){
		PlayMode.SetActive (true);
		SoundManager.PlaySfx (SoundManager.Instance.soundClick);
	}

	public void ShowNotEnoughCoins(){
		NotEnoughCoins.SetActive (false);
	}
}
