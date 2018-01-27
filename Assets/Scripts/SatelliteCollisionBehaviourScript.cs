using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SatelliteCollisionBehaviourScript : MonoBehaviour {

    public string gameOverScreen;
	GameObject canvas;
	// Use this for initialization
	void Start () {
		canvas = GameObject.Find ("Canvas");
		canvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(new Vector3(-5, StaticBehaviourScript.currentDelay, 0), new Vector3(5, StaticBehaviourScript.currentDelay, 0));
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {     
        Debug.Log("Collision " + collision.gameObject.name);
        Instantiate(Resources.Load("Explosion", typeof(GameObject)) as GameObject, gameObject.transform);
        Invoke("GameOver", 2);
        transform.Find("Satellite").gameObject.SetActive(false);

    }

    protected void GameOver() {
        Debug.Log("gameover");
		canvas.SetActive (true);
    }
}
