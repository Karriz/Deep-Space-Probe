using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviourScript : MonoBehaviour {
    Vector3 v3_down = new Vector3(0.0f, -0.05f);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(v3_down, Space.World);
	}

    private void OnBecameInvisible()
    {
        if (this.transform.localPosition.y < 0) {
            Destroy(gameObject, 2);
        }
    }
}
