using UnityEngine;
using System.Collections;

public class ConfeteCow : MonoBehaviour {

	private Animator 	anim;
	public 	int 	 	change;

	public static int 	compare;

	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetInteger ("Change", 0);
	}
	
	void Update () {
		if (change == 1) {
			anim.SetInteger ("Change", 1);
		} else {
			anim.SetInteger ("Change", 0);
		}
		if (transform.position.y > Camera.main.orthographicSize) {
			change = 0;
		}

		compare = change;

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Confete") {
			change = 1;

		}
	}

}
