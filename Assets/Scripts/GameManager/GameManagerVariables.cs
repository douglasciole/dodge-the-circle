using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerVariables : MonoBehaviour
{
    public float ringSpeed;
    public float ringMaxSize;
    public bool collisionFlag;
    public bool bonusFlag;
    public int collisionCounter;

    public int maxLives;
    public int maxShields;

    public float endgameTransitionTime;
    public GameObject player;
    public GameObject particles;
    public AudioSource endGameSound;
    private bool endSoundPlayed;

    private void LateUpdate()
    {
        if (collisionFlag)
        {
            collisionCounter++;
            collisionFlag = false;
        }
        if (bonusFlag)
        {
            if (collisionCounter > maxShields)
            {
                collisionCounter--;
            }
            bonusFlag = false;
        }
        if (collisionCounter > maxLives)
        {
            EndGameTransition();
        }
    }

    [ContextMenu("EndGameTransition")]
    void EndGameTransition()
    {

        //Score making
        float timer = this.GetComponent<RingInstantiateScript>().gameTimer;
        PlayerPrefs.SetFloat("Last_Score", timer);
        var hs = PlayerPrefs.GetFloat("High_Score", 0);
        if (timer > hs)
        {
            PlayerPrefs.SetFloat("High_Score", timer);
        }


        //Transition
        Vibration.LongVibration();
        this.GetComponent<ColorChangeScript>().enabled = false;
        this.GetComponentInChildren<CameraBehaviour>().enabled = false;
        this.GetComponentInChildren<Canvas>().enabled = false;
        player.SetActive(false);
        if (particles.GetComponent<ParticleSystem>().isPlaying == false)
        {
            particles.GetComponent<ParticleSystem>().Play();
        }
        if (!endSoundPlayed)
        {
            endGameSound.Play();
            endSoundPlayed = true;
        }

        //Start countdown
        StartCoroutine(NextScene());

    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(endgameTransitionTime);
        SceneManager.LoadScene("3_ScoreScene", LoadSceneMode.Single);
    }

}
