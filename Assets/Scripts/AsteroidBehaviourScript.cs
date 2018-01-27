﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviourScript : MonoBehaviour {
    Vector3 v3_down = new Vector3(0.0f, -0.02f);
    //Vector3 v3_scaleAway = new Vector3(0.5f, 0.5f, 1f);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(v3_down, Space.World);
        if (this.transform.position.y < -1.5f) {
            var s = this.transform.localScale;
            this.transform.localScale = new Vector3(s.x / 1.05f, s.y / 1.05f, s.z);
            var p = this.transform.position;
            this.transform.position = new Vector3(p.x / 1.02f, p.y, p.z);
        }
	}

    private void OnBecameInvisible()
    {
        if (this.transform.position.y < 0) {
            Destroy(gameObject, 2);
        }
    }
}
