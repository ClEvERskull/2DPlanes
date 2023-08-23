using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    public Slider healthSlider;
    public Slider speedSlider;
    public Slider levelSlider;
    public Text levelNumber;
    public Text scoreNow;
    public Canvas playerUI;
    public Canvas deathCanvas;
    public Text coins;
    public Text earnedCash;
    
    public static int levelPoints;
    public static float health;
    public float fullHealth = 6f;
    public static int level = 1;
    public static int cash;
    public static float sharedHealth;
    public static float myX;
    public int maxScore = 0;
    public int score = 0;
    float speedUp = 0;
    void Start()
    {
        levelSlider.maxValue = level * 200;
        health = fullHealth;
        playerUI.gameObject.SetActive(true);
        deathCanvas.gameObject.SetActive(false);
        level = 1;
        levelPoints = 0;
        cash = PlayerPrefs.GetInt("cash");
        maxScore = PlayerPrefs.GetInt("maxScore");
        score = 0;
    }
    
    void Update()
    {
        speedUp = Player.powerUpTime;
        sharedHealth = fullHealth;
        levelNumber.text = level.ToString();
        earnedCash.text = cash.ToString();
        healthSlider.value = health;
        speedSlider.value = speedUp;
        levelSlider.value = levelPoints;
        score = levelPoints;

        myX = transform.position.x;
        if (health <= 0)
        {
            Death();
        }
        
        if (levelPoints >= level * 200)
        {
            level++;
            fullHealth++;
            cash += level;
            levelSlider.maxValue = level * 200;
            levelPoints -= (level-1) * 200;
        }
    }
    void Death()
    {
        PlayerPrefs.SetInt("cash", cash);
        coins.text = "Cash earned: " + cash.ToString();
        scoreNow.text = "My score: " + score.ToString();
        if (score > maxScore)
        {
            maxScore = score;
            PlayerPrefs.SetInt("Score", maxScore);
        }
        Destroy(gameObject);
        playerUI.gameObject.SetActive(false);
        deathCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    
    public static void Attack(float enemyX)
    {
        if (myX <= enemyX)
        {
            if (level < 4)
                health -= 3 / (enemyX - myX);
            else if((level >= 4) & (level < 12))
                health -= 4 / (enemyX - myX);
            else if ((level >= 12) & (level < 20))
                health -= 4.4f / (enemyX - myX);
            else if (level >= 20)
                health -= 5 / (enemyX - myX);
        }
    }
}

