using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

	private Animator anim;

	public GameObject panel;

	public int games;

	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		anim = GetComponent <Animator>();
		//PlayerPrefs.SetInt ("Games", games);

	}
	public void Tutorial1() {
		anim.SetInteger ("Transition",1);
	}
	public void Tutorial2() {
		anim.SetInteger ("Transition",2);
	}
	public void Tutorial3() {
		anim.SetInteger ("Transition",3);
	}
	public void Tutorial4() {
		anim.SetInteger ("Transition",4);
	}
	public void Tutorial5() {
		if (PlayerPrefs.GetInt ("levelPlayer") == 1){
			panel.SetActive (true);
		}else {
			panel.SetActive (false);
		}
	}
	public void Tutorial6() {
		if (PlayerPrefs.GetInt ("levelPlayer") > 1){
			panel.SetActive (true);
		}
		else {
			panel.SetActive (false);
		}
	}


	public void Game () {
		SceneManager.LoadScene ("Jogo");
	}

}
