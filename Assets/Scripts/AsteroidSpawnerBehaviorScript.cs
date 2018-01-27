using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidSpawnerBehaviorScript : MonoBehaviour {

    public GameObject[] AsteroidPrefabs;
	// Use this for initialization
	void Start () {
   }

    float lastSpawnTime = 0;

	// Update is called once per frame
	void Update () {
        
        Debug.Log("spawner udpate");
        if (lastSpawnTime == 0) {
            lastSpawnTime = Time.time;
        }
        if (Time.time - lastSpawnTime > 10 && AsteroidPrefabs.Length > 0)
        {
            Debug.Log("spawn new object");
            //var scene = SceneManager.GetActiveScene();
            Instantiate(AsteroidPrefabs[Mathf.RoundToInt(Random.value * AsteroidPrefabs.Length-1)]);
        }
	}
}
