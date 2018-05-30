using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] float secBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;


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
           
            GameObject enemy = Instantiate(enemyPrefab.gameObject, transform.position, Quaternion.identity);
            enemy.transform.parent = gameObject.transform;

            yield return new WaitForSeconds(secBetweenSpawns);
        }
    }

}
