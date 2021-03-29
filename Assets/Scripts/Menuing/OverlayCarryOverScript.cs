using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverlayCarryOverScript : MonoBehaviour
{

    private static OverlayCarryOverScript _instance;
    public static OverlayCarryOverScript Instance { get { return _instance; } }

    public Material thisMaterial;

    public AudioSource audioSource;

    void Awake()
    {
        CheckForInstance();

        DontDestroyOnLoad(this.gameObject);

        Color loadedColor = Color.green;
        loadedColor.r = PlayerPrefs.GetFloat("Overlay_R", 0);
        loadedColor.g = PlayerPrefs.GetFloat("Overlay_G", 1);
        loadedColor.b = PlayerPrefs.GetFloat("Overlay_B", 0);

    }
    void OnApplicationQuit()
    {
        Color savedColor = thisMaterial.color;
        PlayerPrefs.SetFloat("Overlay_R", savedColor.r);
        PlayerPrefs.SetFloat("Overlay_G", savedColor.g);
        PlayerPrefs.SetFloat("Overlay_B", savedColor.b);
    }

    void CheckForInstance()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void FixedUpdate()
    {

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "G_GameScene")
        {
            audioSource.enabled = false;
        }
        else
        {
            audioSource.enabled = true;
        }
    }

}
