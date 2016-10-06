using UnityEngine;
using System.Collections;

public class Shine : MonoBehaviour {


	public static int shineColor;

	void Start () {
	
	}
	
	void Update () {
		if (shineColor == 1) {	
			SpriteRenderer color = GetComponent <SpriteRenderer> ();
			color.color = new Color (1, 0.92f, 0.016f, 1);
		}
		if (shineColor == 2) {	
			SpriteRenderer color = GetComponent <SpriteRenderer> ();
			color.color = new Color (0, 1, 0, 1);
		}
		if (shineColor == 3) {	
			SpriteRenderer color = GetComponent <SpriteRenderer> ();
			color.color = new Color (1, 0, 0, 1);
		}

	}
}
