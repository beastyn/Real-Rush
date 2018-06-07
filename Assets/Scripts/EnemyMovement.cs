using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float speed = 1f;
    [SerializeField] ParticleSystem attackBaaseeEffect;

    // Use this for initialization
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
       
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
              
            yield return new WaitForSeconds(speed);
        }
        AttackBase();
       
    }

    private void AttackBase()
    {
        var vfxDie = Instantiate(attackBaaseeEffect, transform.position, Quaternion.identity);
        vfxDie.Play();
      
        Destroy(vfxDie.gameObject, vfxDie.main.duration);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {



    }
}


