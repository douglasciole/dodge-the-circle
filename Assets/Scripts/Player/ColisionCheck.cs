using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionCheck : MonoBehaviour
{

    public GameManagerVariables gameManagerVariables;

    void Start()
    {
        gameManagerVariables = GameObject.Find("GameManager").GetComponent<GameManagerVariables>();

    }

    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.tag == "Ring")
            gameManagerVariables.collisionFlag = true;
    }
}
