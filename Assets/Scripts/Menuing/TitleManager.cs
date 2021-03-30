using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public AudioSource buttonAudioSource;
    public AudioSource gameAudioSource;

    private void Awake()
    {
        Vibration.QuickVibration();
        Input.backButtonLeavesApp = true;
    }
    public void LoadOptions()
    {
        Vibration.QuickVibration();
        buttonAudioSource.Play();
        SceneManager.LoadScene("2_OptionsScene", LoadSceneMode.Single);
    }

    public void LoadGame()
    {
        Vibration.QuickVibration();
        gameAudioSource.Play();
        SceneManager.LoadScene("G_GameScene", LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Vibration.QuickVibration();
        buttonAudioSource.Play();
        Application.Quit();
    }

}
