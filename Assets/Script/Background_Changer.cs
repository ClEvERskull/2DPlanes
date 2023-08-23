using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Changer : MonoBehaviour {
    public float startTime = 40;
    public float timeToChange;
    public Material[] Backgrounds;
    public MeshRenderer Renderer;
    // Use this for initialization
    void Start () {
        Renderer = GetComponent<MeshRenderer>();
        timeToChange = startTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (timeToChange >= 0)
            timeToChange -= 1 * Time.deltaTime;
        else if (timeToChange <= 0)
        {
            int number = Random.Range(0, Backgrounds.Length);
            Renderer = GetComponent<MeshRenderer>();
            if (Backgrounds[number] != null)
            {
                Renderer.material = Backgrounds[number];
                timeToChange = startTime;
            }
        }
    }
}
