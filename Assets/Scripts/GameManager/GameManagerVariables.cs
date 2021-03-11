using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerVariables : MonoBehaviour
{
    public float ringSpeed;
    public float ringMaxSize;
    public bool collisionFlag;
    public int collisionCounter;

    public int maxLives;


    void Start()
    {

    }

    private void LateUpdate()
    {
        if (collisionFlag)
        {
            collisionCounter++;
            collisionFlag = false;
        }
        if (collisionCounter > maxLives)
        {
            EndGameTransition();
        }
    }

    void EndGameTransition()
    {
        SceneManager.LoadScene("3_ScoreScene", LoadSceneMode.Single);
    }
}
