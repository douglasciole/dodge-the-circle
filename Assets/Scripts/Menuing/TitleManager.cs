using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    private void Awake()
    {
        Vibration.QuickVibration();
        Input.backButtonLeavesApp = true;
    }
    public void LoadOptions()
    {
        Vibration.QuickVibration();
        SceneManager.LoadScene("2_OptionsScene", LoadSceneMode.Single);
    }

    public void LoadGame()
    {
        Vibration.QuickVibration();
        SceneManager.LoadScene("G_GameScene", LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Vibration.QuickVibration();
        Application.Quit();
    }

}
