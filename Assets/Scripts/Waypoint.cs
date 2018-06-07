using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Waypoint: MonoBehaviour {


    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

   

    Vector2Int onGridPos;
    const int gridSize = 10;
    
   
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

  
    // Update is called once per frame
    void Update ()
    {
      
	}

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
            else
            {
                print("Can`t place it");
            }
        }
        
    }
}
