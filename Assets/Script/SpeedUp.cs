using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {

    public float liveTime = 7;
	// Use this for initialization
	void Start () {
        liveTime = 12;
	}
	
	// Update is called once per frame
	void Update () {
        liveTime -= Time.deltaTime;
        if ((liveTime <= 0) || (transform.position.x == -12))
            Destroy(gameObject);

        Vector3 position = transform.position;
        position.x -= 6 * Time.deltaTime;
        transform.position = position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.speed = 9;
            Player.powerUpTime = 5;
            Destroy(gameObject);
        }
    }
}
