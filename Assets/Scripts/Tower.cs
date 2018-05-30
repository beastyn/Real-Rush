using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    [SerializeField] Transform objectToPan;
    [SerializeField] ParticleSystem turretFire;
    [SerializeField] float fireRange = 10f;

    Transform targetEnemy;


    // Use this for initialization
    void Start () {
        var turretFireEmit = turretFire.emission;
    }
	
	// Update is called once per frame
	void Update () {

        SetTargetEnemy();
        if (targetEnemy)
        {
            ProcessFiring();
        }
        else
        {
            Shoot(false);
        }
	}

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        float distanceToB = Vector3.Distance(transformB.position, transform.position);
        float distanceToA = Vector3.Distance(transformA.position, transform.position);
        if (distanceToB <= distanceToA)
        {
            return transformB;
        }
        return transformA;
    }

    void ProcessFiring()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.position, transform.position);
        if (distanceToEnemy <= fireRange)
        {
            objectToPan.LookAt(targetEnemy);
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
        
    }

    private void Shoot(bool isActive)
    {
        var turretFireEmit = turretFire.emission;
        turretFireEmit.enabled = isActive;
    }
}
