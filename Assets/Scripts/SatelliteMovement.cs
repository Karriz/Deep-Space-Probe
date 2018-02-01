using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatelliteMovement : MonoBehaviour {

	public float speed;
	//private Rigidbody2D rb2d;
	private float delay;
    float size = 2.5f;
    float aspect = 1;
    
    private AudioSource audioSource;
    private Text delayText;

    private Light m_light;

    // Use this for initialization
    void Start () {
        //rb2d = GetComponent<Rigidbody2D> ();
        //delay = 0.05f;
        if (Camera.current)
        {
            size = Camera.current.orthographicSize;
            aspect = Camera.current.aspect; // width/height
            Debug.Log("Size: " + size);
        }
        audioSource = gameObject.GetComponent<AudioSource>();
        delayText = GameObject.Find("DelayText").GetComponent<Text>();
        //delayText.fontSize = StaticBehaviourScript.getScaled(delayText.fontSize);
        //GameObject.Find("DelayText").GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/2f, 30f);
        //delayText.SetNativeSize();

        m_light = transform.Find("Light").GetComponent<Light>();
        m_light.enabled = false;
    }

	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        //touch me
        float pos;
        int width = Screen.width;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.touches.Length > 0)
        {
            pos = Input.touches[0].position.x - width / 2;
            //    Debug.Log("position" + pos);
            moveHorizontal = pos / (width / 2);
        }
        //pos = Input.mousePosition.x - width / 2;
        //Debug.Log("position" + pos);

        //delay += Time.fixedDeltaTime * 0.025f;

        if (gameObject.transform.position.x < -size * aspect)
        {
            gameObject.transform.position = new Vector3( -size * aspect * 0.99f, gameObject.transform.position.y, 0);
        }
        else if (gameObject.transform.position.x > size * aspect)
        {
            gameObject.transform.position = new Vector3(size * aspect * 0.99f, gameObject.transform.position.y, 0);
        }
        else
        {
            delay = StaticBehaviourScript.currentDelay;
            if (moveHorizontal < 0) Invoke("moveLeft", delay);
            if (moveHorizontal > 0) Invoke("moveRight", delay);
            if (moveHorizontal == 0) Invoke("Stop", delay);
        }
        //rb2d.velocity = Vector2.left;
        delayText.text = StaticBehaviourScript.currentDelay.ToString("F2") + " LIGHT SECONDS AWAY";
    }

    float satWidth = 0.2f;

	void moveLeft (){
        m_light.enabled = true;
        if (!audioSource.isPlaying) {
            audioSource.Play();
        }
        if (gameObject.transform.position.x > -size * aspect + satWidth)
        {
            Vector2 movement = new Vector2(-1, 0);

            //Vector3 movement = new Vector3(-0.01f * speed, 0, 0);
            //rb2d.AddForce (movement * speed);
            GetComponent<Rigidbody2D>().AddForce(movement * speed);
            //rb2d.velocity = movement * speed;

            //gameObject.transform.Translate(movement);
            //Debug.Log("velocity" + rb2d.velocity.ToString());
        }
	}

	void moveRight (){
        m_light.enabled = true;
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        if (gameObject.transform.position.x < size * aspect - satWidth)
        {
            Vector2 movement = new Vector2(1, 0);
            //rb2d.AddForce (movement * speed);
            GetComponent<Rigidbody2D>().AddForce(movement * speed);
            //rb2d.velocity = movement * speed;
        } 
	}

    void Stop()
    {
        m_light.enabled = false;
        //rb2d.velocity = Vector2.zero;
    }
}

