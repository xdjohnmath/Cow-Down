﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SelectionGuide : MonoBehaviour {

	public GameObject 		panel;
	public GameObject 		win;
	public GameObject 		lose;

	public 	int 			level;
	private int 			cont = 1;

	public float 			timeToStart;
	public Text  			levelPause;
	public Text  			levelWin;

	public Text 			prefs;
	public int 				pref;

	private AudioSource[] 	checkVictory =  new AudioSource [4];
	public  AudioSource 	winSound;
	public	AudioSource 	loseSound;
	public 	AudioSource  	cow1;
	public 	AudioSource		menu;

	private float 			timeF;
	private int   			timeI;

	public static bool  	activeSound  = false;

	void Start (){
		checkVictory = GetComponents <AudioSource> ();
		winSound 	 = checkVictory [0];
		loseSound 	 = checkVictory [1];
		cow1 		 = checkVictory [2];

		if (PlayerPrefs.GetInt ("confgPrefs") != 1){
			PlayerPrefs.SetInt ("levelPlayer", 1);
		}

	}

	void Update (){
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		levelPause.text = ("Level " + level);
		levelWin.text 	= ("Level " + level);

		// Mostra o nível do player
		pref = PlayerPrefs.GetInt ("levelPlayer");
		prefs.text = (pref).ToString ();

		timeF += Time.deltaTime;
		timeI = (int)timeF;

		// Mugido das vaquinhas
		if (timeI % 10 == 0 && activeSound == true) {
			cow1.Play ();
		}
			
		if (!panel.activeSelf) {
			GameObject.Find ("Sound").GetComponent<AudioSource> ().volume = 0.0f;
		} else {
			GameObject.Find ("Sound").GetComponent<AudioSource> ().volume = 1.0f;
		}

		if (PlayerPrefs.GetInt ("confgPrefs") != 1){
			PlayerPrefs.SetInt ("levelPlayer", 1);
		}
	
		if (PlayerPrefs.GetInt ("levelPlayer") ==  11){
			//VACALOUCA!
		}

	}

	private void Victory () {
		if (!GameController.checkLose) {								// Só executa se nãou houver colisão
			if (GameController.milkBox > 0) {
				win.SetActive (true);
				lose.SetActive (false);
				Countdown.stopSing = true;
				winSound.Play ();
			} else {
				win.SetActive (false);
				lose.SetActive (true);
				Countdown.stopSing = true;
				loseSound.Play ();
			}
		}
	}

	private void ChangeLevel (){

		if (level == 1){
			Level1 ();
		}
		if (level == 2){
			Level2 ();
		}
		if (level == 3){
			Level3 ();
		}
		if (level == 4){
			Level4 ();
		}
		if (level == 5){
			Level5 ();
		}
		if (level == 6){
			Level6 ();
		}
		if (level == 7){
			Level7 ();
		}
		if (level == 8){
			Level8 ();
		}
		if (level == 9){
			Level9 ();
		}
		if (level == 10){
			Level10 ();
		}
	}
		
	public void  Restart (){
		ChangeLevel ();
		Cows.sleepCow =  false;
		win.SetActive 	(false);
		lose.SetActive 	(false);

		GameController.milkBox 	= 0;

		Candy.noSugar 	= true;

		MilkHUD.correct = true;

	}

	public void  Menu (){
		Cows.sleepCow =  false;
		win.SetActive 	(false);
		lose.SetActive 	(false);

		GameController.milkBox 	= 0;

		Candy.noSugar 	= true;

		if (level >= PlayerPrefs.GetInt("levelPlayer")) {
			PlayerPrefs.SetInt ("levelPlayer",level+=cont);
			PlayerPrefs.SetInt ("confgPrefs", 1);
		}

		SceneManager.LoadScene ("Jogo");

	}

	public void  NextLevel (){
		level += cont;
		ChangeLevel ();
		Cows.sleepCow =  false;
		win.SetActive 	(false);
		lose.SetActive 	(false);

		GameController.milkBox 	= 0;

		Candy.noSugar 	= true;

		if (level >= PlayerPrefs.GetInt ("levelPlayer")) {
			PlayerPrefs.SetInt ("levelPlayer", level);
			PlayerPrefs.SetInt ("confgPrefs", 1);
		}
	}

	public void  LoseRestart (){
		Cows.sleepCow =  false;
		win.SetActive 	(false);
		lose.SetActive 	(false);

		GameController.milkBox 	= 0;

		Candy.noSugar 	= true;

		GameController.checkLose = false;

		SceneManager.LoadScene ("Jogo");

	}
	// LEVELS //

																										// LEVEL1
	public void Level1 (){
		
		StartCoroutine (Routine1 ());
		StartCoroutine (Ending1  ());
	}

	public IEnumerator Routine1 (){
		panel.SetActive (false);

		yield return new WaitForSeconds (timeToStart);

		Cows.chgLvl 		= 1;
		Candy.chgLvl 		= 1;
		MilkBox.chgLvl 		= 1;

		MilkBox.milkBoxTime = 0;
		Function.timeF 		= 0;

		level = 1;

		activeSound = true;

	}

	public IEnumerator Ending1() {
		yield return new WaitForSeconds (46f);															// 39 (TIME LEVEL) + 7 (COUNTDOWN)
		Victory ();
		Cows.chgLvl 		= 0;
		Candy.chgLvl 		= 0;
		MilkBox.chgLvl 		= 0;

		Cows.sleepCow 	= true;

		activeSound 	= false;
	}

																										// LEVEL2
	public void Level2 (){

		StartCoroutine (Routine2 ());
		StartCoroutine (Ending2  ());
	}

	public IEnumerator Routine2 (){
		panel.SetActive (false);

		yield return new WaitForSeconds (timeToStart);

		Cows.chgLvl 		= 2;
		Candy.chgLvl 		= 2;
		MilkBox.chgLvl 		= 2;

		MilkBox.milkBoxTime = 0;
		Function.timeF 		= 0;

		level = 2;

		activeSound = true;
	}

	public IEnumerator Ending2() {
		yield return new WaitForSeconds (40f);
		Victory ();
		Cows.chgLvl 		= 0;
		Candy.chgLvl 		= 0;
		MilkBox.chgLvl 		= 0;

		Cows.sleepCow 	= true;
	
		activeSound = false;
	}

	                                                                                                   // LEVEL3
	public void Level3 (){

		StartCoroutine (Routine3 ());
		StartCoroutine (Ending3  ());
	}

	public IEnumerator Routine3 (){
		panel.SetActive (false);

		yield return new WaitForSeconds (timeToStart);

		Cows.chgLvl 		= 3;
		Candy.chgLvl 		= 3;
		MilkBox.chgLvl 		= 3;

		MilkBox.milkBoxTime = 0;
		Function.timeF 		= 0;

		level = 3;

		activeSound = true;
	}

	public IEnumerator Ending3() {
		yield return new WaitForSeconds (49f);
		Victory ();
		Cows.chgLvl 		= 0;
		Candy.chgLvl 		= 0;
		MilkBox.chgLvl 		= 0;

		Cows.sleepCow 	= true;

		activeSound = false;
	}

																										// LEVEL4
	public void Level4 (){

		StartCoroutine (Routine4 ());
		StartCoroutine (Ending4  ());
	}

	public IEnumerator Routine4 (){
		panel.SetActive (false);

		yield return new WaitForSeconds (timeToStart);

		Cows.chgLvl 		= 4;
		Candy.chgLvl 		= 4;
		MilkBox.chgLvl 		= 4;

		MilkBox.milkBoxTime = 0;
		Function.timeF 		= 0;

		level = 4;

		activeSound = true;
	}

	public IEnumerator Ending4() {
		yield return new WaitForSeconds (54f);
		Victory ();
		Cows.chgLvl 		= 0;
		Candy.chgLvl 		= 0;
		MilkBox.chgLvl 		= 0;

		Cows.sleepCow 	= true;

		activeSound = false;
	}

																										// LEVEL5
	public void Level5 (){

		StartCoroutine (Routine5 ());
		StartCoroutine (Ending5  ());
	}

	public IEnumerator Routine5 (){
		panel.SetActive (false);

		yield return new WaitForSeconds (timeToStart);

		Cows.chgLvl 		= 5;
		Candy.chgLvl 		= 5;
		MilkBox.chgLvl 		= 5;

		MilkBox.milkBoxTime = 0;
		Function.timeF 		= 0;

		level = 5;

		activeSound = true;
	}

	public IEnumerator Ending5() {
		yield return new WaitForSeconds (48f);
		Victory ();
		Cows.chgLvl 		= 0;
		Candy.chgLvl 		= 0;
		MilkBox.chgLvl 		= 0;

		Cows.sleepCow 	= true;

		activeSound = false;
	}

																										// LEVEL6
	public void Level6 (){

		StartCoroutine (Routine6 ());
		StartCoroutine (Ending6  ());
	}

	public IEnumerator Routine6 (){
		panel.SetActive (false);

		yield return new WaitForSeconds (timeToStart);

		Cows.chgLvl 		= 6;
		Candy.chgLvl 		= 6;
		MilkBox.chgLvl 		= 6;

		MilkBox.milkBoxTime = 0;
		Function.timeF 		= 0;

		level = 6;

		activeSound = true;
	}

	public IEnumerator Ending6() {
		yield return new WaitForSeconds (69f);
		Victory ();
		Cows.chgLvl 		= 0;
		Candy.chgLvl 		= 0;
		MilkBox.chgLvl 		= 0;

		Cows.sleepCow 	= true;

		activeSound = false;
	}

																										// LEVEL7
	public void Level7 (){

		StartCoroutine (Routine7 ());
		StartCoroutine (Ending7  ());
	}

	public IEnumerator Routine7 (){
		panel.SetActive (false);

		yield return new WaitForSeconds (timeToStart);

		Cows.chgLvl 		= 7;
		Candy.chgLvl 		= 7;
		MilkBox.chgLvl 		= 7;

		MilkBox.milkBoxTime = 0;
		Function.timeF 		= 0;

		level = 7;

		activeSound = true;
	}

	public IEnumerator Ending7() {
		yield return new WaitForSeconds (85f);
		Victory ();
		Cows.chgLvl 		= 0;
		Candy.chgLvl 		= 0;
		MilkBox.chgLvl 		= 0;

		Cows.sleepCow 	= true;

		activeSound = false;
	}

																										// LEVEL8
	public void Level8 (){

		StartCoroutine (Routine8 ());
		StartCoroutine (Ending8  ());
	}

	public IEnumerator Routine8 (){
		panel.SetActive (false);

		yield return new WaitForSeconds (timeToStart);

		Cows.chgLvl 		= 8;
		Candy.chgLvl 		= 8;
		MilkBox.chgLvl 		= 8;

		MilkBox.milkBoxTime = 0;
		Function.timeF 		= 0;

		level = 8;

		activeSound = true;
	}

	public IEnumerator Ending8() {
		yield return new WaitForSeconds (66f);
		Victory ();
		Cows.chgLvl 		= 0;
		Candy.chgLvl 		= 0;
		MilkBox.chgLvl 		= 0;

		Cows.sleepCow 	= true;

		activeSound = false;
	}

																										// LEVEL9
	public void Level9 (){

		StartCoroutine (Routine9 ());
		StartCoroutine (Ending9  ());
	}

	public IEnumerator Routine9 (){
		panel.SetActive (false);

		yield return new WaitForSeconds (timeToStart);

		Cows.chgLvl 		= 9;
		Candy.chgLvl 		= 9;
		MilkBox.chgLvl 		= 9;

		MilkBox.milkBoxTime = 0;
		Function.timeF 		= 0;

		level = 9;

		activeSound = true;
	}

	public IEnumerator Ending9() {
		yield return new WaitForSeconds (79f);
		Victory ();
		Cows.chgLvl 		= 0;
		Candy.chgLvl 		= 0;
		MilkBox.chgLvl 		= 0;

		Cows.sleepCow 	= true;

		activeSound = false;
	}

																										// LEVEL10
	public void Level10 (){

		StartCoroutine (Routine10 ());
		StartCoroutine (Ending10  ());
	}

	public IEnumerator Routine10 (){
		panel.SetActive (false);

		yield return new WaitForSeconds (timeToStart);

		Cows.chgLvl 		= 10;
		Candy.chgLvl 		= 10;
		MilkBox.chgLvl 		= 10;

		MilkBox.milkBoxTime = 0;
		Function.timeF 		= 0;

		level = 10;

		activeSound = true;
	}

	public IEnumerator Ending10() {
		yield return new WaitForSeconds (83f);
		Victory ();
		Cows.chgLvl 		= 0;
		Candy.chgLvl 		= 0;
		MilkBox.chgLvl 		= 0;

		Cows.sleepCow 	= true;

		activeSound = false;

	}

}




