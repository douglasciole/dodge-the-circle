﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScaleScript : MonoBehaviour
{
    public float scale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = new Vector3(0.1f * scale, 0.1f * scale, 1);
    }
}
