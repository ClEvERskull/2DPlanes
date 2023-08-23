using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChoose : MonoBehaviour {
    public Sprite[] planes;
    public int selected;
	// Use this for initialization
	void Start () {
        selected = PlayerPrefs.GetInt("Selected");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = planes[selected];
	}
}
