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

	public static  bool		checkLose = false;

	private bool 			dead = false;
	public 	static bool 	VLPlayer = false;
	public 	GameObject 		deadVL;

	public  Text			timeString;
	public  Text 			highscoreString;

	public Text 			highscoreT;

	public static bool		trueTime = false;

	void Start () {
		anim 		= GetComponent  <Animator> ();
		loseSound	= GetComponent	<AudioSource> ();
		if (!dead) {
			velPlayer	= 7;
		}

	}

	void Update () {
		Movement ();
		milkT.text = ("MilkBox "+milkBox);
		highscoreT.text = ("HGS . " + PlayerPrefs.GetInt ("Highscore"));

		if (trueTime) {
			if (Function.timeI >= PlayerPrefs.GetInt ("Highscore")) {
				PlayerPrefs.SetInt ("Highscore", Function.timeI);
			}
		}
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
		SelectionGuide.ads = 1;
		dead  = true;
		right = false;
		left  = false;
		if (!VLPlayer) {
			StartCoroutine (PlayerDead ());
		}else {
			StartCoroutine (PlayerDeadVL ());
		}

	}

	IEnumerator PlayerDead () {
		yield return new WaitForSeconds (1f);
		checkLose = true;
		lose.SetActive (true);
		Countdown.stopSing = true;
		loseSound.Play ();

		Cows.chgLvl = 0;
		Candy.chgLvl = 0;
		MilkBox.chgLvl = 0;

		Cows.sleepCow = true;

		SelectionGuide.activeSound = false;

	} 

	IEnumerator PlayerDeadVL () {
		
		trueTime = false;
		yield return new WaitForSeconds (1f);
		checkLose = true;
		deadVL.SetActive 	(true);
		Countdown.stopSing = true;
		loseSound.Play ();

		Cows.chgLvl 		= 0;
		Candy.chgLvl 		= 0;
		MilkBox.chgLvl 		= 0;

		Cows.sleepCow 	= true;
		Cows.cowVelstatic = true;

		yellowCandy = false;

		SelectionGuide.activeSound = false;


		highscoreString.text = ("Seu Record: " + PlayerPrefs.GetInt ("Highscore"));
		timeString.text = ("Você Fez: " + (Function.timeI-1));
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

