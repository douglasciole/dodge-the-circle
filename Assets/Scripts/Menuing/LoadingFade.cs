using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingFade : MonoBehaviour
{
    public float initialTimer, fadeInTimer, stayTimer, fadeOutTimer;
    public Color initialFade;

    public float timer;
    private float t;

    public Image img;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    void Update()
    {
        if (timer > (initialTimer + fadeInTimer + stayTimer + fadeOutTimer))
        {
            LoadMenu();
        }
        else if (timer > (initialTimer + fadeInTimer + stayTimer))
        {
            img.color = Color.Lerp(Color.white, initialFade, t);
            t += Time.deltaTime / fadeOutTimer;
        }
        else if (timer > (initialTimer + fadeInTimer))
        {
            t = 0;
        }
        else if (timer > initialTimer)
        {
            img.color = Color.Lerp(initialFade, Color.white, t);
            t += Time.deltaTime / fadeInTimer;
        }

        timer += Time.deltaTime;

    }

    void LoadMenu()
    {
        Debug.Log("Load the game");
    }
}
