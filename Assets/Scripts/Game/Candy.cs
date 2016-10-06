using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class Candy : MonoBehaviour {

	public float		vel;
	public int    		candy;
	public float  		positionx;
	public float  		positiony;
	private float		height;

	public static int 	chgLvl;

	public static bool  noSugar = false;

	public GameObject 	yellowPower;
	public GameObject 	greenPower;
	public GameObject	redPower;

	private AudioSource [] 	powers = new AudioSource[3];
	public  AudioSource		yellowSound, greenSound, redSound;


	void Start (){
		height = GetComponent<SpriteRenderer> ().bounds.size.y;

		powers 		= GetComponents <AudioSource> ();
		yellowSound = powers [0];
		greenSound	= powers [1];
		redSound	= powers [2];

	}

	void Update(){
		ChangeLevel ();
//			Level1 ();

		if (candy == 1) {						//Trocar a cor e transladar
			Falling();
			SpriteRenderer renderer = GetComponent<SpriteRenderer>();
			renderer.color = new Color(1, 0.92f, 0.016f, 1);
			Shine.shineColor = 1;
		}
		if (candy == 2) {
			Falling();
			SpriteRenderer renderer = GetComponent<SpriteRenderer>();
			renderer.color = new Color(0, 1, 0, 1); 
			Shine.shineColor = 2;
		}
		if (candy == 3) {
			Falling();
			SpriteRenderer renderer = GetComponent<SpriteRenderer>();
			renderer.color = new Color(1, 0, 0, 1); 
			Shine.shineColor = 3;
		}

		if (noSugar == true){
			StartCoroutine (NoSugar ());
		}else{
			noSugar = false;
		}
			
	}

	IEnumerator NoSugar(){
		Function.timeI = 0;
		candy = 0;
		yield return new WaitForSeconds (0.5f);
		noSugar = false;
	}

	// Translação
	void Falling(){
		transform.Translate (0, -vel * Time.deltaTime, 0);
		if (transform.position.y + height < -Camera.main.orthographicSize) {
			transform.position = new Vector2 (positionx, positiony);
			vel = 0;
		}
	}

	// Tratamento de colisão
	public IEnumerator YellowCandy(){								// Player não recebe dano por 5 segundos
		PowerActive.staticPower = 1;
		GameController.yellowCandy = true;
			yield return new WaitForSeconds (5f);
				PowerActive.staticPower = 0;
				GameController.yellowCandy = false;
	}

	public IEnumerator GreenCandy(){								// Player se move mais rápido
		GameController.velPlayer += GameController.greenVel;
		PowerActive.staticPower = 2;
			yield return new WaitForSeconds (5f);
				GameController.velPlayer -= GameController.greenVel;
				PowerActive.staticPower = 0;
	}

	public IEnumerator RedCandy(){									// Vacas e caixas de Leite demoram mais para cair
		PowerActive.staticPower = 3;
		Cows.redCandy = true;										// (Ajustar o redCandy em Cows como false na marcação de velocidade normal)	
			yield return new WaitForSeconds (5f);
				PowerActive.staticPower = 0;
				Cows.redCandy = false;

	}

	//Colisão
	void OnTriggerEnter2D(Collider2D other){
		
		if (other.CompareTag ("Player")){
			if (candy == 1) {
				yellowSound.Play ();
				StartCoroutine (YellowCandy ());
					transform.position = new Vector2 (positionx, positiony);
					vel = 0;
			}
			if (candy == 2) {
				greenSound.Play ();
				StartCoroutine (GreenCandy ());
				transform.position = new Vector2 (positionx, positiony);
				vel = 0;
			}
			if (candy == 3) {
				redSound.Play ();
				StartCoroutine   (RedCandy ());
				transform.position = new Vector2 (positionx, positiony);
				vel = 0;
			}	
		}
	}

	//Fases
	void Level1 (){									// No action
	}

	void Level2 (){									// No action
	}

	void Level3 (){
		if (Function.timeI == 0){
			positionx = 0;
			positiony = 6;
			vel = 2;
			transform.position = new Vector2 (positionx, positiony);
		}
		if (Function.timeI == 32){
			candy = 1;
		}
	}

	void Level4	(){
		if (Function.timeI == 0){
			positionx = 0;
			positiony = 6;
			vel = 3;
			transform.position = new Vector2 (positionx, positiony);
		}
		if (Function.timeI == 31){
			candy = 2;
		}
	}

	void Level5 (){
		if (Function.timeI == 0){
			positionx = 8;
			positiony = 6;
			vel = 4;
			transform.position = new Vector2 (positionx, positiony);
		}
		if (Function.timeI == 19){
			candy = 1;
		}
		if (Function.timeI == 22){
			positionx =  4.5F;
			positiony =  6;
			transform.position = new Vector2 (positionx, positiony);
		}
		if (Function.timeI == 28){
			candy = 2;
			vel = 4;
		}

	}

	void Level6 (){
		if (Function.timeI == 0){
			positionx = 0;
			positiony = 6;
			vel = 4;
			transform.position = new Vector2 (positionx, positiony);
		}
		if (Function.timeI == 40){
			candy = 3;
		}
	}

	void Level7 (){
		if (Function.timeI == 0) {
			positionx = 5;
			positiony = 6;
			vel = 4.5f;
			transform.position = new Vector2 (positionx, positiony);
		}
		if (Function.timeI == 34) {
			candy = 1;
		}
		if (Function.timeI == 40) {
			positionx = 0;
			positiony = 6;
			transform.position = new Vector2 (positionx, positiony);
		}
		if (Function.timeI == 44) {
			candy = 3;
			vel = 4.5f;
		}
	
	}

	void Level8 (){
		if (Function.timeI == 0) {
			positionx = -5;
			positiony = 6;
			vel = 4.5f;
			transform.position = new Vector2 (positionx, positiony);
		}
		if (Function.timeI == 14) {
			candy = 2;
		}
		if (Function.timeI == 20) {
			positionx = 7;
			positiony = 6;
			transform.position = new Vector2 (positionx, positiony);
		}
		if (Function.timeI == 28) {
			candy = 3;
			vel = 4.5f;
		}

	}

	void Level9 (){
		if (Function.timeI == 0) {
			positionx = 6;
			positiony = 6;
			vel = 4.7f;
			transform.position = new Vector2 (positionx, positiony);
		}
		if (Function.timeI == 18) {
			candy = 2;
		}
		if (Function.timeI == 22) {
			positionx = 0;
			positiony = 6;
			transform.position = new Vector2 (positionx, positiony);
		}
		if (Function.timeI == 29) {
			candy = 1;
			vel = 4.7f;
		}
		if (Function.timeI == 35) {
			positionx = 7;
			positiony = 6;
			transform.position = new Vector2 (positionx, positiony);
		}
		if (Function.timeI == 52) {
			candy = 3;
			vel = 4.7f;
		}
	}

	void Level10 (){
		if (Function.timeI == 0) {
			positionx = 6f;
			positiony = 6;
			vel = 5.0f;
			transform.position = new Vector2 (positionx, positiony);
		}
		if (Function.timeI == 18) {
			candy = 3;
		}
		if (Function.timeI == 20) {
			positionx = -4;
			positiony = 6;
			transform.position = new Vector2 (positionx, positiony);
		}
		if (Function.timeI == 51) {
			candy = 1;
			vel = 5.0f;
		}
		if (Function.timeI == 60) {
			positionx = 0;
			positiony = 6;
			transform.position = new Vector2 (positionx, positiony);
		}
		if (Function.timeI == 66) {
			candy = 2;
			vel = 5.0f;
		}
	}

	void ChangeLevel (){

		if (chgLvl == 1){
			Level1 ();
		}
		if (chgLvl == 2){
			Level2 ();
		}
		if (chgLvl == 3){
			Level3 ();
		}
		if (chgLvl == 4){
			Level4 ();
		}
		if (chgLvl == 5){
			Level5 ();
		}
		if (chgLvl == 6){
			Level6 ();
		}
		if (chgLvl == 7){
			Level7 ();
		}
		if (chgLvl == 8){
			Level8 ();
		}
		if (chgLvl == 9){
			Level9 ();
		}
		if (chgLvl == 10){
			Level10 ();
		}

	}
}
