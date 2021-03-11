using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void LoadOptions()
    {
        SceneManager.LoadScene("2_OptionsScene", LoadSceneMode.Single);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("G_GameScene", LoadSceneMode.Single);
    }
    
}
