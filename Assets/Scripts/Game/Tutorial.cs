using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

	private Animator anim;

	public GameObject panel;

	void Start () {
		anim = GetComponent <Animator>();
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
		panel.SetActive (true);
	}

	public void Game () {
		SceneManager.LoadScene ("Jogo");
	}

}
