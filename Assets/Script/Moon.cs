using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour {
    public Vector3 position;
    public float speedX = 1;
    public float speedY = 1;
	// Use this for initialization
	void Start () {
        position.x = -0.44f;
        position.y = -0.35f;
    }
	
	// Update is called once per frame
	void Update () {
        if (position.x < 0)
        {
            position = transform.position;
            position.x += speedX * Time.deltaTime;
            position.y += speedY * Time.deltaTime;
            transform.position = position;
        }
        else if (position.x >= 0)
        {
            position = transform.position;
            position.x += speedX * Time.deltaTime;
            position.y -= speedY * Time.deltaTime;
            transform.position = position;
        }
        else if(transform.position.x >= 0.3f)
        {
            position = transform.position;
            position.x = -0.44f;
            position.y = -0.35f;
            transform.position = position;
        }
    }
}
