using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {
	public Text floatingText;
	public float timeToLive = 1;

	void Start(){
		Destroy (gameObject, timeToLive);
	}

	public void SetText(string text, Color color){
		floatingText.color = color;
		floatingText.text = text;
	}
}
