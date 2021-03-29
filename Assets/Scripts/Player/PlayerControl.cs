using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    public float maxRotateSpeed, accelSpeed;
    public float rotateSpeed;

    public GameObject player;
    public Button l_button, r_button;
    public bool l_pressed, r_pressed;

    void Start()
    {
        player = GameObject.Find("Player");
        l_button = transform.GetChild(0).transform.Find("L_Button").GetComponent<Button>();
        r_button = transform.GetChild(0).transform.Find("R_Button").GetComponent<Button>();
    }

    void Update()
    {

        if (l_pressed && !r_pressed)
        {
            // Vibration.QuickVibration();
            player.transform.Rotate(Vector3.forward * RotateSpeed(true));
        }
        else if (r_pressed && !l_pressed)
        {
            // Vibration.QuickVibration();
            player.transform.Rotate(Vector3.back * RotateSpeed(true));
        }
        else
        {
            RotateSpeed(false);
        }
    }

    float RotateSpeed(bool accelMode)
    {
        if (accelMode == false)
        {
            rotateSpeed = 0;
        }
        if (rotateSpeed < maxRotateSpeed)
        {
            rotateSpeed += accelSpeed;
        }
        return rotateSpeed;

    }

    //Editor buttons methods
    public void L_ButtonDown()
    {
        l_pressed = true;
    }
    public void L_ButtonUp()
    {
        l_pressed = false;
    }
    public void R_ButtonDown()
    {
        r_pressed = true;
    }
    public void R_ButtonUp()
    {
        r_pressed = false;
    }

}

