using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Decider : MonoBehaviour {
    public Canvas guns;
    public Canvas planes;
    public Canvas shop;

    void Start () {
        guns.gameObject.SetActive(false);
        planes.gameObject.SetActive(false);
        shop.gameObject.SetActive(true);
	}
	
	public void buyPlane()
    {
        shop.gameObject.SetActive(false);
        guns.gameObject.SetActive(false);
        planes.gameObject.SetActive(true);
    }

    public void buyGun()
    {
        shop.gameObject.SetActive(false);
        guns.gameObject.SetActive(true);
        planes.gameObject.SetActive(false);
    }
    public void back()
    {
        shop.gameObject.SetActive(true);
        guns.gameObject.SetActive(false);
        planes.gameObject.SetActive(false);
    }



    public void loadLevel(string name)
    {
        Application.LoadLevel(name);
        Time.timeScale = 1;
    }
}
