using UnityEngine;
using System.Collections;

public class MilkHUD : MonoBehaviour {

	private 	Animator anim;
	public int 	transition;

	public static bool correct = false;

	public		ParticleSystem newMilk;

	void Start () {
		anim = GetComponent<Animator> ();
		newMilk.Stop ();
	}
	
	void Update () {

		transition = GameController.milkBox;

		if (transition == 1) {
			correct = false;
			anim.SetInteger ("Milk", 1);
		} else if (transition == 2) {
			correct = false;
			anim.SetInteger ("Milk", 2);
		} else if (transition == 3) {
			correct = false;
			anim.SetInteger ("Milk", 3);
		} else if (transition == 0) {
			anim.SetInteger ("Milk", 0);
		}
	

		if (correct == true) {
			anim.SetInteger ("Milk", 0);
		} else {
			correct = false;
		}
	}
}
