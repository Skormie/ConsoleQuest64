using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCombo : MonoBehaviour
{
    public string[] buttons;
    private int currentIndex = 0; //moves along the array as buttons are pressed

    public float allowedTimeBetweenButtons = 0.3f; //tweak as needed
    private float timeLastButtonPressed;

    public KeyCombo(string[] b)
    {
        buttons = b;
    }

    //usage: call this once a frame. when the combo has been completed, it will return true
    public bool Check()
    {
        if (Time.time > timeLastButtonPressed + allowedTimeBetweenButtons) currentIndex = 0;
        {
            if (currentIndex < buttons.Length)
            {
                if ((buttons[currentIndex] == "down" && Input.GetAxisRaw("Vertical") == -1) ||
                (buttons[currentIndex] == "3" && Input.GetAxisRaw("Vertical") == -1 && Input.GetAxisRaw("Horizontal") == 1) || //Diagonal Down Forward
                (buttons[currentIndex] == "1" && Input.GetAxisRaw("Vertical") == -1 && Input.GetAxisRaw("Horizontal") == -1) || //Diagonal Down Backward
                (buttons[currentIndex] == "up" && Input.GetAxisRaw("Vertical") == 1) ||
                (buttons[currentIndex] == "9" && Input.GetAxisRaw("Vertical") == 1 && Input.GetAxisRaw("Horizontal") == 1) || //Diagonal Up Forward
                (buttons[currentIndex] == "7" && Input.GetAxisRaw("Vertical") == 1 && Input.GetAxisRaw("Horizontal") == -1) || //Diagonal Up Forward
                (buttons[currentIndex] == "left" && Input.GetAxisRaw("Vertical") == -1) ||
                (buttons[currentIndex] == "right" && Input.GetAxisRaw("Horizontal") == 1)) //||
                //(buttons[currentIndex] != "down" && buttons[currentIndex] != "up" && buttons[currentIndex] != "left" && buttons[currentIndex] != "right" && Input.GetButtonDown(buttons[currentIndex])))
                {
                    timeLastButtonPressed = Time.time;
                    currentIndex++; 
                }

                if (currentIndex >= buttons.Length)
                {
                    currentIndex = 0;
                    return true;
                }
                else return false;
            }
        }

        return false;
    }

    private static KeyCombo falconPunch = new KeyCombo(new string[] { "down", "right", "right" });
    private static KeyCombo falconKick = new KeyCombo(new string[] { "down", "right", "Fire1" });
    private static KeyCombo qcf = new KeyCombo(new string[] { "down", "3", "right" });

    // Update is called once per frame
    void Update()
    {
        var v3 = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        Debug.Log(v3.normalized);
        if (falconPunch.Check())
        {
            // do the falcon punch
            Debug.Log("PUNCH");
        }
        if (qcf.Check())
        {
            // do the falcon punch
            Debug.Log("qcf");
        }
        if (falconKick.Check())
        {
            // do the falcon punch
            Debug.Log("KICK");
        }
    }
}