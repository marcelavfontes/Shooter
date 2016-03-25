using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	private bool gameOver;

	public GameObject RestartButton;
	public Transform hazardLeft;
	public Transform hazardRight;
	public float hazardRate;
	private float nextHazard;

	// Use this for initialization
	void Start () {
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(Time.time > nextHazard){
			nextHazard = Time.time + hazardRate;
			//min[inclusive] max[exclusive]
			int side = Random.Range (1,3); //1-left, 2-right
			float height = Random.Range (-5, 5);

			if(side == 1){
				Vector3 v = new Vector3(-9, height, 0.0f);
				Instantiate(hazardLeft, v, Quaternion.identity);
			}else{
				Vector3 v = new Vector3(9, height, 0.0f);
				Instantiate(hazardRight, v, Quaternion.identity);
			}
		}
	}

	public void GameOver(){
		gameOver = true;
		RestartButton.SetActive (true);
	}


	public void ReloadGame(){
			Application.LoadLevel (Application.loadedLevel);	
	}
}
