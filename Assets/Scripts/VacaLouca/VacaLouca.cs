using UnityEngine;
using System.Collections;

public class VacaLouca : MonoBehaviour {
	public 	float 				vcVel;
	public 	float 				vcX;
	public 	float 				vcY;
	public 	int 				type;
	private float 				height;
	private CircleCollider2D 	col;

	public float timeVcF;
	public int	 timeVcI;

	public int tempo;

	void Start () {
		col 	= GetComponent <CircleCollider2D> ();    
		height 	= GetComponent <SpriteRenderer> ().bounds.size.y;


		transform.position = new Vector2 (Random.Range (-8, 8), vcY);

		type = 1;
	}

	void Update () {
		
		FallingTypes ();

		timeVcF += Time.deltaTime;
		timeVcI = (int)timeVcF;

		if (timeVcI % 10 == 0 && timeVcI != 0 && tempo == 0){
			vcVel--;
			tempo = 1;
		}

		if (timeVcI % 11 == 0){
			tempo = 0;
		}
			
	}

	// Tipos de queda

	void CrazyCowsFallingNormal () {
		transform.Translate (0, vcVel * Time.deltaTime,0);

		if (transform.position.y + height < -Camera.main.orthographicSize) {
			RandomCrazyCows ();
		}
	}
	void CrazyCowsFallingRight () {
		transform.Translate (vcVel/4*Time.deltaTime, vcVel * Time.deltaTime,0);

		if (transform.position.y + height < -Camera.main.orthographicSize) {
			RandomCrazyCows ();
		}
	}
	void CrazyCowsFallingLeft () {
		transform.Translate (-vcVel/4*Time.deltaTime, vcVel * Time.deltaTime,0);
		
		if (transform.position.y + height < -Camera.main.orthographicSize) {
			RandomCrazyCows ();
		}
	}

	void RandomCrazyCows () {
		col.enabled = true;	
		type = (Random.Range (1, 3));
		transform.position = new Vector2 (Random.Range (-8, 8), vcY);

		FallingTypes ();
	}

	void FallingTypes(){
		
		switch (type){
		case 1:
			CrazyCowsFallingNormal ();
			break;
		case 2:
			CrazyCowsFallingRight ();
			break;
		case 3:
			CrazyCowsFallingLeft ();
			break;
		}

	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag ("Confete")){
			col.enabled = false;
		}

	}

}
