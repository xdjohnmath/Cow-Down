using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public 	static float 	velPlayer	= 7;
	public 	static float 	greenVel 	= 4;
	private Animator		anim;

	public  static bool 	yellowCandy = false;

	public  int  			colision;
	public  Text 			col;

	public 	static int 		milkBox;
	public 	Text 			milkT;
												// PARALLAX
	public 	static bool 	right;
	public 	static bool 	left;

	private int 			movementPlayer;

	public	GameObject 		lose;
	public	AudioSource 	loseSound;

	public static bool 		checkLose = false;

	private bool 			dead = false;

	void Start () {
		anim 		= GetComponent  <Animator> ();
		loseSound	= GetComponent	<AudioSource> ();
	}


	void Update () {
		Movement ();
		milkT.text = ("MilkBox "+milkBox);

	}

	void Movement (){
		if (!dead) {
		if (Input.GetKey (KeyCode.RightArrow) || (movementPlayer == 1)) {
			if (transform.position.x < 8.8f) {
				anim.SetFloat ("Turn", 1);
				transform.Translate (velPlayer * Time.deltaTime, 0, 0);
				right = true;
				left = false;
			}
		} else if (Input.GetKey (KeyCode.LeftArrow) || (movementPlayer == 2)) {
			if (transform.position.x > -8.1f) {
				anim.SetFloat ("Turn", 0);
				transform.Translate (-velPlayer * Time.deltaTime, 0, 0);
				left = true;
				right= false;
			}
		} else if (movementPlayer == 0){
				anim.SetFloat ("Turn", 0.5f);
				right = false;
				left = false;
			}
		}
		else {
			velPlayer = 0;
			anim.SetFloat ("Turn", 1.5f);
		}
	}

	void HitnKill () {
		dead = true;
		StartCoroutine (PlayerDead ());
	}

	IEnumerator PlayerDead () {
		yield return new WaitForSeconds (1.5f);
		checkLose = true;
		lose.SetActive 	(true);
		Countdown.stopSing = true;
		loseSound.Play ();

		Cows.chgLvl 		= 0;
		Candy.chgLvl 		= 0;
		MilkBox.chgLvl 		= 0;

		Cows.sleepCow 	= true;

		SelectionGuide.activeSound = false;
	}

	public void Right (){
		movementPlayer = 1;
	}

	public void Left (){
		movementPlayer = 2;
	}

	public void Stop (){
		movementPlayer = 0;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (yellowCandy == false) {
			if (other.CompareTag ("Par") || other.CompareTag ("Impar") && (ConfeteCow.compare == 0) ) {
				colision++;
				col.text = ("Muu" + colision);
			
				HitnKill ();
			}
		}

		if (other.CompareTag ("MilkBox")){
			milkBox++;

		}

	}
}

