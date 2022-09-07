using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour {
	public static Upgrade Instance;

	public bool isFree = false;
	public int price;		//set the price of the item
	public Image itemImage;		//the image of the item
	bool isUnlock;	//check if it's unlocked or not
	public AudioClip soundUnlock;
	public GameObject Shop;
	public GameObject StartMenu;
	public int levelz = 1;
	StartMenu _StartMenu;

	// Use this for initialization
	void Start () {
		CheckUnlock ();		//check

	}

	private void CheckUnlock(){
		if (isFree)
			isUnlock = true;
		
		} 

	//call by the button event itself
	public void Click(){
		if (!isUnlock) {
			if (levelz < 5) {
				levelz = levelz + 1;
				isUnlock = false;
			}
			CheckCoinsToUnlock ();	
		}//if this item is not unlocked then unlock it
		else {
				//set image
				//save the choosen ball, when you play the game again, it will take this ball
				//Shop.SetActive(false);
				//_StartMenu.ShowMenu ();
			}	
		}


	private void CheckCoinsToUnlock(){
		if (GameManager.Instance.SavedStars >= price) {
			GameManager.Instance.SavedStars -= price;
			//ItemManager.Instance.Unlock ();
			CheckUnlock ();
			SoundManager.PlaySfx (soundUnlock);
		} else {
			MenuManager.Instance.ShowNotEnoughCoins ();
		}
	}

}
