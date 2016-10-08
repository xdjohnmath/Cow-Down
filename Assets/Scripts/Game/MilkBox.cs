using UnityEngine;
using System.Collections;

public class MilkBox : MonoBehaviour {

	public  float 		vel;
	private float 		height;

	private float 		positionx;
	private float 		positiony;

	public int    		milkSet = 0;
	public static float milkBoxTime;
	public int 			timeInt;

	public static int 	chgLvl;

	public bool 		colision;

	public static bool 	colAnim;

	private Animator	anim;

	void Start () {
		height = GetComponent<SpriteRenderer> ().bounds.size.y;
		anim   = GetComponent <Animator> ();
	}
	
	void Update () {
		ChangeLevel ();
	//	Level1 ();

		milkBoxTime += Time.deltaTime;
		timeInt = (int) milkBoxTime ; 

	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.CompareTag ("Player")) {

			colision = true;
		}

		if(other.CompareTag ("Confete")){
			anim.SetBool ("onFloor", true);
			StartCoroutine (OnFloor ());
		}
	}

	IEnumerator OnFloor () {
		yield return new WaitForSeconds(1f);
		anim.SetBool ("onFloor", false);
	}

	void Level1 () {
		
		if (timeInt == 8){									// Primeiro Objeto
			milkSet = 	1;
		}
		if (timeInt == 20){									// Segundo Objeto
			milkSet = 	2;
		}
		if (timeInt == 27){									// Terceiro Objeto
			milkSet = 	3;
		}

		if (milkSet == 0){									// Para parar a translação
			vel = 0;
		}

		if (timeInt == 0){
			transform.position = new Vector2 (6, 6); 		// Posição do primeiro Objeto
		}

		if (milkSet == 1) {
			vel = 3.0f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (-6, 6);	// Posição do segundo Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 2) {
			vel = 3.0f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (0, 6);	// Posição do terceiro Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 3) {
			vel = 3.0f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (0, 6);	// Retorno ao 0
				milkSet = 0;
				colision = false;
			}
		}			
	}

	void Level2 () {
		if (timeInt == 9){									// Primeiro Objeto
			milkSet = 	1;
		}
		if (timeInt == 21){									// Segundo Objeto
			milkSet = 	2;
		}
		if (timeInt == 25){									// Terceiro Objeto
			milkSet = 	3;
		}

		if (milkSet == 0){									// Para parar a translação
			vel = 0;
		}

		if (timeInt == 0){
			transform.position = new Vector2 (-6, 6); 		// Posição do primeiro Objeto
		}

		if (milkSet == 1) {
			vel = 3.0f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (5, 6);	// Posição do segundo Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 2) {
			vel = 3.0f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (5, 6);	// Posição do terceiro Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 3) {
			vel = 3.0f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (0, 6);	// Retorno ao 0
				milkSet = 0;

			}
		}			
	}

	void Level3 () {
		if (timeInt == 9){									// Primeiro Objeto
			milkSet = 	1;
		}
		if (timeInt == 21){									// Segundo Objeto
			milkSet = 	2;
		}
		if (timeInt == 36){									// Terceiro Objeto
			milkSet = 	3;
		}

		if (milkSet == 0){									// Para parar a translação
			vel = 0;
		}

		if (timeInt == 0){
			transform.position = new Vector2 (8, 6); 		// Posição do primeiro Objeto
		}

		if (milkSet == 1) {
			vel = 3.0f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (-1, 6);	// Posição do segundo Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 2) {
			vel = 3.0f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (0, 6);	// Posição do terceiro Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 3) {
			vel = 3.0f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (0, 6);	// Retorno ao 0
				milkSet = 0;
				colision = false;
			}
		}			
	}

	void Level4 () {
		if (timeInt == 9){									// Primeiro Objeto
			milkSet = 	1;
		}
		if (timeInt == 23){									// Segundo Objeto
			milkSet = 	2;
		}
		if (timeInt == 36){									// Terceiro Objeto
			milkSet = 	3;
		}

		if (milkSet == 0){									// Para parar a translação
			vel = 0;
		}

		if (timeInt == 0){
			transform.position = new Vector2 (8, 6); 		// Posição do primeiro Objeto
		}

		if (milkSet == 1) {
			vel = 3.0f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (-1, 6);	// Posição do segundo Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 2) {
			vel = 3.0f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (0, 6);	// Posição do terceiro Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 3) {
			vel = 3.0f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (0, 6);	// Retorno ao 0
				milkSet = 0;
				colision = false;
			}
		}			
	}

	void Level5 () {
		if (timeInt == 9){									// Primeiro Objeto
			milkSet = 	1;
		}
		if (timeInt == 15){									// Segundo Objeto
			milkSet = 	2;
		}
		if (timeInt == 34){									// Terceiro Objeto
			milkSet = 	3;
		}

		if (milkSet == 0){									// Para parar a translação
			vel = 0;
		}

		if (timeInt == 0){
			transform.position = new Vector2 (-8, 6); 		// Posição do primeiro Objeto
		}

		if (milkSet == 1) {
			vel = 4.0f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (6, 6);	// Posição do segundo Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 2) {
			vel = 4.0f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (-5, 6);	// Posição do terceiro Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 3) {
			vel = 4.0f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (0, 6);	// Retorno ao 0
				milkSet = 0;
				colision = false;
			}
		}			
	}

	void Level6 () {
		if (timeInt == 13){									// Primeiro Objeto
			milkSet = 1;
		}
		if (timeInt == 31){									// Segundo Objeto
			milkSet = 2;
		}
		if (timeInt == 46){									// Terceiro Objeto
			milkSet = 3;
		}

		if (milkSet == 0){									// Para parar a translação
			vel = 0;
		}

		if (timeInt == 0){
			transform.position = new Vector2 (-8, 6); 		// Posição do primeiro Objeto
		}

		if (milkSet == 1) {
			vel = 4.5f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (8, 6);	// Posição do segundo Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 2) {
			vel = 4.5f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (0, 6);	// Posição do terceiro Objeto
				milkSet = 0;
				colision = false;
			}
		}
			if (milkSet == 3) {
			vel = 4.5f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (0, 6);	// Retorno ao 0
				milkSet = 0;
				colision = false;
			}
		}			
	}

	void Level7 (){
		if (timeInt == 25){									// Primeiro Objeto
			milkSet = 1;
		}
		if (timeInt == 40){									// Segundo Objeto
			milkSet = 2;
		}
		if (timeInt == 49){									// Terceiro Objeto
			milkSet = 3;
		}

		if (milkSet == 0){									// Para parar a translação
			vel = 0;
		}

		if (timeInt == 0){
			transform.position = new Vector2 (7.5f, 6); 		// Posição do primeiro Objeto
		}

		if (milkSet == 1) {
			vel = 4.7f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (-7, 6);	// Posição do segundo Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 2) {
			vel = 4.7f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (1.5f, 6);	// Posição do terceiro Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 3) {
			vel = 4.7f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (0, 6);	// Retorno ao 0
				milkSet = 0;
				colision = false;
			}
		}			
	}

	void Level8 (){
		if (timeInt == 17){									// Primeiro Objeto
			milkSet = 1;
		}
		if (timeInt == 33){									// Segundo Objeto
			milkSet = 2;
		}
		if (timeInt == 48){									// Terceiro Objeto
			milkSet = 3;
		}

		if (milkSet == 0){									// Para parar a translação
			vel = 0;
		}

		if (timeInt == 0){
			transform.position = new Vector2 (8, 6); 		// Posição do primeiro Objeto
		}

		if (milkSet == 1) {
			vel = 4.7f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (-7, 6);	// Posição do segundo Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 2) {
			vel = 4.7f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (0, 6);	// Posição do terceiro Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 3) {
			vel = 4.7f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (0, 6);	// Retorno ao 0
				milkSet = 0;
				colision = false;
			}
		}			
	}

	void Level9 (){
		if (timeInt == 9){									// Primeiro Objeto
			milkSet = 1;
		}
		if (timeInt == 21){									// Segundo Objeto
			milkSet = 2;
		}
		if (timeInt == 55){									// Terceiro Objeto
			milkSet = 3;
		}

		if (milkSet == 0){									// Para parar a translação
			vel = 0;
		}

		if (timeInt == 0){
			transform.position = new Vector2 (8, 6); 		// Posição do primeiro Objeto
		}

		if (milkSet == 1) {
			vel = 4.7f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (-6, 6);	// Posição do segundo Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 2) {
			vel = 4.7f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (-0.5f, 6);	// Posição do terceiro Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 3) {
			vel = 4.7f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (0, 6);	// Retorno ao 0
				milkSet = 0;
				colision = false;
			}
		}			
	}

	void Level10 (){
		if (timeInt == 11){									// Primeiro Objeto
			milkSet = 1;
		}
		if (timeInt == 21){									// Segundo Objeto
			milkSet = 2;
		}
		if (timeInt == 55){									// Terceiro Objeto
			milkSet = 3;
		}

		if (milkSet == 0){									// Para parar a translação
			vel = 0;
		}

		if (timeInt == 0){
			transform.position = new Vector2 (-8, 6); 		// Posição do primeiro Objeto
		}

		if (milkSet == 1) {
			vel = 4.7f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (0, 6);	// Posição do segundo Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 2) {
			vel = 4.7f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (6, 6);	// Posição do terceiro Objeto
				milkSet = 0;
				colision = false;
			}
		}
		if (milkSet == 3) {
			vel = 4.7f;
			transform.Translate (0, -vel * Time.deltaTime, 0);
			if (transform.position.y + height < -Camera.main.orthographicSize || colision == true) {
				transform.position = new Vector2 (0, 6);	// Retorno ao 0
				milkSet = 0;
				colision = false;
			}
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