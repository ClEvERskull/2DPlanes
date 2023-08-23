using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    float life = 7f;
    public GameObject player;
    public static float enemyX;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        enemyX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bulletPosition = transform.position;
        bulletPosition.x -= 16 * Time.deltaTime;
        transform.position = bulletPosition;
        life -= Time.deltaTime;
        if (life <= 0)
            Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
                PlayerStats.Attack(enemyX);
                Destroy(gameObject);
        }
    }
}
