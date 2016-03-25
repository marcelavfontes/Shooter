using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public GameObject shotRight;
	public GameObject shotLeft;
	public Transform shotSpawnRight;
	public Transform shotSpawnLeft;
	public float fireRate;

	private float nextFireRight;
	private float nextFireLeft;
	private Rigidbody rigidBody;

	Vector3 zeroAc;
	Vector3 curAc;
	float sensH = 10;
	float sensV = 10;
	float smooth = 0.5f;
	float getAxisH = 0;
	float getAxisV = 0;

	void Start () {
		ResetAxes ();
		rigidBody = GetComponent<Rigidbody> ();
	}

	void Update(){

//		if(Input.GetButton("Jump") && Time.time > nextFireRight){
//			nextFireRight = Time.time + fireRate;
//			Instantiate(shotRight, shotSpawnRight.position, shotSpawnRight.rotation);
//		}
//
//		if(Input.GetButton("Fire1") && Time.time > nextFireLeft){
//			nextFireLeft = Time.time + fireRate;
//			Instantiate(shotLeft, shotSpawnLeft.position, shotSpawnLeft.rotation);
//		}

		if (Input.mousePosition.x > Screen.width / 2) {
			if(Input.GetButton("Fire1") && Time.time > nextFireLeft){
				nextFireLeft = Time.time + fireRate;
				Instantiate(shotRight, shotSpawnRight.position, shotSpawnRight.rotation);
			}
		} else {
			if(Input.GetButton("Fire1") && Time.time > nextFireLeft){
				nextFireLeft = Time.time + fireRate;
				Instantiate(shotLeft, shotSpawnLeft.position, shotSpawnLeft.rotation);
			}
		}

	}

	void FixedUpdate () {
		//for pc
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");

		//for android
		curAc = Vector3.Lerp(curAc, Input.acceleration-zeroAc, Time.deltaTime/smooth);
		getAxisV = Mathf.Clamp(curAc.y * sensV, -1, 1);
		getAxisH = Mathf.Clamp(curAc.x * sensH, -1, 1);

		//change here between moveH and getAxesH
		Vector2 movement = new Vector2 (getAxisH,getAxisV);
		rigidBody.velocity = movement * speed;
		rigidBody.position = new Vector2 (
			Mathf.Clamp(rigidBody.position.x, -5.0f, 5.0f),
			Mathf.Clamp(rigidBody.position.y, -4.0f, 4.0f)
			);


//		transform.Translate(Mathf.Clamp(Input.acceleration.x, -4.0f, 4.0f) * Time.deltaTime, 
//		                    Mathf.Clamp(Input.acceleration.y, -4.0f, 4.0f) * Time.deltaTime, 
//		                    Mathf.Clamp(0.0f, 0.0f, 0.0f));

	}

	void ResetAxes(){
		zeroAc = Input.acceleration;
		curAc = Vector3.zero;
	}
	
}
