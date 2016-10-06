using UnityEngine;
using System.Collections;

public class MilkColision : MonoBehaviour {

	private Animator 	anim;
	public 	AudioSource	sound;

	void Start () {
		anim = GetComponent		<Animator> ();
		sound = GetComponent 	<AudioSource> ();
		anim.SetBool ("Active", false);
	}

	public void BackAnim (){
		anim.SetBool ("Active", false);
	}

	void OnTriggerEnter2D (Collider2D other){

		if (other.CompareTag ("MilkBox")){
			anim.SetBool ("Active", true);
			sound.Play ();
		}


	}
}
