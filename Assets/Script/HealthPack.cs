using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= -4.2f)
            Destroy(gameObject);

        Vector3 healthPosition = transform.position;
        healthPosition.y -= 2.5f * Time.deltaTime;
        healthPosition.x -= 2f * Time.deltaTime;
        transform.position = healthPosition;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            PlayerStats.health = PlayerStats.sharedHealth;
            Destroy(gameObject);
        }
    }
}
