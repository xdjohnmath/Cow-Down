using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour {

	public 	Button 		button;
	public 	int 		levelNumber;

	public 	Sprite 		disable;
	public 	GameObject 	number;

	void Start () {		
		//PlayerPrefs.SetInt ("levelPlayer", 1);					//Scripts retirados para que o playerprefs funcione!

	}

	void Update() {
		PlayerPrefs.GetInt ("levelPlayer");
		if (levelNumber > PlayerPrefs.GetInt ("levelPlayer")) {
			button.interactable = false;
			button.GetComponent<Image> ().sprite = disable;
			number.SetActive (false);
		}
	}




}	
