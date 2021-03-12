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
        float timer = this.GetComponent<RingInstantiateScript>().gameTimer;
        PlayerPrefs.SetFloat("Last_Score", timer);
        var hs = PlayerPrefs.GetFloat("High_Score", 0);
        if (timer > hs)
        {
            PlayerPrefs.SetFloat("High_Score", timer);
        }

        SceneManager.LoadScene("3_ScoreScene", LoadSceneMode.Single);
    }
}
