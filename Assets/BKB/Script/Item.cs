using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item : MonoBehaviour {
	public bool isFree = false;
	public int ID;		//set the ID of the item
	public int price;		//set the price of the item
	public Image itemImage;		//the image of the item
	bool isUnlock;	//check if it's unlocked or not
	public AudioClip soundUnlock;
	public GameObject Shop;
	public GameObject StartMenu;

	StartMenu _StartMenu;

	// Use this for initialization
	void Start () {
		CheckUnlock ();		//check

	}

	private void CheckUnlock(){
		if (isFree)
			isUnlock = true;
		else
			isUnlock = ItemManager.Instance.isUnlocked (ID);
		
		if (isUnlock)
			itemImage.sprite = ItemManager.Instance.GetItemImage (ID);		//if the ball is unlocked, set the image for it
	}

	//call by the button event itself
	public void Click(){
		if (!isUnlock)
			CheckCoinsToUnlock ();		//if this item is not unlocked then unlock it
		else {
			TheBall.Instance.BallSprite = ItemManager.Instance.GetItemImage (ID);		//set image
			TheBall.Instance.ChangeBallSprite ();	//change image of the current ball 
			PlayerPrefs.SetInt (GlobalValue.ChoosenBall, ID);		//save the choosen ball, when you play the game again, it will take this ball
			Shop.SetActive(false);
			_StartMenu.ShowMenu ();
		}	
	}

	private void CheckCoinsToUnlock(){
		if (GameManager.Instance.SavedStars >= price) {
			GameManager.Instance.SavedStars -= price;
			ItemManager.Instance.Unlock (ID);
			CheckUnlock ();
			SoundManager.PlaySfx (soundUnlock);
		} else {
			MenuManager.Instance.ShowNotEnoughCoins ();
		}
	}
}
