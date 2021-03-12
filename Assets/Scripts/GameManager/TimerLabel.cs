using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerLabel : MonoBehaviour
{
    public Text timeText;

    private float time = 0;

    void Start()
    {
        timeText = GetComponent<Text>();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= 10)
        {
            timeText.text = string.Format("{0:N2}", time);
        }
        else
        {
            timeText.text = string.Format("0{0:N2}", time);
        }


    }
}
