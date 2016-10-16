using UnityEngine;
using System.Collections;

public class AnimButton: MonoBehaviour {
	private  Animator 		animVacaLouca;


	public int pp;
	void Start () {
		animVacaLouca = GetComponent <Animator> ();
	}
	void Update () {



		if (PlayerPrefs.GetInt ("levelPlayer") == 11) {
			animVacaLouca.SetBool ("Actived",true);
		}
	}
}
