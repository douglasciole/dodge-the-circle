using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionCheck : MonoBehaviour
{
    public bool collisionFlag;
    public GameManagerVariables gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerVariables>();
        gameManagerScript.collisionFlag = collisionFlag;
    }

    // Update is called once per frame
    void Update()
    {
        
        // gameManagerScript.collisionFlag = true;

    }

    void OnTriggerEnter2D(Collider2D other) 
    {    
        collisionFlag = true;
        if(other.transform.tag == "Ring")
            gameManagerScript.collisionFlag = true;
    }
}
