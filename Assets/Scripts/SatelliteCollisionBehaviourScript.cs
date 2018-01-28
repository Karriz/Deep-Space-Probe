using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SatelliteCollisionBehaviourScript : MonoBehaviour {

    public bool gameover = false;
    public string gameOverScreen;
    GameObject canvas;

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        canvas = GameObject.Find("GameOverPanel");
        canvas.SetActive(false);
        audioSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(new Vector3(-5, StaticBehaviourScript.currentDelay, 0), new Vector3(5, StaticBehaviourScript.currentDelay, 0));
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(gameover);
        if (!this.gameover) { 
            Debug.Log("Collision " + collision.gameObject.name);
            Instantiate(Resources.Load("Explosion", typeof(GameObject)) as GameObject, gameObject.transform, true);
            audioSource.PlayOneShot(Resources.Load<AudioClip>("boom1"));
            Invoke("GameOver", 2);
            transform.Find("Satellite").gameObject.SetActive(false);
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
    }

    protected void GameOver() {
        GameObject.Find("AsteroidSpawner").GetComponent<AudioSource>().Stop();

        audioSource.PlayOneShot(Resources.Load<AudioClip>("introtune"));

        Debug.Log("gameover");
        //SceneManager.LoadScene(gameOverScreen);
        canvas.SetActive(true);
        var gameovertext = GameObject.Find("HighScoreText").GetComponent<Text>();
        gameovertext.text = gameovertext.text.Replace("{score}", StaticBehaviourScript.currentDelay.ToString("F2"));
        StaticBehaviourScript.SaveHighScore(StaticBehaviourScript.currentDelay);
        gameovertext.text =     gameovertext.text.Replace("{highscore}", StaticBehaviourScript.highScore.ToString("F2"));

        this.gameover = true;
    }
}
