using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayCarryOverScript : MonoBehaviour
{
    public Material thisMaterial;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        Color loadedColor = Color.green;
        loadedColor.r = PlayerPrefs.GetFloat("Overlay_R", 0);
        loadedColor.g = PlayerPrefs.GetFloat("Overlay_G", 1);
        loadedColor.b = PlayerPrefs.GetFloat("Overlay_B", 0);

    }
    void OnDestroy()
    {
        Color savedColor = thisMaterial.color;
        PlayerPrefs.SetFloat("Overlay_R", savedColor.r);
        PlayerPrefs.SetFloat("Overlay_G", savedColor.g);
        PlayerPrefs.SetFloat("Overlay_B", savedColor.b);
    }

}
