using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	private GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.Log("Cannot find GAMECONTROLLER script"); 
		}
	}


	void OnTriggerEnter(Collider other){

		if(other.tag == "Boundary"){
			return;
		}
		if(other.tag == "Player"){
			gameController.GameOver();	
		}
		Destroy (other.gameObject);
		Destroy (gameObject);

	}
}
