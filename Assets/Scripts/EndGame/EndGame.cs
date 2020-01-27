using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public bool collisionFlag;
    public GameManagerVariables gameManagerScript;
    public Canvas endCanvas;
    public Text lastTime;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerVariables>();
        GameObject.Find("EndCanvas").GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.collisionFlag == true)
        {
            lastTime = GameObject.Find("Canvas").GetComponentInChildren<Timer>().timeText;
            GameObject.Find("EndCanvas").GetComponent<Canvas>().enabled = true;
        }
    }
}
