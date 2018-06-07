using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform parentForTowers;
    [SerializeField] int towerLimit = 3;

    int towerCount = 0;
    Queue<Tower> towers = new Queue<Tower>();
  
    public void AddTower(Waypoint baseWaypoint)
    {
        
        if (towerCount < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Tower placedTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity, parentForTowers);
        
        baseWaypoint.isPlaceable = false;
        placedTower.baseWaypoint = baseWaypoint;

        towers.Enqueue(placedTower);
        towerCount = towers.Count;
    }

    private void MoveExistingTower(Waypoint baseWaypoint)
    {
        var firstInLineTower = towers.Dequeue();

        firstInLineTower.baseWaypoint.isPlaceable = true;
        baseWaypoint.isPlaceable = false;

        firstInLineTower.baseWaypoint = baseWaypoint;
        firstInLineTower.transform.position = baseWaypoint.transform.position;
  
        towers.Enqueue(firstInLineTower);
    }


}
