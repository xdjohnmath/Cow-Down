using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Function : MonoBehaviour {

	public static float	timeF;
	public static int	timeI;
	public Text   	 	timeT;

	public GameObject	pausePanel;
	private bool	   	paused;

	public static bool 	removePanel;

	public static bool 	checkActived = false;

	public bool 		isMuted = false;

	public GameObject 	left;
	public GameObject 	right;

	public GameObject	soundOn;
	public GameObject	soundOff;

	public GameObject 	controles;

	void Start (){
		paused 		= false;
		removePanel = false;
	}

	void Update () {
		Timer ();

		if (removePanel == true){
			ReturnPause ();
		}else{
			removePanel = false;
		}

		if (isMuted) {
			AudioListener.volume = 0.0f;
			soundOn.SetActive (false);
			soundOff.SetActive (true);
		} else {
			AudioListener.volume = 1.0f;
			soundOn.SetActive (true);
			soundOff.SetActive (false);
		}

	}

	public void PlayInstructions (){
		StartCoroutine (Instruction ());
	}

	IEnumerator Instruction () {
		controles.SetActive (true);
		yield return new WaitForSeconds (6f);
		controles.SetActive (false);
	}

	void Timer (){
		timeF += Time.deltaTime;
		timeI = (int)timeF;
		timeT.text = ("LEVELTIME " + timeI);
	}

	public void Pause (){
		paused = true;
		if (paused == true){
			Time.timeScale = 0;
			AudioListener.pause = true;
			pausePanel.SetActive (true);
			left.SetActive (false);
			right.SetActive (false);
		} else {
			ReturnPause ();
		}
	}

	public void ReturnPause (){
		Time.timeScale = 1;
		AudioListener.pause = false;
		pausePanel.SetActive (false);
		left.SetActive 	(true);
		right.SetActive (true);
	}

	public void GameToMenu () {
		Time.timeScale = 1;
		timeF = 0;
		AudioListener.pause = false;
		SceneManager.LoadScene ("Jogo");
	}

	public void SelToMenu (){
		GameObject soundObject = GameObject.Find ("Sound");
		Destroy (soundObject);
		PlayerPrefs.SetInt ("tomenu", 1);
		SceneManager.LoadScene ("StartMenu");
	}
		
	public void Sound () {
		isMuted = !isMuted;

	}
}
