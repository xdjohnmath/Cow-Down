using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour {

	private Animator 		countdown;
	public	AudioSource [] 	bgm = new AudioSource[2];
	public 	AudioSource 	start;
	public 	AudioSource 	loop;

	public static bool stopSing;

	void Start (){
		countdown 	= GetComponent <Animator> ();

		bgm			= GetComponents <AudioSource> ();
		start 		= bgm [0];
		loop 		= bgm [1];
	
	}

	void Update(){
		if (stopSing == true){
			loop.Stop ();
			stopSing = false;
		}else {
			stopSing = false;
		}
	}

	public void Animator (){
		StartCoroutine (CountAnim   ());

	}

	IEnumerator CountAnim (){
		countdown.SetInteger ("active", 1);
		yield return new WaitForSeconds (7f);
		countdown.SetInteger ("active", 0);
	}

	public void IntroBGM(){
		start.Play ();
		StartCoroutine (PlayLoopBGM ());

	}
		
	IEnumerator PlayLoopBGM(){
		yield return new WaitForSeconds (4.5f);
		loop.Play ();
	}

}