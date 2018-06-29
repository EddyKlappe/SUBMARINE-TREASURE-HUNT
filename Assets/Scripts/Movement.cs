using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	private Rigidbody rb;
	public float force;
	public float forceSteering;
	public float rotateSpeed;
	private bool buttonPressed;

	public ParticleSystem bubbles;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		transform.position = new Vector3(0.0f, 1.5f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
		if (Input.GetKeyDown("space")) {
			boostForward ();
			bubbles.Play ();
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (new Vector3 (0, 1, 0) * rotateSpeed * Time.deltaTime);
			rb.AddRelativeForce (new Vector3 (-1,1,-1) * forceSteering, ForceMode.VelocityChange);
		}

		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.Rotate(new Vector3(0,-1,0) * rotateSpeed * Time.deltaTime);
			rb.AddRelativeForce(new Vector3(1,1,1)*forceSteering,ForceMode.VelocityChange);
		}

	}

	// Update is called once per frame
	void FixedUpdate () {
		//rb.AddForce(new Vector3(0,1,0)*force,ForceMode.Acceleration)
	}

	void boostForward () {
		rb.AddRelativeForce(new Vector3(3,3,0)*force,ForceMode.Acceleration);
	}
}
