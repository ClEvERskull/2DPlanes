using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    float spawnIt = 21;
    public GameObject speedPowerUp;
    public GameObject powerUp;
    public float spawnPos;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", 0f, spawnIt);
	}
	
	// Update is called once per frame
	void Update () {
        if (powerUp == null)
        {
            spawnIt = Random.Range(8f, 15f);
            if(PlayerStats.level <= 5)
                spawnIt = spawnIt / PlayerStats.level;
            /*while (spawnIt >= 0)
            {
                spawnIt -= Time.deltaTime;
            }
            Spawn();*/
        }
    }

    public void Spawn()
    {
        Vector3 spawnPosition = transform.position;
        spawnPos = Random.Range(-2f, 5f);
        spawnPosition.y = spawnPos;
        transform.position = spawnPosition;


        powerUp = Instantiate(speedPowerUp, spawnPosition, Quaternion.identity);
        powerUp.name = "SpeedUp";
    }
}
