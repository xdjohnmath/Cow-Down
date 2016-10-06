using UnityEngine;
using System.Collections;

public class SoundMenu : MonoBehaviour {

	private AudioSource	[] 	soundMenu = new AudioSource[2];
	public 	AudioSource 	soundM1;
	public 	AudioSource 	soundM2;


	void Start () {
		soundMenu = GetComponents <AudioSource> ();
		soundM1 = soundMenu [0];
		soundM2 = soundMenu [1];
	}
	public void SoundMenu1(){
		soundM1.Play ();
	}

	public void SoundMenu2(){
		soundM2.Play ();
	}
}
