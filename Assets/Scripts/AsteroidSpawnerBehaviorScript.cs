using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsteroidSpawnerBehaviorScript : MonoBehaviour {

    public GameObject[] AsteroidPrefabs;
    public bool isActive;

    float size = 2.5f;
    float aspect = 0.625f;

    // Use this for initialization
    [RuntimeInitializeOnLoadMethod]
    void Start () {
        Debug.Log("Start AsteroidSpawner");
        StaticBehaviourScript.uiScale = Screen.height / StaticBehaviourScript.defaultWindowHeight;                
    }

    private float lastSpawnTime = 0;
    private float spawnDelay = 4f;

	// Update is called once per frame
	void Update () {
        StaticBehaviourScript.uiScale = Screen.height / StaticBehaviourScript.defaultWindowHeight;
        float size = 5;
        if (Camera.current) {
            size = Camera.current.orthographicSize;
            aspect = Camera.current.aspect;
        }
        if (isActive) {
            Spawn();
        }

	}

    void Spawn() {
        var delay = StaticBehaviourScript.currentDelay;
        if (lastSpawnTime == 0)
        {
            lastSpawnTime = Time.time;
        }
        if (Time.time - lastSpawnTime > spawnDelay && AsteroidPrefabs.Length > 0)
        {
            Debug.Log("Camera size: " + size);
            lastSpawnTime = Time.time - Random.value;
            Debug.Log("spawn new object");
            //var scene = SceneManager.GetActiveScene();
            /*int index = Mathf.RoundToInt(Random.value * (AsteroidPrefabs.Length));
            if (index == AsteroidPrefabs.Length) {
                index = AsteroidPrefabs.Length - 1;
            }*/
            int index = Random.Range(0, AsteroidPrefabs.Length);

            if (index > delay*2.5f) {
                index = Mathf.RoundToInt(delay*2.5f);
            }

            Debug.Log(index);
            var asteroid = Instantiate(AsteroidPrefabs[index], gameObject.transform);
            asteroid.transform.Translate( (-size / aspect) + (Random.value * 2 * size / aspect), 0, 10);
            asteroid.transform.Rotate(Vector3.back, Random.value * 360);
            asteroid.GetComponent<AsteroidBehaviourScript>().rotationSpeed = (-1f + Random.value * 2f) * (1f / (1+Mathf.Pow(index, 2)) );
             

        }
    }
}
