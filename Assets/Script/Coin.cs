using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    GameObject player;
    int howMuch;
    public float liveTime = 8;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
    void Update()
    {
        liveTime -= Time.deltaTime;
        if ((liveTime <= 0) || (transform.position.x == -12))
            Destroy(gameObject);

        Vector3 coinPosition = transform.position;
        coinPosition.x -= 5 * Time.deltaTime;
        transform.position = coinPosition;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            howMuch = Random.Range(0, 11);
            PlayerStats.cash += PlayerStats.level * howMuch;
            Destroy(gameObject);
        }
    }
}
