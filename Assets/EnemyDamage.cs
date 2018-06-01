using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] ParticleSystem dieEffect;

    // Use this for initialization
    void Start() {

    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints<1)
        {
            KillEnemy();
        }
    }

 
     void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitEffect.Play();
    }

    private void KillEnemy()
    {
        var instDieEffect = Instantiate(dieEffect, transform.position, Quaternion.identity);
        //instDieEffect.transform.parent = gameObject.transform;
        Destroy(gameObject);
       
    }
}
