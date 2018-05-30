using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;

    List<Waypoint> path = new List<Waypoint>(); 

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left 
    };
    
    private void CreatePath()
    {
        SetAsPath(endWaypoint);

        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            SetAsPath(previous);
            previous = previous.exploredFrom;
        }
        SetAsPath(startWaypoint);
        path.Reverse();
    }

    private void SetAsPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceable = false;
    }

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            BreadthFirstSearchLogic();
            CreatePath();
        }
            return path;
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
       
    }

    private void StopIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
           isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourPosition = searchCenter.GetOnGridPos() + direction;
           if (grid.ContainsKey(neighbourPosition))
            {
                QueueNewNeighbours(neighbourPosition);
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
          
            }                  
        }
        
    }



 
}
