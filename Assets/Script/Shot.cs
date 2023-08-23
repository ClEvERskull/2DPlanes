using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour {
    public GameObject bullet;
    public Transform spawnPosition;
    public Slider gunCooldown;
    public float actualCooldown;
    public float defaultCooldown = 0;
    public float maxCooldown = 3;
    public Button shotButton;
	public void shot()
    {
        Instantiate(bullet, spawnPosition.position, Quaternion.identity);
        actualCooldown += 0.3f;
    }

    void Update()
    {
        gunCooldown.value = actualCooldown;
        if(actualCooldown >= 0)
            actualCooldown -= 0.4f * Time.deltaTime;
        if (actualCooldown >= maxCooldown)
            shotButton.interactable = false;
        else if (actualCooldown <= 1.5f)
            shotButton.interactable = true;
    }
}
