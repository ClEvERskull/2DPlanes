using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimator : MonoBehaviour
{
    public Image quit;
    public Image play;
    public Sprite quit00;
    public Sprite quit01;
    public Sprite quit02;
    public Sprite play00;
    public Sprite play01;
    public int click;
    // Use this for initialization
    void Start()
    {
        click = 0;
        if(quit != null)
            quit.sprite = quit00;
        if(play != null)
            play.sprite = play00;
    }
    void Update()
    {
        if(quit != null)
            if(click == 0)
                quit.sprite = quit00;
    }
    public void pressedQuit()
    {
        if (click == 0)
        {
            quit.sprite = quit01;
            click++;
        }
        else if (click == 1)
        {
            quit.sprite = quit02;
            click++;
        }
        else if (click == 2)
        {
            Application.Quit();
            click = 0;
        }
    }

    public void pressedPlay()
    {
        play.sprite = play01;
    }
}