using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    float spawnAgain = 6f;
    float spawnNow ;
    public Player player;
    public GameObject enemy;
    public GameObject copter;
    public GameObject Enemy;
    public int number;
	// Use this for initialization
	void Start () {
        spawnNow = 0;
	}
	
	// Update is called once per frame
	void Update () {
        spawnNow -= Time.deltaTime;
        if (spawnNow <= 0)
        {
            //presun sa na player y
            //spawni enemy
            Vector3 spawnPosition = transform.position;
            spawnPosition.y = player.pos.y;
            transform.position = spawnPosition;
            if (PlayerStats.level >= 3)
            {
                number = Random.Range(1, 3);
                if(number == 1)
                    Enemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
                else if(number == 2)
                    Enemy = Instantiate(copter, spawnPosition, Quaternion.identity);
            }
            else
                Enemy = Instantiate(enemy, spawnPosition, Quaternion.identity);

            Enemy.name = "Enemy";
            spawnAgain = Random.Range(2f, 8f);
            spawnNow = spawnAgain;
        }
	}
}
