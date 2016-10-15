using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cows : MonoBehaviour {

	public float 		cowVel;

	public  float 		positionx;
	public  float 		positiony;
	private float 		randomx;
	private float 		alternativeY;
	public  float 		nextPosition;
	public  float 		nextPosition2;
	public  int   		round;             // Responsável pela transição de uma Rate escalar para outra escalar

	public 	int			fallType;
	public 	int   		contCow;

	private float 		height;

	public 	static int 	chgLvl;

	public 	static bool redCandy = false;

	public 	static bool sleepCow = false;

	public 	float 		timeToSound;

	public	bool		vacaLouca = false;
	public 	static bool	vacaLoucaStatic = false;
	public 	float 		vacaLoucaY;
	public 	int 		type;
	public  float 		timeVLfloat;
	public  int 		timeVLInt;
	public  int 		timeVLreturn;

	private CircleCollider2D col;

	void Start () {
		height 	= GetComponent <SpriteRenderer> ().bounds.size.y;
		transform.position = new Vector2 (positionx, positiony);

		col 	= GetComponent <CircleCollider2D> ();             // Para desativar a colisão das vacas x confete
	
		if (vacaLouca) {
			vacaLoucaStatic = true;
		} else {
			vacaLoucaStatic = false;
		}
	
	}

	void Update () {
		ChangeLevel  ();
		FallingTypes (); 

		if (redCandy == true) {
			cowVel = 2;
		}
		if (sleepCow == true) {
			contCow = 0;
		} else {
			sleepCow = false;
		}

		timeVLfloat += Time.deltaTime;
		timeVLInt = (int)timeVLfloat;

		if (vacaLouca) {
			if (timeVLInt % 10 == 0 && timeVLInt != 0 && timeVLreturn == 0) {
				cowVel++;
				timeVLreturn = 1;
			}
			if (timeVLInt % 11 == 0) {
				timeVLreturn = 0;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.CompareTag ("Confete")){
			col.enabled = false;
		}

	}

	//Falling Types
	void FallingTypes () {

		switch (type){
		case 1:
			Falling ();
			break;
		case 2:
			FallingRight ();
			break;
		case 3:
			FallingLeft ();
			break;
		}

	}

	void Falling	  (){
		
		transform.Translate (0, -cowVel * Time.deltaTime, 0);
		if (transform.position.y + height < -Camera.main.orthographicSize) {
			if (!vacaLouca) { // se não foi o infinity
				Position ();
				contCow++;  //para controlar quantos objetos caíram.
			} else{															//INFINITY
				RandomPosition ();
				contCow++;
			}
		}
	
	}

	void FallingRight (){

		transform.Translate (cowVel/4*Time.deltaTime, -cowVel * Time.deltaTime, 0);
		if (transform.position.y + height < -Camera.main.orthographicSize) {
			if (!vacaLouca) { 
				Position ();
				contCow++;  //para controlar quantos objetos caíram.
			} else {
				RandomPosition ();
				contCow++;
			}
		}
	}

	void FallingLeft  (){
		transform.Translate (-cowVel/4*Time.deltaTime, -cowVel * Time.deltaTime, 0);
		if (transform.position.y + height < -Camera.main.orthographicSize) {
			if (!vacaLouca) { 
				Position ();
				contCow++;  //para controlar quantos objetos caíram.
			} else {
				RandomPosition ();
				contCow++;
			}
		}

	}

	void FallingNull  (){
		transform.Translate (0, 0, 0);
	}

	// Para definir a posição de reuso das vacas que caíram.
	void Position (){
		col.enabled = true;			// Para desativar a colisão das vacas x confete
		if (fallType == 1) {													// Descida padrão
			positiony = 6;
			transform.position = new Vector2 (positionx, positiony);
		}

		if (fallType == 2) {													// Aleatório
			randomx = Random.Range (-7, 7);
			transform.position = new Vector2 (randomx, positiony);
		}

		if (fallType == 3) {													// Mantém  a última posição
			transform.position = new Vector2 (positionx, positiony);
		}

		if (fallType == 4) {													// Escala crescente
			alternativeY = positiony + nextPosition;
			transform.position = new Vector2 (positionx, alternativeY);
		}
		if (fallType == 5) {													// Escala decrescente
			positiony = 6;
			alternativeY = positiony + (nextPosition2*2);
			transform.position = new Vector2 (positionx, alternativeY);
		}
		if (fallType == 6) {													// Reduz a distância das vacas pela metade
			transform.position = new Vector2 (positionx/2, positiony);
		}
		if (fallType == 7) {													// Reinicia o eixo Y | escala crescente 
			transform.position = new Vector2 (positionx, positiony*round);
		}
		if (fallType == 8) {													// Reinicia o eixo X | round é a quantidade de waves que passaram
			transform.position = new Vector2 (positionx*round, positiony);
		}
		if (fallType == 9) {													// Reinicia o eixo Y para posição inicial | Usado para fechar o jogo;
			positiony = 6;
			transform.position = new Vector2 (positionx, positiony);
		}
		if (fallType == 10) {													// Reinicia o eixo Y | escala decrescente 
			transform.position = new Vector2 (positionx, positiony/round);
		}
	}

	void RandomPosition () {
		type = (Random.Range (1, 3));
		col.enabled = true;
		transform.position = new Vector2 (Random.Range (-8, 8), vacaLoucaY);
	}				

	//Funções das posiçõe de reuso
	void Rate1() {
		fallType = 1;
	}

	void Rate2() {
		fallType = 2;
	}

	void Rate3(){
		fallType = 3;
	}

	void Rate4(){
		fallType = 4;
	}

	void Rate5(){
		fallType = 5;
	}

	void Rate6(){
		fallType = 6;
	}

	void Rate7(){
		fallType = 7;
	}

	void Rate8(){
		fallType = 8;
	}

	void Rate9(){
		fallType = 9;
	}

	void Rate10(){
		fallType = 10;
	}

	//Fases

	void Level1 (){
		
		if (tag == ("Par")) {
			cowVel = 0;
		}
		if (tag == ("Impar")) {
			cowVel = 3;
			if (contCow == 0){
				Falling ();
				Rate4 ();
			}if (contCow == 1) {
				Falling ();
				Rate4 ();
			}if (contCow == 2) {
				Falling ();
				Rate5 ();
			}if (contCow == 3) {
				Falling ();
				Rate4 ();
			}if (contCow == 4) {
				Falling ();
				Rate4 ();
			}if (contCow == 5) {
				Falling ();
				Rate5 ();
			}if (contCow == 6) {
				ResetPosition ();
				cowVel = 0;
			}
		}
	}

	void Level2 (){

		if (tag == ("Par")) {
			cowVel = 0;
		}
		if (tag == ("Impar")) {
			cowVel = 3;

			if (contCow == 0) {
				Falling ();
				Rate6 ();
			} else if (contCow == 1) {
				Falling ();
				Rate1 ();
			}else if (contCow == 2) {
				Falling ();
				Rate1 ();
			} else if (contCow == 3) {
				Falling ();
				Rate4 ();
			} else if (contCow == 4) {
				Falling ();
				Rate1 ();
			}else if (contCow > 6){
				cowVel=0;
			}
		}
	}

	void Level3 (){
		cowVel = 4;

		if (tag == "Impar") {

			if (contCow < 2) {
				Falling ();
				Rate5 ();
			}
			if (contCow == 2){
				FallingLeft ();
				Rate1 ();
			}
			if (contCow == 3){
				Falling ();
				Rate4 ();
			}
			if (contCow == 4){
				Falling ();
				Rate4 ();
			}
			if (contCow == 5){
				Falling ();
				Rate4 ();
			}
			if (contCow == 6) {
				Falling ();
				Rate4 ();
			}
			if (contCow == 7){
				Falling ();
				Rate6 ();
			}
			if (contCow == 8){
				Falling ();
				Rate1 ();
			}
		}

		if (contCow < 5) {
			if (gameObject.name == "Cow2") {
				if (Function.timeI > 20) {
					FallingRight ();
					Rate1 ();
				}
			}
			if (gameObject.name == "Cow8") {
				if (Function.timeI > 20) {
					FallingLeft ();
					Rate1 ();
				}
			}
		}
	}

	void Level4 (){
		
		if (contCow < 6) {
			cowVel = 4;
			if (Function.timeI > 0) {
				if (gameObject.name == "Cow_1" || gameObject.name == "Cow_9") {
					Falling ();
					Rate1 ();
				}
			}
			if (Function.timeI > 1) {
				if (gameObject.name == "Cow_2" || gameObject.name == "Cow_8") {
					Falling ();
					Rate1 ();
				}
			}
			if (Function.timeI > 2) {
				if (gameObject.name == "Cow_3" || gameObject.name == "Cow_7") {
					Falling ();
					Rate1 ();
				}
			}
			if (Function.timeI > 3) {
				if (gameObject.name == "Cow_4" || gameObject.name == "Cow_6") {
					Falling ();
					Rate1 ();
				}
			}
			if (Function.timeI > 4) {
				if (gameObject.name == "Cow_5") {
					Falling ();
					Rate1 ();
				}
			}
		}
		if (contCow == 6 && tag == "Par"){
			ResetPosition ();
		}
		if (contCow == 6 && tag == "Impar"){
			FallingLeft ();
			Rate5 ();
		}
		if (contCow == 7){
			FallingRight ();
				Rate4();
		}
		if (contCow == 8){
			FallingRight ();
			Rate1();
		}
		if (contCow == 9){
			FallingRight ();
			Rate1();
		}
		if (contCow == 10){
			FallingRight ();
			Rate4();
		}
		if (contCow == 11){
			FallingLeft ();
			ResetPosition ();
		}

	}

	void Level5 (){
		cowVel = 4.5f;

		if (tag == "Impar") {
			if (contCow == 0) {
				Falling ();
				Rate6 ();
			}
			if (contCow == 1) {
				Falling ();
				Rate1 ();
			}
			if (contCow == 2) {
				Falling ();
				Rate6 ();
			}
			if (contCow == 3) {
				Falling ();
				Rate1 ();
			}
			if (contCow == 4) {
				Falling ();
				Rate6 ();
			}
			if (contCow == 5) {
				Falling ();
				Rate1 ();
			}
			if (contCow == 6) {
				FallingLeft ();
				Rate1 ();
			}
			if (contCow == 7) {
				FallingRight ();
				Rate1 ();
			}
		}
		if (Function.timeI > 23) {										// Segunda Parte da fase
			if (tag == "Par") {
				if (contCow == 0) {
					Falling ();
					Rate4 ();
				}
				if (contCow == 1) {
					Falling ();
					Rate5 ();
				}
				if (contCow == 2){
					contCow = 10;
				}
			}
			if (tag == "Impar") {
				if (contCow == 8) {
					Falling ();
					Rate4 ();
				}
				if (contCow == 9 && gameObject.name != "Cow_7") {
					Falling ();
					Rate5 ();
				}
				if (contCow == 9 && gameObject.name == "Cow_7") {
					Rate5 ();
					contCow = 10;
				}
			}
		}
		if (Function.timeI >= 30){
			round = 1;
			if (contCow == 10 && gameObject.name != "Cow_3"){
				Falling ();
				Rate7 ();
			}
			if (contCow == 11 && gameObject.name != "Cow_5" && gameObject.name != "Cow_7"){
				Falling ();
				Rate1 ();
			}
		}

		if (Function.timeI == 41){
			ResetPosition ();
		}
	}

	void Level6 () {
		if (redCandy == false){
			cowVel = 4.8f;	
		}

		if (tag == "Impar") {
			if (contCow == 0) {
				Falling ();
				Rate4 ();
			}
			if (contCow == 1) {
				Falling ();
				Rate6 ();
			}
			if (contCow == 2) {
				FallingLeft ();
				Rate5 ();
			}
			if (contCow == 3) {
				Falling ();
				Rate6 ();
			}
			if (contCow == 4) {
				FallingRight ();
				Rate1 ();
			}
			if (contCow == 5) {
				Falling ();
				Rate6 ();
			}
			if (contCow == 6) {
				Falling ();
				Rate4 ();
			}
			if (contCow == 7) {
				Falling ();
				Rate5 ();
			}
			if (contCow == 8) {
				FallingLeft ();
				Rate1 ();
			}
			if (contCow == 9) {
				FallingRight ();
				Rate5 ();
			}
			if (contCow == 10) {
				FallingLeft ();
				Rate6 ();
			}
			if (contCow == 11) {
				Falling ();
				Rate4 ();
			}
			if (contCow == 12) {
				Falling ();
				Rate4 ();
			}
			if (contCow == 13) {
				FallingLeft ();
				Rate6 ();
			}
			if (contCow == 14) {
				FallingRight ();
				Rate1 ();
			}
			if (contCow == 15) {
				Falling ();
				Rate4 ();
			}
			if (contCow == 16){
				Falling ();
				Rate1 ();
			}
		}
	}

	void Level7 (){
		if (redCandy == false){
			cowVel = 5.0f;
		}
		if (tag == "Impar"){
			if (contCow == 0){
				Falling ();
				Rate4 ();
			}
			if (contCow == 1){
				FallingRight ();
				Rate5 ();
			}
			if (contCow == 2){
				FallingLeft ();
				Rate4 ();
			}
			if (contCow == 3){
				Falling ();
				Rate1 ();
			}
			if (contCow == 4){
				FallingLeft ();
				Rate1 ();
			}
			if (contCow == 5){
				FallingRight ();
				Rate6 ();
			}
			if (contCow == 6){
				FallingLeft ();
				Rate5 ();
			}
			if (contCow == 7){
				FallingRight ();
				Rate4 ();
			}
			if (contCow == 8){
				Falling ();
				Rate5 ();
			}
			if (contCow == 9){
				FallingRight ();
				round = 2;
				Rate7 ();
			}
			if (contCow == 10){
				FallingLeft ();
				Rate1 ();
			}
			if (contCow == 11){
				Falling ();
				Rate5 ();
			}
			if (contCow == 12){
				FallingLeft ();
				Rate4 ();
			}
			if (contCow == 13){
				Falling ();
				Rate1 ();
			}
			if (contCow == 14){
				FallingRight ();
				Rate4 ();
			}
			if (contCow == 15){
				FallingLeft ();
				Rate1 ();
			}
			if (contCow == 16){
				Falling ();
				Rate1 ();
			}
			if (contCow == 17){
				Falling();
				Rate1 ();
			}
			if (contCow == 18){
				FallingLeft ();
				Rate4 ();
			}
			if (contCow == 19){
				FallingRight ();
				Rate5 ();
			}
			if (contCow == 20){
				Falling ();
				Rate1 ();
			}
		}
	}

	void Level8 (){
		if (redCandy == false){
			cowVel = 5.0f;
		}
		if (tag == "Impar"){
			if (contCow == 0){
				FallingRight ();
				Rate4 ();
			}
			if (contCow == 1){
				FallingLeft ();
				Rate6 ();
			}
			if (contCow == 2){
				FallingRight ();
				Rate6 ();
			}
			if (contCow == 3){
				FallingLeft ();
				Rate5 ();
			}
			if (contCow == 4){
				FallingRight ();
				Rate1 ();
			}
			if (contCow == 5){
				Falling ();
				Rate6 ();
			}
			if (contCow == 6){
				Falling ();
				Rate1 ();
			}
			if (contCow == 7){
				Falling ();
				Rate5 ();
			}
			if (contCow == 8){
				FallingLeft ();
				Rate1 ();
			}
			if (contCow == 9){
				FallingRight ();
				Rate6 ();
			}
			if (contCow == 10){
				FallingLeft ();
				Rate4 ();
			}
			if (contCow == 11){
				FallingRight ();
				Rate5 ();
			}
			if (contCow == 12){
				Falling ();
				Rate5 ();
			}
			if (contCow == 13){
				Falling ();
				Rate4();
			}
			if (contCow == 14){
				Falling ();
				Rate6 ();
			}
			if (contCow == 15){
				Falling ();
				Rate1 ();
			}
		}
	}

	void Level9 (){
		if (redCandy == false){
			cowVel = 5.0f;
		}
		if (tag == "Impar") {
			if (contCow == 0) {
				Falling ();
				Rate4 ();
			}
			if (contCow == 1) {
				FallingLeft ();
				Rate5 ();
			}
			if (contCow == 2) {
				FallingRight ();
				Rate4 ();
			}
			if (contCow == 3){
				Falling ();
				Rate1 ();
			}
			if (contCow == 4){
				FallingRight ();
				Rate5 ();
			}
			if (contCow == 5){
				Falling ();
				Rate1 ();
			}
			if (contCow == 6){
				FallingLeft ();
				Rate4 ();
			}
			if (contCow == 7){
				Falling ();
				Rate4 ();
			}
			if (contCow == 8){
				FallingRight ();
				Rate1 ();
			}
			if (contCow == 9){
				FallingRight();
				Rate1();
			}
			if (contCow == 10){
				Falling ();
				Rate5 ();
			}
			if (contCow == 11){
				FallingLeft ();
				Rate6 ();
			}
			if (contCow == 12){
				FallingRight ();
				Rate1 ();
			}
			if (contCow == 13){
				FallingLeft ();
				Rate5 ();
			}
			if (contCow == 14){
				FallingRight ();
				Rate6 ();
			}
			if (contCow == 15){
				Falling ();
				Rate1 ();
			}
			if (contCow == 16){
				FallingLeft ();
				Rate6 ();
			}
			if (contCow == 17){
				Falling ();
				Rate4 ();
			}
			if (contCow == 18){
				FallingLeft ();
				Rate6 ();
			}
			if (contCow == 19){
				Falling ();
				Rate1 ();
			}
		}

		if (tag == "Par") {								// Impar contCow = 9
			if (Function.timeI > 29) {
				if (tag == "Par") {
					if (contCow == 0) {
						FallingLeft ();
						Rate1 ();
					}		
				}
			}
		}
	}

	void Level10 (){
		if (redCandy == false) {
			cowVel = 5.5f;
		}
		if (tag == "Impar") {
			if (contCow == 0) {
				Falling ();
				Rate1 ();
			}
			if (contCow == 1) {
				Falling ();
				Rate4 ();
			}
			if (contCow == 2) {
				Falling ();
				Rate5 ();
			}
			if (contCow == 3) {
				Falling ();
				Rate4 ();
			}
			if (contCow == 4) {
				FallingRight ();
				Rate5 ();
			}
			if (contCow == 5) {
				Falling ();
				Rate1 ();
			}
			if (contCow == 6) {
				Falling ();
				Rate1 ();
			}
			if (contCow == 7) {
				FallingLeft ();
				Rate4 ();
			}
			if (contCow == 8) {
				FallingLeft ();
				Rate4 ();
			}
			if (contCow == 9) {
				FallingRight ();
				Rate4 ();
			}
			if (contCow == 10) {
				FallingRight ();
				Rate4 ();
			}
			if (contCow == 11) {
				FallingRight ();
				Rate1 ();
			}
			if (contCow == 12) {
				FallingRight ();
				Rate5 ();
			}
			if (contCow == 13) {
				FallingRight ();
				Rate5 ();
			}
			if (contCow == 14) {
				Falling();
				Rate1 ();
			}
			if (contCow == 15) {
				FallingRight();
				Rate4 ();
			}
			if (contCow == 16) {
				Falling();
				Rate5 ();
			}
			if (contCow == 17) {
				FallingLeft();
				Rate4 ();
			}
			if (contCow == 18) {
				FallingRight();
				Rate5 ();
			}
			if (contCow == 19) {
				FallingLeft();
				Rate1 ();
			}
			if (contCow == 20) {
				FallingRight();
				Rate1 ();
			}
			if (contCow == 21) {
				FallingLeft();
				Rate4 ();
			}


		}

		if (tag == "Par") {
			if (Function.timeI > 1 / 2) {
				if (contCow == 0) {
					Falling ();
					Rate4 ();
				}
				if (contCow == 1) {
					Falling ();
					Rate5 ();
				}
				if (contCow == 2) {
					Falling ();
					Rate1 ();
				}
				if (contCow == 3) {
					Falling ();
					Rate4 ();
				}
				if (contCow == 4) {
					FallingLeft ();
					Rate5 ();
				}
				if (contCow == 5) {
					Falling ();
					Rate1 ();
				}
				if (contCow == 6) {
					Falling ();
					Rate1 ();
				}
				if (contCow == 7) {
					FallingLeft ();
					Rate4 ();
				}
				if (contCow == 8) {
					FallingLeft ();
					Rate4 ();
				}
				if (contCow == 9) {
					FallingRight ();
					Rate4 ();
				}
				if (contCow == 10) {
					FallingRight ();
					Rate4 ();
				}
				if (contCow == 11) {
					FallingRight ();
					Rate4 ();
				}
				if (contCow == 12) {
					FallingRight ();
					Rate5 ();
				}
				if (contCow == 13) {
					FallingRight ();
					Rate5 ();
				}
				if (contCow == 14) {
					FallingLeft ();
					Rate1 ();
				}
				if (contCow == 15) {
					FallingRight ();
					Rate4 ();
				}
				if (contCow == 16) {
					Falling();
					Rate5 ();
				}
				if (contCow == 17) {
					Falling();
					Rate1 ();
				}
				if (contCow == 18) {
					FallingRight();
					Rate5 ();
				}
				if (contCow == 19) {
					FallingLeft();
					Rate1 ();
				}
				if (contCow == 20) {
					FallingRight();
					Rate1 ();
				}
				if (contCow == 21) {
					Falling();
					Rate4 ();
				}
			}
		}
	}

	void LevelInfinity () {
		vacaLouca = true;
		chgLvl = 11;
	
	}

	public void InfinityStart() {
		vacaLouca = true;
		type = (Random.Range (1, 3));
		transform.position = new Vector2 (Random.Range (-8, 8), vacaLoucaY);
		cowVel = 2;
		timeVLfloat = 0;
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
		if (chgLvl == 11) {
			LevelInfinity ();		
		}
		if (chgLvl == 20){												//randomPositionVACALOUCA
			InfinityStart();
		}

	}

	void ResetPosition(){
		transform.position = new Vector2 (positionx, 6);
	}
		
}
