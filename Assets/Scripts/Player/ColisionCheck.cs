using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionCheck : MonoBehaviour
{

    public GameManagerVariables gameManagerVariables;
    public GameObject shield;

    public AudioSource hitSound, shieldSound;

    void Start()
    {
        gameManagerVariables = GameObject.Find("GameManager").GetComponent<GameManagerVariables>();

    }

    void Update()
    {
        if (gameManagerVariables.collisionCounter < 0)
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Ring")
        {
            hitSound.Play();
            gameManagerVariables.collisionFlag = true;
        }
        if (other.transform.tag == "Bonus")
        {
            shieldSound.Play();
            gameManagerVariables.bonusFlag = true;
        }

    }
}
