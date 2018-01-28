using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviourScript : MonoBehaviour {
    Vector3 v3_down = new Vector3(0.0f, -0.02f);
    //Vector3 v3_scaleAway = new Vector3(0.5f, 0.5f, 1f);

    public float rotationSpeed = 0;
    public float vanishPosition = -1.8f;
    public float horizontalVelocity = 0;

    private AudioSource audioSource;
    private Rigidbody2D rigidbody;

    // Use this for initialization
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        v3_down.x = horizontalVelocity;
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody.angularVelocity = rotationSpeed * 45;

        
        this.transform.Translate(v3_down, Space.World);
        //this.transform.Rotate(new Vector3(0, 0, rotationSpeed));

        if (this.transform.position.y < vanishPosition) {
            var s = this.transform.localScale;
            //magic numbers to taste
            this.transform.localScale = new Vector3(s.x / 1.04f, s.y / 1.04f, s.z);
            var p = this.transform.position;
            this.transform.position = new Vector3(p.x / 1.01f, p.y, p.z);
            Destroy(gameObject, 3);
        }

        
	}

    private void OnBecameVisible()
    {
        if (gameObject.name.Contains("Whaley"))
        {
            Debug.Log(gameObject.name);
            if (audioSource)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
        } 
    }

    private void OnBecameInvisible()
    {
        if (this.transform.position.y < 0) {
            Destroy(gameObject, 2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name.Contains("Lego")) {
            if (audioSource && !audioSource.isPlaying) {
                audioSource.Play();
            }
        }
    }
}
