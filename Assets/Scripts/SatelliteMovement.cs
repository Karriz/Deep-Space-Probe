﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteMovement : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb2d;
	private float delay;
    float size = 2.5f;
    float aspect = 1;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D> ();
        //delay = 0.05f;
        
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (Camera.current)
        {
            size = Camera.current.orthographicSize;
            aspect = Camera.current.aspect; // width/height
        }
        float moveHorizontal = Input.GetAxis ("Horizontal");
        //delay += Time.fixedDeltaTime * 0.025f;

        if (gameObject.transform.position.x < -size * aspect)
        {
            gameObject.transform.position = new Vector3( -size * aspect, gameObject.transform.position.y, 0);
        }
        else if (gameObject.transform.position.x > size * aspect)
        {
            gameObject.transform.position = new Vector3(size * aspect, gameObject.transform.position.y, 0);
        }
        else
        {
            delay = StaticBehaviourScript.currentDelay;
            if (moveHorizontal < 0) Invoke("moveLeft", delay);
            if (moveHorizontal > 0) Invoke("moveRight", delay);
            //if (moveHorizontal == 0) Invoke("Stop", delay);
        }
        //rb2d.velocity = Vector2.left;
	}

    float satWidth = 0.2f;

	void moveLeft (){
      
        if (gameObject.transform.position.x > -size * aspect + satWidth)
        {
            Debug.Log("moveleft position correct" + rb2d.position.ToString());
            Vector2 movement = new Vector2(-1, 0);

            //Vector3 movement = new Vector3(-0.01f * speed, 0, 0);
            rb2d.AddForce (movement * speed);
            //rb2d.velocity = movement * speed;

            //gameObject.transform.Translate(movement);
            Debug.Log("velocity" + rb2d.velocity.ToString());
        }
	}

	void moveRight (){
        if (gameObject.transform.position.x < size * aspect - satWidth)
        {
            Vector2 movement = new Vector2(1, 0);
            rb2d.AddForce (movement * speed);
            //rb2d.velocity = movement * speed;
        } 
	}

    void Stop()
    {
        rb2d.velocity = Vector2.zero;
    }
}
