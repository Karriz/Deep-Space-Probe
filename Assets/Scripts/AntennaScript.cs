using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaScript : MonoBehaviour {
    public float arcSpeed = 5f;
    public float maxDistance = 20f;

    private static int right = 1;
    private static int left = -1;

    public Arc arcPrefab;
    private List<Arc> arcs = new List<Arc>();
    private List<Arc> inActiveArcs = new List<Arc>();
    private bool sendingSignal = false;

    public float startScale = 0.5f;
    public float shrinkRate = 0.01f;

    private float distance;
    private float interval;

    private float nextSpawnTime;
    private Transform earth;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 20; i++)
        {
            Arc newArc = Instantiate(arcPrefab).GetComponent<Arc>();
            inActiveArcs.Add(newArc);
        }
        earth = GameObject.Find("Earth").transform;
        earth.localScale = Vector3.one * startScale;
        distance = 1 / startScale;
    }
	
	// Update is called once per frame
	void Update () {
        arcSpeed -= 0.5f * Time.deltaTime * shrinkRate;
        interval = 1 / arcSpeed;
        distance += Time.deltaTime * shrinkRate;
        earth.localScale = Vector3.one / distance;
		if (Input.GetAxis("Horizontal") > 0f)
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
        else if (Input.GetAxis("Horizontal") < 0f)
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
                arc.SetAlpha(1f - arc.radius / maxDistance);
            }
        }
    }

    void SendSignal(int direction)
    {
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
