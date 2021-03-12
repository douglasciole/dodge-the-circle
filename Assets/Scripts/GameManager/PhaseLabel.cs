using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseLabel : MonoBehaviour
{
    public Text phaseText;
    public RingInstantiateScript ringScript;

    void Start()
    {
        phaseText = GetComponent<Text>();
        ringScript = GameObject.Find("GameManager").GetComponent<RingInstantiateScript>();
    }

    void Update()
    {
        switch (ringScript.phase)
        {
            case 5:
                phaseText.text = ("Lvl Max");
                break;
            default:
                phaseText.text = string.Format("Lvl {0}", ringScript.phase);
                break;
        }

    }
}
