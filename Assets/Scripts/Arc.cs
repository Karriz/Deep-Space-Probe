using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arc : MonoBehaviour {
    LineRenderer lineRenderer;
    public float radius;
    float startAngle = 3f * Mathf.PI / 8f;
    float arcAngle = Mathf.PI / 4f;
    bool activated = false;
    Color color;
    Transform antenna;
	// Use this for initialization
	void Start () {
        antenna = GameObject.Find("Antenna").transform;
        lineRenderer = GetComponent<LineRenderer>();
        radius = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateArcPoints();
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
	}

    void UpdateArcPoints()
    {
        if (activated)
        {
            for (int i = 0; i < lineRenderer.positionCount; i++)
            {
                lineRenderer.SetPosition(i, CalculateArcPoint(antenna.position, radius, startAngle + ((float)i / (lineRenderer.positionCount - 1f)) * arcAngle));
            }
        }
    }

    Vector2 CalculateArcPoint(Vector2 center, float r, float angle)
    {
        return new Vector2(center.x + r * Mathf.Cos(angle), center.y + r * Mathf.Sin(angle));
    }

    public void SetColor(Color c)
    {
        color = c;
    }

    public void SetAlpha(float a)
    {
        color.a = a;
    }

    public void SetDistance(float r)
    {
        radius = r;
    }

    public void IncreaseDistance(float amount)
    {
        radius += amount;
    }

    public void DeActivate()
    {
        activated = false;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(-100, -100, 0));
        }
    }

    public void Activate()
    {
        radius = 0f;
        activated = true;
        lineRenderer = GetComponent<LineRenderer>();
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(0f, -10f, 0f));
        }
    }
}
