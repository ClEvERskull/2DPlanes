using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float speed = 5;
    public Joystick joystick;
    public float x, y;
    public Vector3 pos;
    public GameObject speedUp;
    public static float powerUpTime = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Plane rotation(UNFINISHED)
       /* Quaternion playerRotation = transform.rotation;
        float z = playerRotation.eulerAngles.z;
            z += joystick.Vertical() * 50 * Time.deltaTime;
            playerRotation = Quaternion.Euler(0, 0, z);
            transform.rotation = playerRotation;*/
        

        //Moving plane, based on readings from joystick
        pos = transform.position;
        x = joystick.Horizontal();
        y = joystick.Vertical();
        if((pos.x >= 0.5) & (pos.x <= 26))
            pos.x += x * speed * Time.deltaTime;
        else if(pos.x < 0.5f)
            pos.x += 0.1f * speed * Time.deltaTime;
        else if(pos.x > 26)
            pos.x -= 0.1f * speed * Time.deltaTime;
        if ((pos.y >= -4.05f) & (pos.y <= 5.35f))
            pos.y += y * speed * Time.deltaTime;
        else if (pos.y < -4.05f)
            pos.y += 0.1f * speed * Time.deltaTime;
        else if (pos.y > 5.35f)
            pos.y -= 0.1f * speed * Time.deltaTime;
        //Vector3 velocity = new Vector3(0, joystick.Horizontal() * 3 * Time.deltaTime, 0);
        //pos += playerRotation * velocity;
        transform.position = pos;


        if (speed > 5)
        {
            powerUpTime -= Time.deltaTime;
            if (powerUpTime <= 0)
                speed = 5;
        }
    }
}
