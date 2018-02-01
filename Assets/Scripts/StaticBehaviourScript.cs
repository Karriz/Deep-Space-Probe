using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticBehaviourScript : MonoBehaviour {

    public static float currentDelay;
    public static int defaultWindowHeight = 800;
    public static float uiScale = 1;

    private static AudioSource audioSource = null;

    public static string endScreenTemplate;

    public static float highScore {
        get { float hs = PlayerPrefs.GetFloat("highscore");            
            return hs; }
        set { PlayerPrefs.SetFloat("highscore", value); } }

    // Use this for initialization
    void Start() {
        Debug.Log("static script");

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

    internal static int getScaled(int fontSize)
    {
        return fontSize * Screen.height / defaultWindowHeight;
    }
}
