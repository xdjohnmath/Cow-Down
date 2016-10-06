using UnityEngine;
using System.Collections;

public class PowerActive : MonoBehaviour {

	private int 			power;
	private Animator 		anim;
	public 	static int 		staticPower;

	void Start () {
		anim 		= GetComponent	<Animator> ();


	}

	void Update () {
		power = staticPower;
		Anim ();
	}

	void Anim (){
		if (power == 1){
			anim.SetInteger ("PowerActive", 1);
		}
		else if (power == 2){
			anim.SetInteger ("PowerActive", 2);
		}
		else if (power == 3){
			anim.SetInteger ("PowerActive", 3);
		}
		else if (power == 0) {
			anim.SetInteger ("PowerActive", 0);
		}
	}
}