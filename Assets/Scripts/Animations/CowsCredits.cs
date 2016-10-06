using UnityEngine;
using System.Collections;

public class CowsCredits : MonoBehaviour {


	public RectTransform joao, igor, adriel;
	public float vel;
	private float posJ, posI, posA;


	void Start(){
		posJ = joao.position.y;
		posI = igor.position.y;
		posA = adriel.position.y;
	}

	public int change;

	void Update(){
		if (change == 1){
			CreditsCows ();
		}else{
			change = 0;
		}
	}


	void CreditsCows() {
		joao.Translate (0, -vel * Time.deltaTime, 0);
		if (joao.position.y < -2 -Camera.main.orthographicSize) {
			joao.position = new Vector2 (Random.Range (-7, 7), posJ);
		}

		igor.Translate (0, -vel * Time.deltaTime, 0);
		if (igor.position.y < -2 -Camera.main.orthographicSize) {
			igor.position = new Vector2 (Random.Range (-7, 7), posI);
		}

		adriel.Translate (0, -vel * Time.deltaTime, 0);
		if (adriel.position.y < -2 -Camera.main.orthographicSize) {
			adriel.position = new Vector2 (Random.Range (-7, 7), posA);
		}
	}

	public void CallCows(){
		change = 1;
	}

	public void ByeCows() {
		joao.position   = new Vector2 (Random.Range (-7, 7), posJ);
		igor.position   = new Vector2 (Random.Range (-7, 7), posI);
		adriel.position = new Vector2 (Random.Range (-7, 7), posA);
	}

}