using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaScript : MonoBehaviour {
    private float arcSpeed;
    public float startDistance = 2f;
    public float maxDistance = 20f;

    public float maxWaveDistance = 5f;

    private static int right = 1;
    private static int left = -1;

    public Arc arcPrefab;
    private List<Arc> arcs = new List<Arc>();
    private List<Arc> inActiveArcs = new List<Arc>();
    private bool sendingSignal = false;

    public float startScale = 1f;
    public float moveRate = 0.01f;

    private float distance;
    private float interval;

    private float nextSpawnTime;
    private Transform earth;
    private Transform satellite;
    private AudioClip beepSend;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 20; i++)
        {
            Arc newArc = Instantiate(arcPrefab).GetComponent<Arc>();
            inActiveArcs.Add(newArc);
        }
        earth = GameObject.Find("Earth").transform;
        earth.localScale = Vector3.one * startScale;
        distance = startDistance;
        satellite = GameObject.Find("Satellite").transform;
        beepSend = Resources.Load<AudioClip>("beepsend1");
        audioSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (distance < maxDistance)
        {
            distance += Time.deltaTime * moveRate;
        }
        arcSpeed = 10 / distance;
        interval = 1 / arcSpeed;
        StaticBehaviourScript.currentDelay = (satellite.position.y - transform.position.y) / arcSpeed;
        earth.localScale = Vector3.one * (startDistance / distance);

        float moveHorizontal = Input.GetAxis("Horizontal");

        //touch me
        float pos;
        int width = Screen.width;
        if (Input.touches.Length > 0)
        {
            pos = Input.touches[0].position.x - width / 2;
            //    Debug.Log("position" + pos);
            moveHorizontal = pos / (width / 2);
        }

        if (moveHorizontal > 0f)
        {
            SendSignal(right);

            if (Time.time >= nextSpawnTime)
            {
                Arc newArc;
                if (inActiveArcs.Count == 0)
                {
                    newArc = Instantiate(arcPrefab).GetComponent<Arc>();
                    newArc.Activate();
                }
                else
                {
                    Debug.Log(inActiveArcs.Count);
                    newArc = inActiveArcs[0];
                    inActiveArcs.Remove(newArc);
                    newArc.Activate();
                }
                newArc.SetColor(Color.magenta);
                arcs.Add(newArc);
                nextSpawnTime = Time.time + interval;
            }
        }
        else if (moveHorizontal < 0f)
        {
            SendSignal(left);

            if (Time.time >= nextSpawnTime)
            {
                Arc newArc;
                if (inActiveArcs.Count == 0)
                {
                    newArc = Instantiate(arcPrefab).GetComponent<Arc>();
                    newArc.Activate();
                }
                else
                {
                    newArc = inActiveArcs[0];
                    inActiveArcs.Remove(newArc);
                    newArc.Activate();
                }
                newArc.SetColor(Color.cyan);
                arcs.Add(newArc);
                nextSpawnTime = Time.time + interval;
            }
        }
        else
        {
            sendingSignal = false;
            nextSpawnTime = 0f;
        }

        for(int i = arcs.Count - 1; i >= 0; i--)
        {
            Arc arc = arcs[i];
            if (arc.radius > maxDistance)
            {
                arcs.Remove(arc);
                arc.DeActivate();
                inActiveArcs.Add(arc);
                continue;
            }
            else
            {
                arc.IncreaseDistance(arcSpeed * Time.deltaTime);
                arc.SetAlpha(1f - arc.radius / maxWaveDistance);
            }
        }
    }

    void SendSignal(int direction)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(beepSend);
        }
        sendingSignal = true;
        if (direction == right)
        {

        }
        else if (direction == left)
        {

        }
    }

    void SpawnArcs()
    {

    }
}
