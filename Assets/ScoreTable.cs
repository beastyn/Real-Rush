using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTable : MonoBehaviour {

    [SerializeField] int score = 0;
    [SerializeField] Text scoreText;
    
    EnemySpawner enemySpawn;

	// Use this for initialization
	void Start () {
        scoreText.text = "0";
	}
    void OnEnemySpawn()
    {
        score++;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
