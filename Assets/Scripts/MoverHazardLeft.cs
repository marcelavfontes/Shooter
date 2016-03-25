using UnityEngine;
using System.Collections;

public class MoverHazardLeft : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.right * speed;
	}

}
