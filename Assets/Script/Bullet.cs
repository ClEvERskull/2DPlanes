using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    float life = 7f;
    public GameObject enemy;
    public static float startX;
	// Use this for initialization
	void Start () {
        enemy = GameObject.Find("Enemy");
        startX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 bulletPosition = transform.position;
        bulletPosition.x += 16 * Time.deltaTime;
        transform.position = bulletPosition;
        life -= Time.deltaTime;
        if (life <= 0)
            Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy.Attack(startX);
            Destroy(gameObject);
        }
    }
}
