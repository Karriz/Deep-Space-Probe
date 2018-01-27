using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SatelliteCollisionBehaviourScript : MonoBehaviour {

    public string gameOverScreen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {     
        Debug.Log("Collision " + collision.gameObject.name);
        this.GameOver();

    }

    private void GameOver() {
        Debug.Log("gameover");
        SceneManager.LoadScene(gameOverScreen);
    }
}
