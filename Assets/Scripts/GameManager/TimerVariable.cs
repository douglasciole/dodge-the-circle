using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerVariable : MonoBehaviour
{
    public float survivedTime;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

}
