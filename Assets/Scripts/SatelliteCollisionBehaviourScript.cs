using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SatelliteCollisionBehaviourScript : MonoBehaviour {

    public string gameOverScreen;
    GameObject canvas;

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        canvas = GameObject.Find("Button");
        canvas.SetActive(false);
        audioSource = gameObject.GetComponent<AudioSource>();
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
        audioSource.PlayOneShot(Resources.Load<AudioClip>("boom1"));
        Invoke("GameOver", 2);
        transform.Find("Satellite").gameObject.SetActive(false);

    }

    protected void GameOver() {
        Debug.Log("gameover");
        //SceneManager.LoadScene(gameOverScreen);
        canvas.SetActive(true);
    }
}
