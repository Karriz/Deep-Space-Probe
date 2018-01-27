using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SatelliteCollisionBehaviourScript : MonoBehaviour {

    public bool gameover = false;
    public string gameOverScreen;
    GameObject canvas;

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        canvas = GameObject.Find("Canvas");
        canvas.SetActive(false);
        audioSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(new Vector3(-5, StaticBehaviourScript.currentDelay, 0), new Vector3(5, StaticBehaviourScript.currentDelay, 0));
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(this.gameover);
        if (!this.gameover) { 
            Debug.Log("Collision " + collision.gameObject.name);
            Instantiate(Resources.Load("Explosion", typeof(GameObject)) as GameObject, gameObject.transform, true);
            audioSource.PlayOneShot(Resources.Load<AudioClip>("boom1"));
            Invoke("GameOver", 2);
            transform.Find("Satellite").gameObject.SetActive(false);
        }
    }

    protected void GameOver() {
        audioSource.PlayOneShot(Resources.Load<AudioClip>("introtune"));

        Debug.Log("gameover");
        //SceneManager.LoadScene(gameOverScreen);
        canvas.SetActive(true);
        this.gameover = true;
    }
}
