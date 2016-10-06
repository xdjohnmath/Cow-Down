using UnityEngine;
using System.Collections;

public class Confete : MonoBehaviour {

	public	int 	   		change;
	private Animator   		anim;

	public 	AudioSource 	confete;

	void Start () {
		anim 	= GetComponent <Animator> ();
		confete = GetComponent <AudioSource> ();

	}

	void Update () {
		if (change == 1){
			anim.SetInteger ("Change", 1);

		}else{
			anim.SetInteger ("Change", 0);
		
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Impar" || other.tag == "Par"){
			change = 1;
			confete.Play ();
		}
	}

	public void Stop() {
		change = 0;
	}

}
