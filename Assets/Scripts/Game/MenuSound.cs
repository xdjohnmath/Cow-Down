using UnityEngine;
using System.Collections;

public class MenuSound : MonoBehaviour {

	public AudioSource musicMenu;
	public static bool active = false;


	void Awake(){
		if (PlayerPrefs.GetInt ("tomenu") == 0) {
			StartCoroutine (MenuMusic ());
			DontDestroyOnLoad (this);
		}else {
			DontDestroyOnLoad (this);
		}
	}

	IEnumerator MenuMusic() {
		yield return new WaitForSeconds (8f);
		musicMenu.Play ();
	}
}
