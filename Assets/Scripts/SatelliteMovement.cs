using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteMovement : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb2d;
	private float delay;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D> ();
        delay = 0.05f;
	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		delay += Time.fixedDeltaTime * 0.025f;
		if (moveHorizontal < 0) Invoke ("moveLeft", delay);
		if (moveHorizontal > 0) Invoke ("moveRight", delay);
	}
	void moveLeft (){
		Vector2 movement = new Vector2 (-1,0);
		rb2d.AddForce (movement * speed);
	}
	void moveRight (){
		Vector2 movement = new Vector2 (1,0);
		rb2d.AddForce (movement * speed);
	}
}
