using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text lastTime;
    public TimerVariable timerVariable;

    // Start is called before the first frame update
    void Start()
    {
        timerVariable = GameObject.Find("TimerVariable").GetComponent<TimerVariable>();
        lastTime.text = timerVariable.survivedTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
