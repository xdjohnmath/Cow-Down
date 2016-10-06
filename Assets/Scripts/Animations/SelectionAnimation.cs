using UnityEngine;
using System.Collections;

public class SelectionAnimation : MonoBehaviour {

	private Animator anim;
	public 	int 	 change;

	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	void Update () {
		if (change == 1){
			anim.SetInteger ("change", 1);
		}else if (change == 2){
			anim.SetInteger ("change", 2);
		}

	
	}
}
