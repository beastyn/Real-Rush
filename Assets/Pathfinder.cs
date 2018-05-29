using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;

    public List<Waypoint> path = new List<Waypoint>(); //todo make private

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    
    // Use this for initialization
    void Start () {
        LoadBlocks();
        SetStartEndColor();
        BreadthFirstSearchLogic();
        CreatePath();
      
		
	}

    private void CreatePath()
    {
        path.Add(endWaypoint);
        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        
    }

    private void BreadthFirstSearchLogic()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            StopIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;

        }
        print("Finish pathfinding");
    }

    private void StopIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {

            print("You are at the finish point"); // TODO remove log
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourPosition = searchCenter.GetOnGridPos() + direction;
            try
            {
                QueueNewNeighbours(neighbourPosition);
            }
            catch
            {
                //do nothing
            }
         
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourPosition)
    {
        Waypoint neighbour = grid[neighbourPosition];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            //do nothing
        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        

        foreach (Waypoint waypoint in waypoints)
        {
            var onGridPos = waypoint.GetOnGridPos();
     
            if (grid.ContainsKey(onGridPos))
            {
                Debug.LogWarning("Overlapping" + waypoint);
            }
            else
            {
                grid.Add(onGridPos, waypoint);
                waypoint.SetTopColor(Color.grey);
            }                  
        }
        print(grid.Count);
    }

    void SetStartEndColor()
    {
        startWaypoint.SetTopColor(Color.green);
        startWaypoint.isStartPoint = true;
        endWaypoint.SetTopColor(Color.red);
        endWaypoint.isEndPoint = true;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
