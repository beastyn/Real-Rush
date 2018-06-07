using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] float secBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] AudioClip spawnenemySFX;

    public int enemyCount = 0;
    

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnTheEnemy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTheEnemy()
    {
        while (true)
        {
          
            GetComponent<AudioSource>().PlayOneShot(spawnenemySFX);
            Instantiate(enemyPrefab.gameObject, transform.position, Quaternion.identity, gameObject.transform);
            SendMessage("OnEnemySpawn");
            yield return new WaitForSeconds(secBetweenSpawns);
        }
    }

}
