using UnityEngine;
using System.Collections;

public class BGTest : MonoBehaviour {

	public float smooth;

	public Transform player;

	void Update () {
		Movement ();
			
	}

	void Movement(){
		if (GameController.right == true && GameController.left == false){
			if (player.position.x < 8.8f) {
				transform.Translate (-smooth * Time.deltaTime, 0, 0);
			}
		}
		if (GameController.left == true && GameController.right == false ){
			if (player.position.x > -8.1f) {
				transform.Translate (smooth * Time.deltaTime, 0, 0);
			}
		}
	}

}
