using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    // this value can be changed
    public float rotateSpeed;

    public GameObject player;

    public Button l_button, r_button;
    public bool l_pressed, r_pressed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        l_button = transform.GetChild(0).transform.Find("L_Button").GetComponent<Button>();
        r_button = transform.GetChild(0).transform.Find("R_Button").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (l_pressed && !r_pressed)
        {
            player.transform.Rotate(Vector3.forward * rotateSpeed);
        }
        if (r_pressed && !l_pressed)
        {
            player.transform.Rotate(Vector3.back * rotateSpeed);
        }
    }

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

