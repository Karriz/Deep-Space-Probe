using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidSpawnerBehaviorScript : MonoBehaviour {

    public GameObject[] AsteroidPrefabs;
    float size = 2.5f;
    float aspect = 0.625f;

    // Use this for initialization
    void Start () {
   }

    private float lastSpawnTime = 0;
    private float spawnDelay = 2f;

	// Update is called once per frame
	void Update () {
        float size = 5;
        if (Camera.current) {
            size = Camera.current.orthographicSize;
            aspect = Camera.current.aspect;
        }

        if (lastSpawnTime == 0) {
            lastSpawnTime = Time.time;
        }
        if (Time.time - lastSpawnTime > spawnDelay && AsteroidPrefabs.Length > 0)
        {
            Debug.Log("Camera size: " + size);
            lastSpawnTime = Time.time;
            Debug.Log("spawn new object");
            //var scene = SceneManager.GetActiveScene();
            int index = Mathf.RoundToInt(Random.value * (AsteroidPrefabs.Length - 1));
            
            Debug.Log(index);
            var asteroid = Instantiate(AsteroidPrefabs[index], gameObject.transform);
            asteroid.transform.Translate(-size/aspect + Random.value * 2 * size/aspect, 0, 10);
            asteroid.transform.Rotate(Vector3.back, Random.value * 360);
            
          }
	}
}
