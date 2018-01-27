using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBehaviourScript : MonoBehaviour {

    public static float currentDelay;

    private static AudioSource audioSource = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static AudioSource getAudioSource() {
        if (null == StaticBehaviourScript.audioSource) {
            Debug.Log("creating audiosource");
            StaticBehaviourScript.audioSource = new AudioSource();
        }
        return StaticBehaviourScript.audioSource;
    }
}
