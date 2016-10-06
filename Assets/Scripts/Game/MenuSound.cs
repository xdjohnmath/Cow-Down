using UnityEngine;
using System.Collections;

public class MenuSound : MonoBehaviour {

	public AudioSource musicMenu;
	public static bool active = false;


	void Awake(){
		StartCoroutine (MenuMusic ());
		DontDestroyOnLoad (this);
	}

	IEnumerator MenuMusic() {
		yield return new WaitForSeconds (14f);
		musicMenu.Play ();
	}
}
