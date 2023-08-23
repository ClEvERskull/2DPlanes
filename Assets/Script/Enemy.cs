using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject player;
    public GameObject mybullet;
    public Transform spawn;
    public GameObject coin;
    public Transform itemPosition;
    public GameObject healthPack;
    public static float health;
    public float fullHealth = 3;
    public static bool imDead;
    public static float myX;
    float cooldown = 0.5f;
    int choose;
    public float timeToLive = 10f;
    public float invincibility;

    void Start () {
        player = GameObject.Find("Player");
        imDead = false;
        health = fullHealth;
    }
	
	// Update is called once per frame
	void Update () {
        timeToLive -= Time.deltaTime;
        imDead = false;
        myX = transform.position.x;
        Vector3 planePosition = transform.position;
        if (player != null)
        {
            if (player.transform.position.y > 0.12 + planePosition.y)
                planePosition.y += 3.1f * Time.deltaTime;
            else if (player.transform.position.y < planePosition.y - 0.12)
                planePosition.y -= 3.1f * Time.deltaTime;
            else if ((player.transform.position.y == planePosition.y) || (player.transform.position.y < 0.12 + planePosition.y) & (player.transform.position.y > planePosition.y - 0.12))
            {
                planePosition.y += 0;
                cooldown -= Time.deltaTime;
                if (cooldown <= 0)
                {
                    Instantiate(mybullet, spawn.position, Quaternion.identity);
                    cooldown = 1f;
                }
            }
        }
        planePosition.x -= 8.2f * Time.deltaTime;
        transform.position = planePosition;


        if (health <= 0)
        {
            choose = Random.Range(0, 5);
            if (choose == 2)
                Instantiate(coin, itemPosition.position, Quaternion.identity);
            else if (choose == 4)
                Instantiate(healthPack, itemPosition.position, Quaternion.identity);
            Destroy(gameObject);
            PlayerStats.levelPoints += 20;
        }
        if (timeToLive <= 0)
            Destroy(gameObject);
    }

    public static void Attack(float bulletX)
    {
        if(PlayerStats.level <= 10)
            health -= (3 / (myX - bulletX)) + (PlayerStats.level / 10);
        else
            health -= 2.5f / (myX - bulletX);
    }

}
