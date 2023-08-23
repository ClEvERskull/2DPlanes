using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneShop : MonoBehaviour {
    public Image previousPlane;
    public Image plane;
    public Image nextPlane;
    public Sprite[] planes;
    public int number;
    public int previous;
    public int next;
    public static int price;

    public Text cost;
    public Text money;

    public static int cash;

    public Button buy;


    public bool[] isBought;
    public bool[] selected;

    public static int lastSelected;
    // Use this for initialization
    void Start () {
        number = 0;
        nextPlane.sprite = planes[next];
        previousPlane.sprite = planes[previous];
        //PlayerPrefs.SetInt("cash", 250);
        cash = PlayerPrefs.GetInt("cash");

        for (int i = 0; i < planes.Length; i++)
        {
            if ((PlayerPrefs.GetInt("bought" + i)) != 0)
                isBought[i] = true;
            else
                isBought[i] = false;
        }

        lastSelected = PlayerPrefs.GetInt("Selected");
        selected[lastSelected] = true;
    }

    void Update()
    {
         if (plane != null)
            plane.sprite = planes[number];

        if (nextPlane != null)
        {
            if (next <= 6)
                nextPlane.sprite = planes[next];
            else 
            {
                next = 0;
                nextPlane.sprite = planes[0];
            }
        }


        if (previousPlane != null)
        {
            if ((previous <= 6) & (previous >= 0))
                previousPlane.sprite = planes[previous];
            else
            {
                previous = 6;
                previousPlane.sprite = planes[6];
            }
        }


        price = number * 500;
        if(isBought[number] != true)
            cost.text = price.ToString();
        else if((isBought[number] == true) & (selected[number] == true))
            cost.text = "Selected!";
        else if ((isBought[number] == true) & (selected[number] != true))
            cost.text = "Select";

        money.text = "Money: " + cash.ToString();
        PlayerPrefs.SetInt("cash", cash);

        if ((cash >= price) & (isBought[number] != true))
            buy.interactable = true;
        else if ((isBought[number] == true) & (selected[number] == true))
            buy.interactable = false;
        else if((isBought[number] == true) & (selected[number] != true))
            buy.interactable = true;
    }

    public void clickRight()
    {
        if (number < (planes.Length - 1))
        {
            number++;
        }
        else
        {
            plane.sprite = planes[0];
            number = 0;
        }
        next = number + 1;
        previous = number - 1;
    }

    public void clickLeft()
    {
        if (number == 0)
        {
            plane.sprite = planes[6];
            number = 6;
        }
        else if (number <= 6)
            number--;

        next = number + 1;
        previous = number - 1;
    }


    public void Buy()
    {
        if (isBought[number] != true)
        {
            cash -= price;
            PlayerPrefs.SetInt("bought" + number, 1);
            isBought[number] = true;
        }
        for(int i = 0; i < planes.Length; i++)
        {
            if (selected[i] == true)
                selected[i] = false;
        }
        selected[number] = true;
        PlayerPrefs.SetInt("Selected", number);
    }
}
