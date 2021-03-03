using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerLabel : MonoBehaviour
{
    public Text timeText;

    private float time = 0;
    private int min = 0;

    void Start()
    {
        timeText = GetComponent<Text>();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= 60)
        {
            min++;
            time -= 60;
        }

        timeText.text = string.Format("{0:}:{1:N2}", min, time);
    }
}
