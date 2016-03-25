using UnityEngine;
using System.Collections;

public class MoverShotLeft : MonoBehaviour {

	public float speed;

	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = -transform.up * -speed;
	}

}
