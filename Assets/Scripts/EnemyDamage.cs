using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] ParticleSystem dieEffect;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip deathSFX;
   

    // Use this for initialization
    void Start() {

    }

    private void OnParticleCollision(GameObject other)
    {
        print("Hit");
        ProcessHit();
        if (hitPoints<1)
        {
            KillEnemy();
        }
    }

 
     void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        GetComponent<AudioSource>().PlayOneShot(hitSFX);
        hitEffect.Play();


    }

    private void KillEnemy()
    {
        var vfxDie = Instantiate(dieEffect, transform.position, Quaternion.identity);
        vfxDie.Play();
        Destroy(vfxDie.gameObject, vfxDie.main.duration);
      
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
        Destroy(gameObject);
       
    }
}
