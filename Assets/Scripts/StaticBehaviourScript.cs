using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticBehaviourScript : MonoBehaviour {

    public static float currentDelay;

    private static AudioSource audioSource = null;

    public static string endScreenTemplate;

    public static float highScore {
        get { var hs = PlayerPrefs.GetFloat("highscore");
            if (null == hs) hs = 0.0f;
            return hs; }
        set { PlayerPrefs.SetFloat("highscore", value); } }

    // Use this for initialization
    void Start() {

    }

    public static void SaveHighScore(float hs) {
        if (highScore < hs) { highScore = hs; }
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public static AudioSource GetAudioSource() {
        if (null == StaticBehaviourScript.audioSource) {
            Debug.Log("creating audiosource");
            StaticBehaviourScript.audioSource = new AudioSource();
        }
        return StaticBehaviourScript.audioSource;
    }
}
