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
			StartCoroutine (milk1 ());
		} else if (transition == 2) {
			correct = false;
			StartCoroutine (milk2 ());
		} else if (transition == 3) {
			correct = false;
			StartCoroutine (milk3 ());;
		} else if (transition == 0) {
			anim.SetInteger ("Milk", 0);
		}
	

		if (correct == true) {
			anim.SetInteger ("Milk", 0);
		} else {
			correct = false;
		}

	}

	IEnumerator milk1(){
		yield return new WaitForSeconds (1.5f);
		anim.SetInteger ("Milk", 1);
	}
	IEnumerator milk2(){
		yield return new WaitForSeconds (1.5f);
		anim.SetInteger ("Milk", 2);
	}
	IEnumerator milk3(){
		yield return new WaitForSeconds (1.5f);
		anim.SetInteger ("Milk", 3);
	}


}
