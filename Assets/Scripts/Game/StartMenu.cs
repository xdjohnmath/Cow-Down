using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class StartMenu : MonoBehaviour {

	private Animator	anim;

	public 	GameObject 	credit;
	public	GameObject	exit;
	public	GameObject	panel;
	public static int 	animRoll;

	public 	bool 		isMuted = false;


	void Start () {
		anim	= GetComponent	<Animator> ();
	}
	
	void Update () {
		StartCoroutine (ChangeAnim ());
		if (PlayerPrefs.GetInt ("tomenu") == 1) {
			anim.SetInteger ("Change", 3);
		}

		if (isMuted) {
			AudioListener.volume = 0.0f;
		} else {
			AudioListener.volume = 1.0f;
		}

	}

	IEnumerator ChangeAnim(){
		yield return new WaitForSeconds (2.35f);
		PlayerPrefs.SetInt ("tomenu",0);
	}

	//  Order

	//  . Canvas
	//  . Scene2
	//  . Scene2.5
	//  . Scene3


	public void ChangeScene() { // to scene 2
		animRoll = 1;
		anim.SetInteger ("Change", animRoll);
	}

	public void ChangeScene2(){ // to scene 2.5
		animRoll = 2;
		anim.SetInteger ("Change", animRoll);
	}

	public void TouchedScene() { // to scene 3
		animRoll = 3;
		anim.SetInteger ("Change", animRoll);
	}

	public void Play () {
		StartCoroutine (LoadingPlay ());
	}

	public IEnumerator LoadingPlay(){
		animRoll = 4;
		anim.SetInteger ("Change", animRoll);
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadScene ("Instructions");

	}

	public void Credits () {
		panel.SetActive (true);
		credit.SetActive (true);

	}

	public void CreditsOff () {
		panel.SetActive (false);
		credit.SetActive (false);
		Time.timeScale = 1;
	}

	public void Exit () {
		panel.SetActive (true);
		exit.SetActive (true);
		Time.timeScale = 0;
	}

	public void ConfirmExit () {
		Application.Quit ();
	}

	public void CancelExit () {
		panel.SetActive (false);
		exit.SetActive (false);
		Time.timeScale = 1;
	}

	public void Mute() {
		isMuted = !isMuted;
	}


}
