using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

	private Animator anim;

	public GameObject panel;

	public int		games;

	void Start () {
		anim = GetComponent <Animator>();
		PlayerPrefs.SetInt ("Games", games);

		games++;

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
		if (games > 1){
			panel.SetActive (true);
		}
	}
	public void Tutorial6() {
		if (games <= 1){
			panel.SetActive (true);
		}
	}


	public void Game () {
		SceneManager.LoadScene ("Jogo");
	}

}
