using UnityEngine;
using System.Collections;

public class CorrectMilkEnding : MonoBehaviour {

	private Animator   anim;
	public  GameObject panel;
	public  int 	   transition;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	void Update () {

		transition = GameController.milkBox;

		if (transition == 1) {
			anim.SetInteger ("Milk", 1);
		} else if (transition == 2) {
			anim.SetInteger ("Milk", 2);
		} else if (transition == 3) {
			anim.SetInteger ("Milk", 3);
		} else if (transition == 0) {
			anim.SetInteger ("Milk", 0);
		}


		if (!panel.activeSelf){
			transition = 0;
		}
	
	}
}
