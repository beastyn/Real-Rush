using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Waypoint: MonoBehaviour {


    public bool isExplored = false;
    public Waypoint exploredFrom;

    public bool isStartPoint = false;
    public bool isEndPoint = false;

    Vector2Int onGridPos;
    const int gridSize = 10;
    [SerializeField] Color exploredColor;

    // Use this for initialization
    void Start ()
    {
        
		
	}

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetOnGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / 10f),
            Mathf.RoundToInt(transform.position.z / 10f)
        );
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRend = transform.Find("top").GetComponent<MeshRenderer>();
        topMeshRend.material.color = color;
    }
    // Update is called once per frame
    void Update ()
    {
        if (isExplored && !isStartPoint && !isEndPoint)
        {
            SetTopColor(exploredColor);
        }
	}
}
